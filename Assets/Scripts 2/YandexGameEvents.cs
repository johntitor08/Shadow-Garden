using System.Runtime.InteropServices;
using UnityEngine;

public class YandexGameEvents : MonoBehaviour
{
    #if UNITY_WEBGL && !UNITY_EDITOR

    private static YandexGameEvents _instance;

    // Ensure there is only one instance that persists across scenes
    public static YandexGameEvents Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singleton = new GameObject("YandexGameEvents");
                _instance = singleton.AddComponent<YandexGameEvents>();
                DontDestroyOnLoad(singleton);
            }
            return _instance;
        }
    }

    [DllImport("__Internal")]
    private static extern void OnGameStartScreen();

    [DllImport("__Internal")]
    private static extern void GameplayStart();

    [DllImport("__Internal")]
    private static extern void GameplayStop();

    [DllImport("__Internal")]
    private static extern void ShowAd();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }

    void Start()
    {
        OnGameStartScreen();
    }

    public void SendGameplayStart()
    {
        GameplayStart();
    }

    public void SendGameplayStop()
    {
        GameplayStop();
    }

    public void SendShowAd()
    {
        ShowAd();
    }

    #endif

}
