using UnityEngine;
using UnityEngine.SceneManagement;

public class SeviyeBitir : MonoBehaviour
{
    public void Seviyeler()
    {
        SceneManager.LoadScene("Seviyeler");
    }

    public void SeviyeBitirme(int i)
    {
        if (i == 7)
        {
            PlayerPrefs.SetInt("stage", 1);
        }

        if (i == 9)
        {
            PlayerPrefs.SetInt("level9Progress", 0);
            Seviyeler();
        }
        else
        {
            PlayerPrefs.SetInt("seviye" + (i + 1) + "Kilidi", 1);
            Seviyeler();
        }
    }
}
