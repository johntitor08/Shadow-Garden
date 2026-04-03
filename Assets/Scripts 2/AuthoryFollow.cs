using UnityEngine;

public class AuthoryFollow : MonoBehaviour
{
    public bool faceRight;
    public GameObject ahmettny;
    public GameObject canvas;
    public Animator anim;
    public GameObject erina;
    public GameObject ahmettnyHealthCanvas;
    public GameObject erinaHealthCanvas;
    public GameObject garouHealthCanvas;
    public GameObject authoryHealthCanvas;
    public GameObject nevoksaHealthCanvas;
    public GameObject darkGarouHealthCanvas;
    public GameObject nevoksa;
    Rigidbody2D rb;
    public Rigidbody2D rbAhmettny;

    void Start()
    {
        if (gameObject.name == "authory")
        {
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }

    }


    void Update()
    {
        if (!GameObject.Find("step2") && gameObject.name == "authory")
        {
            transform.position = Vector2.MoveTowards(transform.position, ahmettny.transform.position, 0.05f);
            InvokeRepeating("Earth", 0, 1);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            if (faceRight == true && ahmettny.transform.position.x - transform.position.x < 0 || faceRight == false && ahmettny.transform.position.x - transform.position.x > 0)
            {
                Turn();
            }
        }

        if (GameObject.Find("erina") && gameObject.name == "garou" && Sword.erinavsgarou == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, erina.transform.position, 0.05f);
            anim.SetBool("attack", true);

            if (faceRight == true && erina.transform.position.x - transform.position.x < 0 || faceRight == false && erina.transform.position.x - transform.position.x > 0)
            {
                Turn();
            }
        }

        if (GameObject.Find("nevoksa") && gameObject.name == "darkGarou" && Sword.erinavsgarou == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, nevoksa.transform.position, 0.1f);
            anim.SetBool("darkGarouAttack", true);

            if (faceRight == true && nevoksa.transform.position.x - transform.position.x < 0 || faceRight == false && nevoksa.transform.position.x - transform.position.x > 0)
            {
                Turn();
            }
        }

        if (Sword.erinavsgarou != 0 && gameObject.name == "garou")
        {
            anim.SetBool("attack", false);
        }

        if (Sword.erinavsgarou != 3 && gameObject.name == "darkGarou")
        {
            anim.SetBool("darkGarouAttack", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Spawner" || collision.gameObject.tag == "lava")
        {
            if (gameObject.name == "authory")
            {
                nevoksa.SetActive(true);
                ahmettnyHealthCanvas.SetActive(false);
                authoryHealthCanvas.SetActive(false);
                ahmettny.SetActive(false);
                Destroy(gameObject);
            }

            if (gameObject.name == "garou")
            {
                nevoksa.SetActive(true);
                garouHealthCanvas.SetActive(false);
                erinaHealthCanvas.SetActive(false);
                Destroy(gameObject);
            }

            if (gameObject.name == "darkGarou")
            {
                nevoksa.SetActive(true);
                nevoksaHealthCanvas.SetActive(false);
                darkGarouHealthCanvas.SetActive(false);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.name == "ahmettny" && gameObject.name == "authory")
        {
            Sword.ahmettnyHealth--;

            if (faceRight)
            {
                rbAhmettny.AddForce(Vector2.right * 50);
            }
            else
            {
                rbAhmettny.AddForce(Vector2.left * 50);
            }
        }
    }

    void Turn()
    {
        faceRight = !faceRight;
        Vector2 yeniscale = transform.localScale;
        yeniscale.x *= -1;
        transform.localScale = yeniscale;
        Vector2 textScale = canvas.transform.localScale;
        textScale.x *= -1;
        canvas.transform.localScale = textScale;
    }

    void Earth()
    {
        anim.SetTrigger("earth");
    }

}
