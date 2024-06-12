using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    // Oyuncunun animatör bileþeni
    private Animator anim;

    // Oyuncunun Rigidbody2D bileþeni
    private Rigidbody2D rb;

    // Oyuncunun ölme durumunda çalýnacak ses efekti
    [SerializeField] private AudioSource deathSoundEffect;

    // Baþlangýçta çalýþacak olan metot
    private void Start()
    {
        // anim deðiþkenine bu nesnenin Animator bileþenini atar
        anim = GetComponent<Animator>();

        // rb deðiþkenine bu nesnenin Rigidbody2D bileþenini atar
        rb = GetComponent<Rigidbody2D>();
    }

    // Çarpýþma algýlandýðýnda çaðrýlan metot
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer çarpýþan nesnenin etiketi "Trap" ise
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Oyuncuyu öldüren metodu çaðýrýr
            Die();
        }
    }

    // Oyuncunun öldüðü durumu yöneten metot
    private void Die()
    {
        // deathSoundEffect ses efektini çalar
        deathSoundEffect.Play();

        // Elmalarý hafýzadan çýkar
        PlayerPrefs.SetInt("ElmaSayisi", 0);
        PlayerPrefs.Save();

        // Oyuncu Rigidbody'sini Static yaparak hareketsizleþtirir
        rb.bodyType = RigidbodyType2D.Static;

        // Oyuncunun ölüm animasyonunu baþlatýr
        anim.SetTrigger("death");

        // Oyun seviyesini yeniden baþlatan metodu çaðýrýr
        Invoke("RestartLevel", 2f);
    }

    // Oyun seviyesini yeniden baþlatan metot
    private void RestartLevel()
    {
        // Aktif sahneyi yeniden yükler
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
