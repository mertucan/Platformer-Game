using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Biti� sesini �almak i�in kullan�lacak AudioSource bile�eni
    private AudioSource finishSound;

    // Seviyenin tamamland���n� kontrol eden de�i�ken
    private bool levelCompleted = false;

    // Ba�lang��ta �al��acak olan metot
    private void Start()
    {
        // finishSound de�i�kenine bu nesnenin AudioSource bile�enini atar
        finishSound = GetComponent<AudioSource>(); 
    }

    // Tetikleyiciye (Trigger) giren nesnelerin kontrol�n� sa�layan metot

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er giren nesnenin ad� "Player" ise ve seviye daha �nce tamamlanmam��sa

        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            // finishSound sesini �alar
            finishSound.Play();
            // Seviye tamamland� olarak i�aretlenir ve CompleteLevel metodu 2 saniye sonra �a�r�l�r
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    // Seviyenin tamamland���nda �a�r�lacak metot
    private void CompleteLevel()
    {
        // Aktif sahneden bir sonraki sahneye ge�i� yapar

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
