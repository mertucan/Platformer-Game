using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Oyuna baþlamak için kullanýlacak metot
    public void StartGame()
    {
        // Aktif sahnenin build index'ine 1 ekleyerek bir sonraki sahneye geçiþ yapar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
