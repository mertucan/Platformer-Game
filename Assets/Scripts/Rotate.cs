using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // D�n�� h�z�, Unity Editor �zerinden ayarlanabilir
    [SerializeField] private float speed = 2f;

    // Her frame'de �a�r�lan metot
    private void Update()
    {
        // Objenin Z ekseninde d�n���n� sa�layan metot
        // 360 derece * speed * Time.deltaTime, her frame'de d�n�� miktar�n� belirler
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
