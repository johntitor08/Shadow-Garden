using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel2a;
    public GameObject panel2b;
    public GameObject panel2c;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    private int option;
    public GameObject star;
    public GameObject starText;
    public Animator cinemachine;
    public GameObject secretPanel;
    public GameObject secretYes;
    public GameObject secretNo;

    private void Start()
    {
        ScoreGenerator.yildizpuani_int = 0;
        Question7();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "sensor1")
        {
            Question1(true);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor2")
        {
            Question2(0);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor3" && option == 1)
        {
            Question2A(true);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor3" && option == 2)
        {
            Question2B(true);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor3" && option == 3)
        {
            Question2C(true);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor4")
        {
            Question3(true);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor5")
        {
            Question4(true);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor6")
        {
            Question5(true);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor7")
        {
            Question6(true);
            Destroy(collision.gameObject);
        }

        if (collision.name == "sensor8")
        {
            Question7();
            Destroy(collision.gameObject);
        }

        if (collision.name == "secretSensor")
        {
            QuestionSecret(0);
            Destroy(collision.gameObject);
        }
    }

    public void Question1(bool active)
    {
        panel1.SetActive(true);

        if (!active)
        {
            panel1.SetActive(false);
            GameObject.Find("border1").SetActive(false);
        }
    }

    public void Question2(int option)
    {
        if (option == 0)
        {
            panel2.SetActive(true);
        }
        else
        {
            GameObject.Find("border2").SetActive(false);
        }

        if (option == 1)
        {
            panel2.SetActive(false);
        }
        else if (option == 2)
        {
            panel2.SetActive(false);
        }
        else if (option == 3)
        {
            panel2.SetActive(false);
        }

        this.option = option;
    }

    public void Question2A(bool active)
    {
        panel2a.SetActive(true);

        if (!active)
        {
            panel2a.SetActive(false);
            GameObject.Find("border3").SetActive(false);
        }
    }

    public void Question2B(bool active)
    {
        panel2b.SetActive(true);

        if (!active)
        {
            panel2b.SetActive(false);
            GameObject.Find("border3").SetActive(false);
        }
    }

    public void Question2C(bool active)
    {
        panel2c.SetActive(true);

        if (!active)
        {
            panel2c.SetActive(false);
            GameObject.Find("border3").SetActive(false);
        }
    }

    public void Question3(bool active)
    {
        panel3.SetActive(true);

        if (!active)
        {
            panel3.SetActive(false);
            GameObject.Find("border4").SetActive(false);
        }
    }

    public void Question4(bool active)
    {
        panel4.SetActive(true);

        if (!active)
        {
            panel4.SetActive(false);
            GameObject.Find("border5").SetActive(false);
        }
    }

    public void Question5(bool active)
    {
        panel5.SetActive(true);

        if (!active)
        {
            panel5.SetActive(false);
            GameObject.Find("border6").SetActive(false);
        }
    }

    public void Question6(bool active)
    {
        panel6.SetActive(true);

        if (!active)
        {
            panel6.SetActive(false);
            GameObject.Find("border7").SetActive(false);
        }
    }

    public void Question7()
    {
        star.SetActive(true);
        starText.SetActive(true);
        cinemachine.SetBool("enlarge", true);
        PlayerPrefs.SetInt("answered", 1);
    }

    public void QuestionSecret(int option)
    {
        if (option == 0)
        {
            secretPanel.SetActive(true);
        }
        else if (option == 1)
        {
            secretPanel.SetActive(false);
            secretYes.SetActive(true);
            Destroy(secretYes, 5f);
        }
        else if (option == 2)
        {
            secretPanel.SetActive(false);
            secretNo.SetActive(true);
            Destroy(secretNo, 5f);
        }
    }
}
