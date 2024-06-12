using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Oyuncunun konumunu takip edecek olan Transform değişkeni
    [SerializeField]private Transform player;

    void Update()
    {
        // Kameranın x ve y pozisyonunu oyuncunun x ve y pozisyonuyla eşleştirir,
        // ancak z pozisyonunu değiştirmeyerek kameranın derinlik konumunu sabit tutar.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
