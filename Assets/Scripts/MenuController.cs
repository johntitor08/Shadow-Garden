using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] Text volumeAmount;
    [SerializeField] Slider volumeSlider;

    #if UNITY_WEBGL && !UNITY_EDITOR

    private YandexGameEvents yandexGameEvents;

    #endif

    void Start()
    {
        settingsMenu.SetActive(false);

        #if UNITY_WEBGL && !UNITY_EDITOR

        yandexGameEvents = FindObjectOfType<YandexGameEvents>();
        if (yandexGameEvents != null)
        {
            yandexGameEvents.SendGameplayStart();
        }

        #endif

        if (!PlayerPrefs.HasKey("audioVolume"))
        {
            PlayerPrefs.SetFloat("audioVolume", 0.5f);
            LoadAudio();
        }
        else
        {
            LoadAudio();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(true);

            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        panel.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        Enemy.hareketEt = true;

        #if UNITY_WEBGL && !UNITY_EDITOR

        if (yandexGameEvents != null)
        {
            yandexGameEvents.SendGameplayStart();
        }

        #endif
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        panel.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        Enemy.hareketEt = false;

#       if UNITY_WEBGL && !UNITY_EDITOR

        if (yandexGameEvents != null)
        {
            yandexGameEvents.SendGameplayStop();
        }

        #endif
    }

    public void Settings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void SetAudio()
    {
        AudioListener.volume = volumeSlider.value;
        volumeAmount.text = ((int)(volumeSlider.value*100)).ToString();
        SaveAudio();
    }

    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume", volumeSlider.value);
    }

    private void LoadAudio()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("audioVolume");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        ScoreGenerator.yildizpuani_int = 0;
        SceneManager.LoadScene("Seviyeler");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
