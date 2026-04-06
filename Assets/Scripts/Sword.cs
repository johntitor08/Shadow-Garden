using UnityEngine;
using UnityEngine.SceneManagement;

public class Sword : MonoBehaviour
{
    public GameObject authory;
    public GameObject ahmettny;
    public GameObject authoryHealthCanvas;
    public static int authoryHealth;
    public Healthbar authoryHealthbar;
    public int authoryMaxHealth;
    public int authoryCurrentHealth;
    public GameObject ahmettnyHealthCanvas;
    public static int ahmettnyHealth;
    public Healthbar ahmettnyHealthbar;
    public int ahmettnyMaxHealth;
    public int ahmettnyCurrentHealth;
    public GameObject nevoksa;
    public GameObject erina;
    public GameObject garou;
    public GameObject erinaHealthCanvas;
    public static int erinaHealth;
    public Healthbar erinaHealthbar;
    public int erinaMaxHealth;
    public int erinaCurrentHealth;
    public GameObject nevoksaHealthCanvas;
    public static int nevoksaHealth;
    public Healthbar nevoksaHealthbar;
    public int nevoksaMaxHealth;
    public int nevoksaCurrentHealth;
    public GameObject garouHealthCanvas;
    public static int garouHealth;
    public Healthbar garouHealthbar;
    public int garouMaxHealth;
    public int garouCurrentHealth;
    public GameObject darkGarouHealthCanvas;
    public static int darkGarouHealth;
    public Healthbar darkGarouHealthbar;
    public int darkGarouMaxHealth;
    public int darkGarouCurrentHealth;
    Animator animator;
    int attackRandomDamage;
    int attackRandomCount;
    public GameObject border1;
    public GameObject border2;
    public static float erinavsgarou;
    bool attack;
    bool handChange;

    void Start()
    {
        ahmettnyHealth = 100;
        authoryHealth = 100;
        erinaHealth = 50;
        garouHealth = 50;
        darkGarouHealth = 50;
        nevoksaHealth = 50;
        ahmettnyMaxHealth = 100;
        ahmettnyCurrentHealth = ahmettnyMaxHealth;
        ahmettnyHealthbar.SetMaxHealth(ahmettnyMaxHealth);
        ahmettnyHealthCanvas.SetActive(false);
        authoryMaxHealth = 100;
        authoryCurrentHealth = authoryMaxHealth;
        authoryHealthbar.SetMaxHealth(authoryMaxHealth);
        authoryHealthCanvas.SetActive(false);
        erinaMaxHealth = 50;
        erinaCurrentHealth = erinaMaxHealth;
        erinaHealthbar.SetMaxHealth(erinaMaxHealth);
        erinaHealthCanvas.SetActive(false);
        garouMaxHealth = 50;
        garouCurrentHealth = garouMaxHealth;
        garouHealthbar.SetMaxHealth(garouMaxHealth);
        garouHealthCanvas.SetActive(false);
        darkGarouMaxHealth = 50;
        darkGarouCurrentHealth = darkGarouMaxHealth;
        darkGarouHealthbar.SetMaxHealth(darkGarouMaxHealth);
        darkGarouHealthCanvas.SetActive(false);
        nevoksaMaxHealth = 50;
        nevoksaCurrentHealth = nevoksaMaxHealth;
        nevoksaHealthbar.SetMaxHealth(nevoksaMaxHealth);
        nevoksaHealthCanvas.SetActive(false);

        if (gameObject.GetComponent<Animator>() != null && gameObject.name != "magicSword")
        {
            animator = GetComponent<Animator>();
        }
        else if (gameObject.name == "magicSword")
        {
            animator = authory.GetComponent<Animator>();
        }

        if (gameObject.name == "baton" || gameObject.name == "garou")
        {
            border1.SetActive(false);
            border2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("level9Progress") != 2)
        {
            erinavsgarou = 0;
        }

        attack = false;
        handChange = true;
    }

