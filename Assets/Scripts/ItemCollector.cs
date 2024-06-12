using UnityEngine;
using UnityEngine.UI;

public class AppleCollector : MonoBehaviour
{
    private int apples = 0;

    [SerializeField] private Text applesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        // E�er scene index 1 ise PlayerPrefs'ten elma say�s�n� s�f�rla
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("ElmaSayisi", 0);
            PlayerPrefs.Save();
        }
        else
        {
            // Di�er sahneler i�in elma say�s�n� al
            apples = PlayerPrefs.GetInt("ElmaSayisi", 0);
        }

        UpdateApplesText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            apples++;
            UpdateApplesText();
        }
    }

    private void UpdateApplesText()
    {
        // Elma say�s�n� g�ncelle ve PlayerPrefs'e kaydet
        applesText.text = "Apples: " + apples;
        PlayerPrefs.SetInt("ElmaSayisi", apples);
        PlayerPrefs.Save();
    }
}
