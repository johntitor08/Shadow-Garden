using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningScenes : MonoBehaviour
{
    [SerializeField] private GameObject gameLogo;

    private void Start()
    {
        ScoreGenerator.yildizpuani_int = 0;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("Language") == "English")
        {
            gameLogo.GetComponent<RectTransform>().sizeDelta = new Vector2(1300, 175);
        }
        else
        {
            gameLogo.GetComponent<RectTransform>().sizeDelta = new Vector2(1250, 200);
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
