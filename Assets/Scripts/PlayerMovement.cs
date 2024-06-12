using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Oyuncunun Rigidbody2D bile�eni
    private Rigidbody2D rb;

    // Oyuncunun Animator bile�eni
    private Animator anim;

    // Oyuncunun BoxCollider2D bile�eni
    private BoxCollider2D coll;

    // Oyuncunun SpriteRenderer bile�eni
    private SpriteRenderer sprite;

    // Z�plamaya izin verilen zeminleri belirleyen layer mask
    [SerializeField] private LayerMask jumpableGround;

    // Oyuncu hareket h�z�
    [SerializeField] private float moveSpeed = 7f;

    // Oyuncu z�plama kuvveti
    [SerializeField] private float jumpForce = 14f;

    // Z�plama s�ras�nda �al�nacak ses efekti
    [SerializeField] private AudioSource jumpSoundEffect;

    // Oyuncunun hareket y�n�
    private float directionX = 0f;

    // Oyuncunun hareket durumlar�n� belirleyen enum
    private enum MovementState { idle, running, jumping, falling }

    // Ba�lang��ta �al��acak olan metot
    void Start()
    {
        // rb de�i�kenine bu nesnenin Rigidbody2D bile�enini atar
        rb = GetComponent<Rigidbody2D>();

        // anim de�i�kenine bu nesnenin Animator bile�enini atar
        anim = GetComponent<Animator>();

        // coll de�i�kenine bu nesnenin BoxCollider2D bile�enini atar
        coll = GetComponent<BoxCollider2D>();

        // sprite de�i�kenine bu nesnenin SpriteRenderer bile�enini atar
        sprite = GetComponent<SpriteRenderer>();
    }

    // Her frame'de �a�r�lan metot
    void Update()
    {
        // Kullan�c�n�n yatay giri�ini al�r
        directionX = Input.GetAxisRaw("Horizontal");

        // Rigidbody'ye yeni bir h�z atar, yatay h�z� kullan�c�n�n giri�ine g�re ayarlar
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        // Kullan�c� z�plama tu�una bast���nda ve oyuncu yere temas etti�inde
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // Yatay h�z� koruyarak oyuncuya yukar� do�ru bir z�plama kuvveti uygular
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Z�plama ses efektini �alar
            jumpSoundEffect.Play();
        }

        // Animasyon durumunu g�nceller
        UpdateAnimationState();
    }

    // Animasyon durumunu g�ncelleyen metot
    private void UpdateAnimationState()
    {
        MovementState state;

        // Yatay h�z� kontrol ederek animasyon durumunu belirler
        if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false; // Oyuncu sa�a do�ru hareket ediyorsa sprite'� ters �evirmez
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; // Oyuncu sola do�ru hareket ediyorsa sprite'� ters �evirir
        }
        else
        {
            state = MovementState.idle;
        }

        // Oyuncu yukar� do�ru h�zlan�yorsa veya a�a�� do�ru d���yorsa, durumu g�nceller
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        // Animator bile�enine durumu ileten bir say� g�nderir
        anim.SetInteger("state", (int)state);
    }

    // Oyuncunun yere temas edip etmedi�ini kontrol eden metot
    private bool IsGrounded()
    {
        // Oyuncu alt�ndaki boks kolinin etraf�nda bir kutu �izerek zeminle temas� kontrol eder
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
