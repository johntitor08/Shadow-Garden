using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    Button button;
    public PlayableDirector playableDirectorEnd;
    public GameObject endSceneCam;
    public GameObject karakter;
    public Camera cam;
    public CinemachineVirtualCamera movingCam;
    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;
    public SeviyeBitir seviyeBitir;
    public GameObject canvas;
    public GameObject skipButton;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (playableDirectorEnd != null)
        {
            if (playableDirectorEnd.time >= 4.9f && SceneManager.GetActiveScene().name == "Level9")
            {
                seviyeBitir.SeviyeBitirme(9);
            }
        }



    }
    public void PointerEnter()
    {
        if (button.interactable)
        {
            transform.localScale = new Vector2(1.2f, 1.2f);
        }
    }

    public void PointerExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }

    public void SkipScene()
    {
        if (PlayerPrefs.GetInt("level9Progress") == 0)
        {
            playableDirector1.time = 41.9f;
        }

        else if (PlayerPrefs.GetInt("level9Progress") == 1)
        {
            playableDirector2.time = 101.4f;
        }

        skipButton.SetActive(false);

    }

    public void EndGame()
    {
        cam.gameObject.SetActive(false);
        Destroy(movingCam);
        Destroy(karakter);
        Destroy(GameObject.Find("Object"));
        Destroy(GameObject.Find("Part2"));
        endSceneCam.SetActive(true);
        canvas.SetActive(false);
        playableDirectorEnd.Play();
        Time.timeScale = 1;
    }
}
