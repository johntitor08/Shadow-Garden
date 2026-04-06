using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeviyelerYoneticisi : MonoBehaviour
{
    [SerializeField] Button seviye2_button, seviye3_button, seviye4_button, seviye5_button, seviye6_button, seviye7_button, seviye8_button, seviye9_button;

    private void Start()
    {
        ScoreGenerator.yildizpuani_int = 0;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("seviye2Kilidi") == 1) seviye2_button.interactable = true;
        if (PlayerPrefs.GetInt("seviye3Kilidi") == 1) seviye3_button.interactable = true;
        if (PlayerPrefs.GetInt("seviye4Kilidi") == 1) seviye4_button.interactable = true;
        if (PlayerPrefs.GetInt("seviye5Kilidi") == 1) seviye5_button.interactable = true;
        if (PlayerPrefs.GetInt("seviye6Kilidi") == 1) seviye6_button.interactable = true;
        if (PlayerPrefs.GetInt("seviye7Kilidi") == 1) seviye7_button.interactable = true;
        if (PlayerPrefs.GetInt("seviye8Kilidi") == 1) seviye8_button.interactable = true;
        if (PlayerPrefs.GetInt("seviye9Kilidi") == 1) seviye9_button.interactable = true;
    }

    public void Level(int i)
    {
        if (i != 5 && i != 6)
        {
            SceneManager.LoadScene("Level" + i);
        }
        else if (i == 5)
        {
            SceneManager.LoadScene("Level5Pre");
        }
        else if (i == 6)
        {
            if (PlayerPrefs.HasKey("answered"))
            {
                _ = PlayerPrefs.GetInt("answered");
                SceneManager.LoadScene("Level6");
            }
            else
            {
                SceneManager.LoadScene("Level6Pre");
            }
        }

        if (i == 7)
        {
            if (PlayerPrefs.HasKey("stage"))
            {
                _ = PlayerPrefs.GetInt("stage");
            }
        }
    }
}
