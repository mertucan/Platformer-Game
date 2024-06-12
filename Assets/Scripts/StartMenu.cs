using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Oyuna ba�lamak i�in kullan�lacak metot
    public void StartGame()
    {
        // Aktif sahnenin build index'ine 1 ekleyerek bir sonraki sahneye ge�i� yapar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
