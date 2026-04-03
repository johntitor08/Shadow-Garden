using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject panelMenu;
    [SerializeField] GameObject panelSettings;

    void Start()
    {

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

    public void SettingsMenu()
    {
        panelMenu.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void Menu()
    {
        panelMenu.SetActive(true);
        panelSettings.SetActive(false);
    }


    [SerializeField] Text volumeAmount;
    [SerializeField] Slider volumeSlider;
    public void SetAudio()
    {
        AudioListener.volume = volumeSlider.value;
        volumeAmount.text = ((int)(volumeSlider.value * 100)).ToString();
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


    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("audioVolume", 0.5f);
        volumeSlider.value = PlayerPrefs.GetFloat("audioVolume");
    }
}
