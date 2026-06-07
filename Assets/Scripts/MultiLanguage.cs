using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class MultiLanguage : MonoBehaviour
{
    private void Start()
    {
        // Kaydedilmiş dili yükle veya varsayılan dili al
        string savedLanguage = PlayerPrefs.GetString("Language", GetDefaultLanguage());
        SetLanguage(savedLanguage);
    }

    private string GetDefaultLanguage()
    {
        // Sistem diline göre varsayılan dil belirle
        return Application.systemLanguage switch
        {
            SystemLanguage.Russian => "Russian",
            SystemLanguage.Turkish => "Turkish",
            _ => "English"
        };
    }

    private void SetLanguage(string language)
    {
        // Seçilen dili Locale sistemine uygula
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            if (locale.LocaleName.Equals(language))
            {
                LocalizationSettings.SelectedLocale = locale;
                PlayerPrefs.SetString("Language", language); // Dili kaydet
                PlayerPrefs.Save(); // Kalıcı olarak sakla
                break;
            }
        }
    }

    public void Language(string language)
    {
        SetLanguage(language);
    }

    public void LanguageChange()
    {
        // Kullanılabilir dilleri döngüsel olarak değiştir
        var locales = LocalizationSettings.AvailableLocales.Locales;
        int currentIndex = locales.IndexOf(LocalizationSettings.SelectedLocale);
        int nextIndex = (currentIndex + 1) % locales.Count;
        string nextLanguage = locales[nextIndex].LocaleName;
        SetLanguage(nextLanguage);
    }

    public void Accept()
    {
        // "Story" sahnesini yükle
        SceneManager.LoadScene("Story");
    }
}
