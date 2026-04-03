using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpandam : MonoBehaviour
{
    bool rote;
    public float speed;
    Rigidbody2D rb;
    public GameObject mermi;
    public Transform atesNoktasi;
    float atisHizi;
    float atesSayac;
    Animator anim;
    public int health;


    void Start()
    {
        health = 3;
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            rote = true;
        }
        if (i == 1)
        {
            rote = false;
        }

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        atisHizi = 2.4f;
    }

    void Update()
    {

        if (rote)
        {
            rb.linearVelocity = Vector2.left * speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            atisHizi = -2.4f;
        }
        if (!rote)
        {
            rb.linearVelocity = Vector2.right * speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            atisHizi = 2.4f;
        }

        atesSayac -= Time.deltaTime;

        if (atesSayac < 0)
        {
            AtesEt();
            atesSayac = 1.5f;
        }

    }

    public void AtesEt()
    {
        GameObject mermiPrefab = Instantiate(mermi, atesNoktasi.position, atesNoktasi.rotation);
        mermiPrefab.GetComponent<MermiHareket>().vec = new Vector2(atisHizi, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "characterBullet" && SceneManager.GetActiveScene().name != "Training")
        {
            health--;
            anim.SetTrigger("isDamaged");

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            rote = !rote;
        }
    }
}
