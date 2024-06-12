using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class DatabaseManager : MonoBehaviour
{
    private string connectionString;
    private IDbConnection dbConnection;

    public Text inputField;
    public Text applesText;
    public Text usernames;
    public Text scores;

    void Start()
    {
        string dbName = "AOTW.db";
        string dbPath = "URI=file:" + Application.dataPath + "/Database/" + dbName;
        connectionString = dbPath;

        if (!DatabaseExists(dbPath))
        {
            CreateDatabase();
        }

        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();

        ShowScoreboard();
    }

    public void ShowScoreboard()
    {
        string dbName = "AOTW.db";
        string dbPath = "URI=file:" + Application.dataPath + "/Database/" + dbName;
        scores.text = "";
        usernames.text = "";

        using(var connection = new SqliteConnection(dbPath))
        {
            connection.Open();

            using(var command =  connection.CreateCommand())
            {
                command.CommandText = "SELECT PlayerName, AppleCount FROM Player ORDER BY AppleCount DESC LIMIT 10";

                using(IDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        usernames.text += reader["PlayerName"] + "\n";
                        scores.text += reader["AppleCount"] + "\n";
                    }

                    reader.Close();
                }
            }

            connection.Close();
        }
    }

    public bool DatabaseExists(string dbPath)
    {
        return System.IO.File.Exists(dbPath);
    }

    public void CreateDatabase()
    {
        IDbConnection tempConnection = new SqliteConnection(connectionString);
        tempConnection.Open();

        IDbCommand dbCommand = tempConnection.CreateCommand();

        dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS Player (ID INTEGER PRIMARY KEY AUTOINCREMENT, PlayerName TEXT UNIQUE, AppleCount INTEGER)";
        dbCommand.ExecuteNonQuery();

        tempConnection.Close();

        Debug.Log("Succesful");
    }

    public void AddPlayer()
    {
        string playerName = inputField.text;
        string text = applesText.text;

        string appleCountString = text.Replace("Apples: ", " ");
        int appleCount = int.Parse(appleCountString);

        if (IsPlayerNameUnique(playerName))
        {
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = $"INSERT INTO Player (PlayerName, AppleCount) VALUES ('{playerName}', '{appleCount}')";
            dbCommand.ExecuteNonQuery();

            Debug.Log(playerName + " " + appleCount.ToString());
        }
        else
        {
            Debug.LogError("A player with the same name already exists.");
        }
    }

    public bool IsPlayerNameUnique(string playerName)
    {
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = $"SELECT COUNT(*) FROM Player WHERE PlayerName = '{playerName}'";

        int count = Convert.ToInt32(dbCommand.ExecuteScalar());

        return count == 0;
    }
}
