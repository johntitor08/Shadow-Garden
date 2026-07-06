using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningScenes : MonoBehaviour
{
    [SerializeField] private GameObject gameLogo;

    private void Start()
    {
        ScoreGenerator.yildizpuani_int = 0;
        Time.timeScale = 1;
        ApplyLogoSize();
    }

    private void ApplyLogoSize()
    {
        // gameLogo is only assigned in scenes that actually show the logo (e.g. AnaMenu);
        // in others (e.g. Seviyeler) it is null, so guard before use.
        if (gameLogo == null)
        {
            return;
        }

        RectTransform logoRect = gameLogo.GetComponent<RectTransform>();
        if (logoRect == null)
        {
            return;
        }

        if (PlayerPrefs.GetString("Language") == "English")
        {
            logoRect.sizeDelta = new Vector2(1300, 175);
        }
        else
        {
            logoRect.sizeDelta = new Vector2(1250, 200);
        }
    }

    public void Levels()
    {
        SceneManager.LoadScene("Seviyeler");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("AnaMenu");
    }

    public void Training()
    {
        SceneManager.LoadScene("Training");
    }

    //public void ExitGame()
    //{
    //    Application.Quit();
    //}
}
