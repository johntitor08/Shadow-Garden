using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "Level5Pre")
        {
            SceneManager.LoadScene("Level5", LoadSceneMode.Single);

        }

        if (SceneManager.GetActiveScene().name == "Story")
        {
            SceneManager.LoadScene("AnaMenu", LoadSceneMode.Single);

        }

        if (SceneManager.GetActiveScene().name == "Level6Pre")
        {
            SceneManager.LoadScene("Memories", LoadSceneMode.Single);

        }

        if (SceneManager.GetActiveScene().name == "Memories")
        {
            SceneManager.LoadScene("Level6", LoadSceneMode.Single);

        }

    }

    public void SkipButton()
    {
        SceneManager.LoadScene("AnaMenu", LoadSceneMode.Single);

    }

}
