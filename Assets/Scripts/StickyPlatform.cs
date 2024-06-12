using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // Nesnenin i�ine bir ba�ka nesne girdi�inde �a�r�lan metot
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er �arpan nesnenin ad� "Player" ise
        if (collision.gameObject.name == "Player")
        {
            // Player nesnesini bu nesnenin alt nesnesi haline getirir
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // Nesnenin i�inden bir ba�ka nesne ��kt���nda �a�r�lan metot
    private void OnTriggerExit2D(Collider2D collision)
    {
        // E�er �arpan nesnenin ad� "Player" ise
        if (collision.gameObject.name == "Player")
        {
            // Player nesnesini ebeveyninden ay�rarak ba��ms�z hale getirir
            collision.gameObject.transform.SetParent(null);
        }
    }
}
