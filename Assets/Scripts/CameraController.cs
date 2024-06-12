using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Oyuncunun konumunu takip edecek olan Transform de�i�keni
    [SerializeField]private Transform player;

    void Update()
    {
        // Kameran�n x ve y pozisyonunu oyuncunun x ve y pozisyonuyla e�le�tirir,
        // ancak z pozisyonunu de�i�tirmeyerek kameran�n derinlik konumunu sabit tutar.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
