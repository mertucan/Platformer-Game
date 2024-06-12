using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    // Oyuncunun animat�r bile�eni
    private Animator anim;

    // Oyuncunun Rigidbody2D bile�eni
    private Rigidbody2D rb;

    // Oyuncunun �lme durumunda �al�nacak ses efekti
    [SerializeField] private AudioSource deathSoundEffect;

    // Ba�lang��ta �al��acak olan metot
    private void Start()
    {
        // anim de�i�kenine bu nesnenin Animator bile�enini atar
        anim = GetComponent<Animator>();

        // rb de�i�kenine bu nesnenin Rigidbody2D bile�enini atar
        rb = GetComponent<Rigidbody2D>();
    }

    // �arp��ma alg�land���nda �a�r�lan metot
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // E�er �arp��an nesnenin etiketi "Trap" ise
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Oyuncuyu �ld�ren metodu �a��r�r
            Die();
        }
    }

    // Oyuncunun �ld��� durumu y�neten metot
    private void Die()
    {
        // deathSoundEffect ses efektini �alar
        deathSoundEffect.Play();

        // Elmalar� haf�zadan ��kar
        PlayerPrefs.SetInt("ElmaSayisi", 0);
        PlayerPrefs.Save();

        // Oyuncu Rigidbody'sini Static yaparak hareketsizle�tirir
        rb.bodyType = RigidbodyType2D.Static;

        // Oyuncunun �l�m animasyonunu ba�lat�r
        anim.SetTrigger("death");

        // Oyun seviyesini yeniden ba�latan metodu �a��r�r
        Invoke("RestartLevel", 2f);
    }

    // Oyun seviyesini yeniden ba�latan metot
    private void RestartLevel()
    {
        // Aktif sahneyi yeniden y�kler
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
