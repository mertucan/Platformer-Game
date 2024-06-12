using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Oyuncunun konumunu takip edecek olan Transform deðiþkeni
    [SerializeField]private Transform player;

    void Update()
    {
        // Kameranýn x ve y pozisyonunu oyuncunun x ve y pozisyonuyla eþleþtirir,
        // ancak z pozisyonunu deðiþtirmeyerek kameranýn derinlik konumunu sabit tutar.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
