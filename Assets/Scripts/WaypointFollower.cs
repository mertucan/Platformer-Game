using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Hareket edilecek olan yol noktalarý
    [SerializeField] private GameObject[] waypoints;

    // Þu anki yol noktasý indeksi
    private int currentWaypointIndex = 0;

    // Hareket hýzý
    [SerializeField] private float speed = 2f;

    // Her frame'de çaðrýlan metot
    private void Update()
    {
        // Eðer mevcut konum ile hedef yol noktasý arasýndaki mesafe 0.1 birimden küçükse
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            // Mevcut yol noktasý indeksini bir arttýr
            currentWaypointIndex++;

            // Eðer mevcut indeks, toplam yol noktasý sayýsýna eþit veya daha büyükse
            if (currentWaypointIndex >= waypoints.Length)
            {
                // Mevcut indeksi sýfýra döndür (döngüyü devam ettir)
                currentWaypointIndex = 0;
            }
        }

        // Yol noktasýna doðru hareket et
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    // Baþlangýçta çalýþacak olan metot
    void Start()
    {
        // Eðer waypoints dizisi boþ veya null ise
        if (waypoints == null || waypoints.Length == 0)
        {
            // "Waypoint" etiketli tüm objeleri bul ve waypoints dizisine ekle
            waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        }
    }
}
