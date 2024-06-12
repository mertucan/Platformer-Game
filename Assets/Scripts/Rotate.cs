using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Dönüþ hýzý, Unity Editor üzerinden ayarlanabilir
    [SerializeField] private float speed = 2f;

    // Her frame'de çaðrýlan metot
    private void Update()
    {
        // Objenin Z ekseninde dönüþünü saðlayan metot
        // 360 derece * speed * Time.deltaTime, her frame'de dönüþ miktarýný belirler
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
