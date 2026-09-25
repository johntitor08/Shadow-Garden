using UnityEngine;

// Level7 (asamali arena): asama girisleri, asama bilgileri ve skor sifirlama.
public partial class KarakterHareket
{
    private void Level7TriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.name == "stage1")
        {
            stage1.gameObject.SetActive(true);
            ScoreGenerator.stageNumber_int = 1;
            PlayerPrefs.SetInt("stage", 1);
        }

        if (collision.gameObject.name == "stage2")
        {
            stage2.gameObject.SetActive(true);
            GameObject.Find("stage2StartBorder").GetComponent<BoxCollider2D>().isTrigger = false;
            ScoreGenerator.stageNumber_int = 2;
            PlayerPrefs.SetInt("stage", 2);
        }

        if (collision.gameObject.name == "stage3")
        {
            stage3.gameObject.SetActive(true);
            downInfo.gameObject.SetActive(true);
            GameObject.Find("stage3StartBorder").GetComponent<BoxCollider2D>().isTrigger = false;
            ScoreGenerator.stageNumber_int = 3;
            PlayerPrefs.SetInt("stage", 3);
        }

        if (collision.gameObject.name == "stage4")
        {
            stage4.gameObject.SetActive(true);
            GameObject.Find("stage4StartBorder").GetComponent<BoxCollider2D>().isTrigger = false;
            ScoreGenerator.stageNumber_int = 4;
            PlayerPrefs.SetInt("stage", 4);
        }

        if (collision.gameObject.name == "stage5")
        {
            stage5.gameObject.SetActive(true);
            GameObject.Find("stage5StartBorder").GetComponent<BoxCollider2D>().isTrigger = false;
            ScoreGenerator.stageNumber_int = 5;
            PlayerPrefs.SetInt("stage", 5);
        }

        if (collision.gameObject.name == "scoreDetector")
        {
            canSayisi = 3;
            ScoreGenerator.scorePoint_int = 0;

            for (int i = 0; i < canSayisi; i++)
            {
                can[i].SetActive(true);
            }

            if (collision.transform.parent.gameObject.name == "stage1")
            {
                ScoreGenerator.yildizpuani_int = 0;
            }
            else if (collision.transform.parent.gameObject.name == "stage2")
            {
                ScoreGenerator.yildizpuani_int = 7;
            }
            else if (collision.transform.parent.gameObject.name == "stage3")
            {
                ScoreGenerator.yildizpuani_int = 12;
            }
            else if (collision.transform.parent.gameObject.name == "stage4")
            {
                ScoreGenerator.yildizpuani_int = 20;
            }
            else if (collision.transform.parent.gameObject.name == "stage5")
            {
                ScoreGenerator.yildizpuani_int = 26;
            }

            Destroy(collision.gameObject);
        }
    }

    private void Level7TriggerExit(Collider2D collision)
    {
        if (collision.gameObject.name == "stage1")
        {
            stage1.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "stage2")
        {
            stage2.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "stage3")
        {
            stage3.gameObject.SetActive(false);
            downInfo.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "stage4")
        {
            stage4.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "stage5")
        {
            stage5.gameObject.SetActive(false);
        }
    }
}