    void Update()
    {
        if (!GameObject.Find("step2") && GameObject.Find("authory"))
        {
            ahmettnyHealthCanvas.SetActive(true);
            authoryHealthCanvas.SetActive(true);

            if (gameObject.name == "magicSword")
            {
                if (ahmettny.transform.position.x - authory.transform.position.x < 0)
                {
                    animator.SetBool("authoryStop", true);
                    animator.SetBool("authoryStopRight", false);
                }
                else
                {
                    animator.SetBool("authoryStop", false);
                    animator.SetBool("authoryStopRight", true);
                }
            }
        }
        else if (!GameObject.Find("step4") && erinavsgarou == 0)
        {
            ahmettnyHealthCanvas.SetActive(false);
            authoryHealthCanvas.SetActive(false);

            if (border1 != null && border2 != null)
            {
                border1.SetActive(true);
                border2.SetActive(true);
            }
        }
        else if (erinavsgarou == 3 && darkGarouHealth > 0)
        {
            darkGarouHealthCanvas.SetActive(true);
            nevoksaHealthCanvas.SetActive(true);
            border1.SetActive(true);
            border2.SetActive(true);
        }

        if (ahmettnyHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (authoryHealth <= 0)
        {
            Destroy(authory);
            nevoksa.SetActive(true);
            authoryHealthCanvas.SetActive(false);
            ahmettnyHealthCanvas.SetActive(false);
            ahmettny.SetActive(false);
        }

        if ((garouHealth <= 0 || erinaHealth <= 0) && erinavsgarou == 0)
        {
            if (border1 != null && border2 != null)
            {
                border1.SetActive(false);
                border2.SetActive(false);
            }

            if (gameObject.name == "baton")
            {
                if (animator.GetBool("batonAttack")) animator.SetBool("batonAttack", false);
                if (animator.GetBool("batonAttackLeft")) animator.SetBool("batonAttackLeft", false);
            }

            erinavsgarou = 1;
        }

        if (darkGarouHealth <= 0)
        {
            Destroy(darkGarouHealthCanvas);
            Destroy(nevoksaHealthCanvas);
            Destroy(border1);
            Destroy(border2);

            if (gameObject.name == "darkGarou")
            {
                Destroy(gameObject);
            }

            erinavsgarou = 4;
        }

        if (nevoksaHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.G) && gameObject.name == "baton" && erinavsgarou == 0)
        {
            if (!handChange)
            {
                if (attack)
                {
                    animator.SetBool("batonAttack", true);
                    animator.SetBool("batonAttackLeft", false);
                }
                else
                {
                    animator.SetBool("batonStop", true);
                    animator.SetBool("batonStopLeft", false);
                }
            }
            else
            {
                if (attack)
                {
                    animator.SetBool("batonAttackLeft", true);
                    animator.SetBool("batonAttack", false);
                }
                else
                {
                    animator.SetBool("batonStopLeft", true);
                    animator.SetBool("batonStop", false);
                }
            }

            handChange = !handChange;
        }

        if (Input.GetKeyDown(KeyCode.F) && gameObject.name == "baton" && erinavsgarou == 0)
        {
            if (attack)
            {
                if (handChange)
                {
                    animator.SetBool("batonStop", true);
                    animator.SetBool("batonAttack", false);
                }
                else
                {
                    animator.SetBool("batonAttackLeft", false);
                    animator.SetBool("batonStopLeft", true);
                }
            }
            else
            {
                if (handChange)
                {
                    animator.SetBool("batonAttack", true);
                    animator.SetBool("batonStop", false);
                }
                else
                {
                    animator.SetBool("batonAttackLeft", true);
                    animator.SetBool("batonStopLeft", false);
                }
            }

            attack = !attack;
        }

        ahmettnyCurrentHealth = ahmettnyHealth; ahmettnyHealthbar.SetHealth(ahmettnyCurrentHealth);
        authoryCurrentHealth = authoryHealth; authoryHealthbar.SetHealth(authoryCurrentHealth);
        garouCurrentHealth = garouHealth; garouHealthbar.SetHealth(garouCurrentHealth);
        erinaCurrentHealth = erinaHealth; erinaHealthbar.SetHealth(erinaCurrentHealth);
        nevoksaCurrentHealth = nevoksaHealth; nevoksaHealthbar.SetHealth(nevoksaCurrentHealth);
        darkGarouCurrentHealth = darkGarouHealth; darkGarouHealthbar.SetHealth(darkGarouCurrentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "shield" &&
            (gameObject.tag == "sword" || gameObject.name == "garou" || gameObject.name == "darkGarou"))
        {
            attackRandomDamage = Random.Range(1, 3);
            attackRandomCount = Random.Range(1, 5);

            if (collision.gameObject.name == "ahmettny" && gameObject.name == "earth")
            {
                ahmettnyHealth -= attackRandomDamage;
            }

            if (collision.gameObject.name == "ahmettny" && gameObject.name == "magicSword")
            {
                if (collision.gameObject.transform.position.x - gameObject.transform.position.x < 0)
                {
                    animator.SetBool("authoryAttack", true);
                    animator.SetBool("authoryStop", false);
                }
                else
                {
                    animator.SetBool("authoryAttackRight", true);
                    animator.SetBool("authoryStopRight", true);
                }

                ahmettnyHealth--;
            }

            if (collision.gameObject.name == "authory" && gameObject.name == "stick" &&
                collision.gameObject.name != "earth")
            {
                authoryHealth--;
            }

            if (collision.gameObject.name == "garou" && gameObject.name == "baton")
            {
                if (attackRandomCount == 1 || attackRandomCount == 3)
                {
                    garouHealth -= attackRandomDamage;
                }
            }

            if (collision.gameObject.name == "erina" && gameObject.name == "garou")
            {
                if (attackRandomCount == 2 || attackRandomCount == 4)
                {
                    erinaHealth -= attackRandomDamage;
                }
            }

            if (collision.gameObject.name == "nevoksa" && gameObject.name == "darkGarou")
            {
                nevoksaHealth -= attackRandomDamage;
            }

            if (collision.gameObject.name == "darkGarou" && gameObject.name == "fireball")
            {
                darkGarouHealth--;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ahmettny" && gameObject.name == "magicSword")
        {
            if (collision.gameObject.transform.position.x - gameObject.transform.position.x < 0)
            {
                animator.SetBool("authoryAttack", false);
                animator.SetBool("authoryStop", true);
            }
            else
            {
                animator.SetBool("authoryAttackRight", false);
                animator.SetBool("authoryStopRight", true);
            }
        }
    }
}
