using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("answered") && SceneManager.GetActiveScene().name == "Level6")
        {
            _ = PlayerPrefs.GetInt("answered");
            GameObject.FindGameObjectWithTag("karakter").transform.position = new Vector3(513.5f, 36, 0f);
        }

        if (PlayerPrefs.HasKey("stage") && SceneManager.GetActiveScene().name == "Level7")
        {
            int stage = PlayerPrefs.GetInt("stage");

            if (stage == 1)
            {
                GameObject.FindGameObjectWithTag("karakter").transform.position = new Vector3(-17.5f, -8f, 0f);
                ScoreGenerator.yildizpuani_int = 0;
            }
            else if (stage == 2)
            {
                GameObject.FindGameObjectWithTag("karakter").transform.position = new Vector3(131f, 19.6f, 0f);
                ScoreGenerator.yildizpuani_int = 7;
            }
            else if (stage == 3)
            {
                GameObject.FindGameObjectWithTag("karakter").transform.position = new Vector3(277f, 47.5f, 0f);
                ScoreGenerator.yildizpuani_int = 12;
            }
            else if (stage == 4)
            {
                GameObject.FindGameObjectWithTag("karakter").transform.position = new Vector3(423f, 75.5f, 0f);
                ScoreGenerator.yildizpuani_int = 20;
            }
            else if (stage == 5)
            {
                GameObject.FindGameObjectWithTag("karakter").transform.position = new Vector3(528f, 75.5f, 0f);
                ScoreGenerator.yildizpuani_int = 26;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("karakter"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ScoreGenerator.yildizpuani_int = 0;
            ScoreGenerator.stageNumber_int = 1;
            ScoreGenerator.scorePoint_int = 0;
        }

        if (collision.gameObject.name == "nevoksa" && SceneManager.GetActiveScene().name == "Level9" && !PlayerPrefs.HasKey("level9Progress"))
        {
            PlayerPrefs.SetInt("level9Progress", 0);
        }
    }
}
