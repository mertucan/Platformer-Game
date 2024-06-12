using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Hareket edilecek olan yol noktalar�
    [SerializeField] private GameObject[] waypoints;

    // �u anki yol noktas� indeksi
    private int currentWaypointIndex = 0;

    // Hareket h�z�
    [SerializeField] private float speed = 2f;

    // Her frame'de �a�r�lan metot
    private void Update()
    {
        // E�er mevcut konum ile hedef yol noktas� aras�ndaki mesafe 0.1 birimden k���kse
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            // Mevcut yol noktas� indeksini bir artt�r
            currentWaypointIndex++;

            // E�er mevcut indeks, toplam yol noktas� say�s�na e�it veya daha b�y�kse
            if (currentWaypointIndex >= waypoints.Length)
            {
                // Mevcut indeksi s�f�ra d�nd�r (d�ng�y� devam ettir)
                currentWaypointIndex = 0;
            }
        }

        // Yol noktas�na do�ru hareket et
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    // Ba�lang��ta �al��acak olan metot
    void Start()
    {
        // E�er waypoints dizisi bo� veya null ise
        if (waypoints == null || waypoints.Length == 0)
        {
            // "Waypoint" etiketli t�m objeleri bul ve waypoints dizisine ekle
            waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        }
    }
}
