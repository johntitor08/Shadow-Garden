using UnityEngine;
using UnityEngine.UI;

public class Sayac : MonoBehaviour
{
    public float zaman;
    public Text zamanText;

    void Start()
    {
        zaman = 0;
    }

    void Update()
    {
        zaman += Time.deltaTime;

        if (PlayerPrefs.GetString("Language") == "English" || !PlayerPrefs.HasKey("Language"))
        {
            zamanText.text = "Time Scale: " + (int)zaman;
        }
        else if (PlayerPrefs.GetString("Language") == "Turkish")
        {
            zamanText.text = "Zaman Ölçeği: " + (int)zaman;
        }
        else if (PlayerPrefs.GetString("Language") == "Russian")
        {
            zamanText.text = "Шкала времени: " + (int)zaman;
        }
    }
}
