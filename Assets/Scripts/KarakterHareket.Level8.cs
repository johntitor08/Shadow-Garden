using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

// Level8: kamera sarsintisi, lav hiz asamalari, diyaloglar ve gizli "100 vurus" objeleri.
public partial class KarakterHareket
{
    private void Level8Start()
    {
        InvokeRepeating(nameof(Shake), 5f, 5f);
        gameObject.transform.position = new Vector3(-11.5f, -1.1f, 0f);
        cruelSunTimeline = GameObject.Find("TimelineCruelSun").GetComponent<PlayableDirector>();
        movingCam = GameObject.FindGameObjectWithTag("moveCamera").GetComponent<CinemachineVirtualCamera>();
        fart = GameObject.Find("Fart").GetComponent<AudioSource>();
        secretMusic = GameObject.Find("SecretMusic").GetComponent<AudioSource>();
    }

    private void Level8Update()
    {
        harekethizi = 12;

        if (changeSpeed == 0)
        {
            ziplamahizi = 10;
        }

        else if (changeSpeed == 1)
        {
            ziplamahizi = 12;
        }

        else if (changeSpeed == 2)
        {
            ziplamahizi = 15;
        }

        if (cruelSunTimeline.time >= 14.9f)
        {
            cinemachine.SetBool("cruelSun", false);
            GameObject.Find("lavaPass").GetComponent<BoxCollider2D>().isTrigger = true;
        }

    }

    private void Level8CollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.name == "Hit100times1")
        {
            hit++;

            if (hit >= 100)
            {
                Destroy(collision.gameObject);
                secretMusic.Play();
                GameObject.Find("Music").GetComponent<AudioSource>().Stop();
            }
        }

        if (collision.gameObject.name == "Hit100times2")
        {
            hit++;

            if (hit >= 200)
            {
                Destroy(collision.gameObject);
                fart.Play();
            }
        }
    }

    private void Level8TriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.name == "lavaSensor")
        {
            changeSpeed = 1;
            cruelSunTimeline.Play();
            cinemachine.SetBool("cruelSun", true);
        }
        else if (collision.gameObject.name == "sensorLava2")
        {
            changeSpeed = 0;
        }

        if (collision.gameObject.name == "sensorAuthory")
        {
            authoryDialogue.SetActive(true);
        }

        if (collision.gameObject.name == "sensorLavinia")
        {
            laviniaDialogue.SetActive(true);
        }
    }

    private void Level8TriggerExit(Collider2D collision)
    {
        if (collision.gameObject.name == "sensorAuthory")
        {
            authoryDialogue.SetActive(false);
        }

        if (collision.gameObject.name == "sensorLavinia")
        {
            laviniaDialogue.SetActive(false);
        }
    }

    public void Shake()
    {
        cinemachine.SetTrigger("shake");
    }
}
