using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreGenerator : MonoBehaviour
{
    public Text yildizpuani;
    public static int yildizpuani_int = 0;
    public Text scorePoint;
    public static int scorePoint_int = 0;
    public Text stageNumber;
    public static int stageNumber_int = 0;
    public GameObject stage1Border;
    public GameObject stage2Border;
    public GameObject stage3Border;
    public GameObject stage4Border;

    private void Start()
    {
        yildizpuani_int = 0;
        stageNumber_int = 1;
        scorePoint_int = 0;
    }

    private void Update()
    {
        yildizpuani.text = yildizpuani_int.ToString();

        if (SceneManager.GetActiveScene().name == "Level7")
        {
            if (PlayerPrefs.GetString("Language") == "English")
            {
                scorePoint.text = "Score: " + scorePoint_int.ToString();
                stageNumber.text = "Stage: " + stageNumber_int.ToString();
            }
            else if (PlayerPrefs.GetString("Language") == "Turkish")
            {
                scorePoint.text = "Skor: " + scorePoint_int.ToString();
                stageNumber.text = "Aþama: " + stageNumber_int.ToString();
            }
        }

        if (scorePoint_int == 6 && yildizpuani_int == 7)
        {
            Destroy(stage1Border);
        }
        else if (scorePoint_int == 5 && yildizpuani_int == 12)
        {
            Destroy(stage2Border);
        }
        else if (scorePoint_int == 5 && yildizpuani_int == 20)
        {
            Destroy(stage3Border);
        }
        else if (scorePoint_int == 4 && yildizpuani_int == 26)
        {
            Destroy(stage4Border);
        }
    }
}
