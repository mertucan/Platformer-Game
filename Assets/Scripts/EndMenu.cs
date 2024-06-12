using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    // Oyunu sonlandýran fonksiyon
    public void EndGame()
    {
        // Uygulamadan çýkýþ yapar. Bu, oyunun oynatýldýðý platforma baðlý olarak farklý sonuçlar doðurabilir.
        // Örneðin, bu metot bilgisayar platformlarýnda oyunu kapatýr, ancak mobil platformlarda farklý davranabilir.

        Application.Quit();
    }
}
