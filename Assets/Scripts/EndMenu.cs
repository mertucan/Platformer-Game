using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    // Oyunu sonland�ran fonksiyon
    public void EndGame()
    {
        // Uygulamadan ��k�� yapar. Bu, oyunun oynat�ld��� platforma ba�l� olarak farkl� sonu�lar do�urabilir.
        // �rne�in, bu metot bilgisayar platformlar�nda oyunu kapat�r, ancak mobil platformlarda farkl� davranabilir.

        Application.Quit();
    }
}
