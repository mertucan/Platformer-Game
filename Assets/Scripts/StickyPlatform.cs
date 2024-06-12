using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // Nesnenin içine bir baþka nesne girdiðinde çaðrýlan metot
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer çarpan nesnenin adý "Player" ise
        if (collision.gameObject.name == "Player")
        {
            // Player nesnesini bu nesnenin alt nesnesi haline getirir
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // Nesnenin içinden bir baþka nesne çýktýðýnda çaðrýlan metot
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Eðer çarpan nesnenin adý "Player" ise
        if (collision.gameObject.name == "Player")
        {
            // Player nesnesini ebeveyninden ayýrarak baðýmsýz hale getirir
            collision.gameObject.transform.SetParent(null);
        }
    }
}
