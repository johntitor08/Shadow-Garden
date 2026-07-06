using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public int health;
    Transform target;
    public bool faceRight;
    public GameObject mermi;
    public Transform atesNoktasi;
    public static float atisHizi;
    float atesSayac;
    Animator anim;
    public static bool hareketEt;
    Rigidbody2D rb;
    float bigEnemyTime;
    float bigEnemyRandomTime;
    public GameObject portal;
    public GameObject areaUp;
    public Healthbar healthbar;
    public int maxHealth;
    public int currentHealth;
    public GameObject bossHealthCanvas;

    void Start()
    {
        if (gameObject.CompareTag("bigEnemy"))
        {

            if (gameObject.name == "bigEnemyFirst")
            {
                health = 7;
                maxHealth = 7;
                currentHealth = maxHealth;
                if (healthbar != null)
                {
                    healthbar.SetMaxHealth(maxHealth);
                }
                if (bossHealthCanvas != null)
                {
                    bossHealthCanvas.SetActive(false);
                }
            }
            else
            {
                health = 5;
            }

        }

        if (gameObject.CompareTag("enemy"))
        {
            if (SceneManager.GetActiveScene().name != "Level7")
            {
                health = 3;

            }

        }

        if (gameObject.CompareTag("heraclus"))
        {
            health = 3;
        }

        //StartCoroutine(AtesEt());
        //InvokeRepeating("AtesEt", 0.5f, 1f);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hareketEt = true;
        bigEnemyRandomTime = 0.5f;

        if (gameObject.CompareTag("superEnemy") && SceneManager.GetActiveScene().name == "Level5")
        {
            maxHealth = 10;
            currentHealth = maxHealth;
            if (healthbar != null)
            {
                healthbar.SetMaxHealth(maxHealth);
            }
            if (bossHealthCanvas != null)
            {
                bossHealthCanvas.SetActive(false);
            }

        }

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

        }
        else if (transform.localScale.x < 0)
        {
            faceRight = false;

        }

        if (faceRight)
        {
            atisHizi = 2.4f;

        }
        else
        {
            atisHizi = -2.4f;

        }

        bigEnemyTime -= Time.deltaTime;


        if (Vector2.Distance(transform.position, target.position) < 15)
        {
            if (hareketEt == true)
            {
                if (gameObject.CompareTag("enemy") || gameObject.CompareTag("jumperEnemy"))
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, 0.005f);

                }
                else if (gameObject.CompareTag("heraclus"))
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, 0.05f);
                }

                if (gameObject.CompareTag("jumperEnemy"))
                {
                    if (bigEnemyTime < 0)
                    {
                        bigEnemyTime = 1.5f;

                        if (bigEnemyTime >= bigEnemyRandomTime)
                        {
                            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15);
                            bigEnemyRandomTime = Random.Range(0.5f, 1f);

                            //if (faceRight)
                            //{
                            //    transform.position += Vector3.right * 2;
                            //}
                            //else
                            //{
                            //    transform.position += Vector3.left * 2;
                            //}

                        }

                    }

                }

                transform.LookAt(transform.position);
                transform.position = Vector2.Lerp(transform.position, target.position, 0.001f);

            }
            
            if (atesSayac < 0 && Vector2.Distance(transform.position, target.position) > 2)
            {
                AtesEt();

                if (!gameObject.CompareTag("jumperEnemy"))
                {
                    atesSayac = Random.Range(1f, 2f);

                }
                else
                {
                    atesSayac = Random.Range(0.5f, 1.5f);

                }

            }

        }

        if (Vector2.Distance(transform.position, target.position) < 30)
        {
            if (gameObject.CompareTag("bigEnemy"))
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, 0.12f);

                if (bigEnemyTime < 0)
                {
                    bigEnemyTime = 5;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 25);

                }

                if (gameObject.name == "bigEnemyFirst")
                {
                    bossHealthCanvas.SetActive(true);

                }

            }
            
        }

        if (Vector2.Distance(transform.position, target.position) < 30)
        {
            if (gameObject.CompareTag("superEnemy"))
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, 0.15f);

                if (SceneManager.GetActiveScene().name == "Level5")
                {
                    bossHealthCanvas.SetActive(true);

                }

                if (bigEnemyTime < 0)
                {
                    bigEnemyTime = 10;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 25);

                }

            }

        }

        if (faceRight == true && target.position.x - transform.position.x < 0 || faceRight == false && target.position.x - transform.position.x > 0)
        {
            Turn();

        }

        atesSayac -= Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("characterBullet") && SceneManager.GetActiveScene().name != "Training" && !gameObject.CompareTag("jumperEnemy"))
        {
            health--;

            if (gameObject.CompareTag("superEnemy"))
            {
                currentHealth = health;

                if (SceneManager.GetActiveScene().name == "Level5")
                {
                    healthbar.SetHealth(currentHealth);

                }

            }

            if (gameObject.CompareTag("bigEnemy") && gameObject.name == "bigEnemyFirst")
            {
                currentHealth = health;
                healthbar.SetHealth(currentHealth);

            }

            anim.SetTrigger("isDamaged");

            if (health <= 0)
            {

                if (gameObject.CompareTag("bigEnemy") && gameObject.name == "bigEnemyFirst" && SceneManager.GetActiveScene().name == "Level4")
                {
                    Instantiate(portal, transform.position, portal.transform.rotation);

                }

                if (gameObject.CompareTag("superEnemy") && SceneManager.GetActiveScene().name == "Level5")
                {
                    areaUp.SetActive(true);
                    Destroy(bossHealthCanvas);

                }

                if (gameObject.CompareTag("enemy") && SceneManager.GetActiveScene().name == "Level7")
                {
                    ScoreGenerator.scorePoint_int++;

                }

                Destroy(gameObject);

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lava"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10);

        }

    }

    public void AtesEt()
    {
        GameObject mermiPrefab = Instantiate(mermi, atesNoktasi.position, atesNoktasi.rotation);
        mermiPrefab.GetComponent<MermiHareket>().vec = new Vector2(atisHizi, 0);

        if (gameObject.CompareTag("bigEnemy") || gameObject.CompareTag("superEnemy"))
        {
            mermiPrefab.transform.localScale = new Vector2(0.2f, 0.4f);

        }

        if (gameObject.CompareTag("superEnemy"))
        {
            GameObject mermiPrefab2 = Instantiate(mermi, atesNoktasi.position, atesNoktasi.rotation);
            mermiPrefab2.transform.position += new Vector3(0, 2, 0);
            mermiPrefab2.GetComponent<MermiHareket>().vec = new Vector2(atisHizi, 0);
            mermiPrefab2.transform.localScale = new Vector2(0.2f, 0.4f);
            
        }

    }

    //private IEnumerator AtesEt()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(1f);
    //        GameObject mermiPrefab = Instantiate(mermi);

    //    }

    //}

    private void Turn()
    {
        faceRight = !faceRight;
        Vector2 yeniscale = transform.localScale;
        yeniscale.x *= -1;
        transform.localScale = yeniscale;
        atisHizi *= -1;

    }

}
