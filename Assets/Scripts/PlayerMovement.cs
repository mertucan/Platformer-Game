using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Oyuncunun Rigidbody2D bileþeni
    private Rigidbody2D rb;

    // Oyuncunun Animator bileþeni
    private Animator anim;

    // Oyuncunun BoxCollider2D bileþeni
    private BoxCollider2D coll;

    // Oyuncunun SpriteRenderer bileþeni
    private SpriteRenderer sprite;

    // Zýplamaya izin verilen zeminleri belirleyen layer mask
    [SerializeField] private LayerMask jumpableGround;

    // Oyuncu hareket hýzý
    [SerializeField] private float moveSpeed = 7f;

    // Oyuncu zýplama kuvveti
    [SerializeField] private float jumpForce = 14f;

    // Zýplama sýrasýnda çalýnacak ses efekti
    [SerializeField] private AudioSource jumpSoundEffect;

    // Oyuncunun hareket yönü
    private float directionX = 0f;

    // Oyuncunun hareket durumlarýný belirleyen enum
    private enum MovementState { idle, running, jumping, falling }

    // Baþlangýçta çalýþacak olan metot
    void Start()
    {
        // rb deðiþkenine bu nesnenin Rigidbody2D bileþenini atar
        rb = GetComponent<Rigidbody2D>();

        // anim deðiþkenine bu nesnenin Animator bileþenini atar
        anim = GetComponent<Animator>();

        // coll deðiþkenine bu nesnenin BoxCollider2D bileþenini atar
        coll = GetComponent<BoxCollider2D>();

        // sprite deðiþkenine bu nesnenin SpriteRenderer bileþenini atar
        sprite = GetComponent<SpriteRenderer>();
    }

    // Her frame'de çaðrýlan metot
    void Update()
    {
        // Kullanýcýnýn yatay giriþini alýr
        directionX = Input.GetAxisRaw("Horizontal");

        // Rigidbody'ye yeni bir hýz atar, yatay hýzý kullanýcýnýn giriþine göre ayarlar
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        // Kullanýcý zýplama tuþuna bastýðýnda ve oyuncu yere temas ettiðinde
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // Yatay hýzý koruyarak oyuncuya yukarý doðru bir zýplama kuvveti uygular
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Zýplama ses efektini çalar
            jumpSoundEffect.Play();
        }

        // Animasyon durumunu günceller
        UpdateAnimationState();
    }

    // Animasyon durumunu güncelleyen metot
    private void UpdateAnimationState()
    {
        MovementState state;

        // Yatay hýzý kontrol ederek animasyon durumunu belirler
        if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false; // Oyuncu saða doðru hareket ediyorsa sprite'ý ters çevirmez
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; // Oyuncu sola doðru hareket ediyorsa sprite'ý ters çevirir
        }
        else
        {
            state = MovementState.idle;
        }

        // Oyuncu yukarý doðru hýzlanýyorsa veya aþaðý doðru düþüyorsa, durumu günceller
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        // Animator bileþenine durumu ileten bir sayý gönderir
        anim.SetInteger("state", (int)state);
    }

    // Oyuncunun yere temas edip etmediðini kontrol eden metot
    private bool IsGrounded()
    {
        // Oyuncu altýndaki boks kolinin etrafýnda bir kutu çizerek zeminle temasý kontrol eder
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
