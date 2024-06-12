using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Bitiþ sesini çalmak için kullanýlacak AudioSource bileþeni
    private AudioSource finishSound;

    // Seviyenin tamamlandýðýný kontrol eden deðiþken
    private bool levelCompleted = false;

    // Baþlangýçta çalýþacak olan metot
    private void Start()
    {
        // finishSound deðiþkenine bu nesnenin AudioSource bileþenini atar
        finishSound = GetComponent<AudioSource>(); 
    }

    // Tetikleyiciye (Trigger) giren nesnelerin kontrolünü saðlayan metot

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer giren nesnenin adý "Player" ise ve seviye daha önce tamamlanmamýþsa

        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            // finishSound sesini çalar
            finishSound.Play();
            // Seviye tamamlandý olarak iþaretlenir ve CompleteLevel metodu 2 saniye sonra çaðrýlýr
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    // Seviyenin tamamlandýðýnda çaðrýlacak metot
    private void CompleteLevel()
    {
        // Aktif sahneden bir sonraki sahneye geçiþ yapar

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
