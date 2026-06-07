using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Boss : MonoBehaviour
{
    public int health;
    public Healthbar healthbar;
    public int maxHealth;
    public int currentHealth;
    public GameObject bossHealthCanvas;
    Transform target;
    public bool faceRight;
    public bool turned;
    Rigidbody2D rb;
    Animator anim;
    public float jumpTime;
    public float randomTime;
    public float speedTime;
    public Text healthbarText;
    public GameObject stage3Part2;

    void Start()
    {
        health = 15;
        maxHealth = 15;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        bossHealthCanvas.SetActive(false);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stage3Part2.SetActive(false);
    }

    void Update()
    {
        GameObject karakter = GameObject.FindGameObjectWithTag("karakter");
        if (karakter == null)
        {
            return;
        }
        target = karakter.transform;

        if (transform.localScale.x > 0)
        {
            faceRight = true;
            turned = true;
        }
        else if (transform.localScale.x < 0)
        {
            faceRight = false;
            turned = false;
        }

        if (Vector2.Distance(transform.position, target.position) < 30)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 0.15f);
            bossHealthCanvas.SetActive(true);

            if (jumpTime < 0)
            {
                //jumpTime = 3;
                jumpTime = Random.Range(3f, 5f);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 35);
            }

            if (speedTime < -10)
            {
                speedTime = 3f;
            }
            if (speedTime > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, 0.3f);
            }

            //if (jumpTime >= randomTime)
            //{
            //    randomTime = Random.Range(0.5f, 1f);
            //    randomTime = 1f;
            //}

            transform.LookAt(transform.position);
            transform.position = Vector2.Lerp(transform.position, target.position, 0.001f);
        }

        if (faceRight == true && target.position.x - transform.position.x < 0 || faceRight == false && target.position.x - transform.position.x > 0)
        {
            Turn();
            TurnText();
        }

        jumpTime -= Time.deltaTime;
        speedTime -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("characterBullet"))
        {
            health--;
            currentHealth = health;
            healthbar.SetHealth(currentHealth);
            anim.SetTrigger("isDamaged");
            
            if (health <= 0)
            {
                if (SceneManager.GetActiveScene().name == "Level7")
                {
                    ScoreGenerator.scorePoint_int++;
                    stage3Part2.SetActive(true);
                }

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "nora" && collision.gameObject.name == "Spawner")
        {
            transform.position = new Vector3(267, 51.5f, 0);
        }
    }

    void Turn()
    {
        faceRight = !faceRight;
        Vector2 yeniscale = transform.localScale;
        yeniscale.x *= -1;
        transform.localScale = yeniscale;
    }

    void TurnText()
    {
        turned = !turned;
        Vector2 textScale = healthbarText.transform.localScale;
        textScale.x *= -1;
        healthbarText.transform.localScale = textScale;
        Vector2 barScale = healthbar.transform.localScale;
        barScale.x *= -1;
        healthbar.transform.localScale = barScale;
    }
}
