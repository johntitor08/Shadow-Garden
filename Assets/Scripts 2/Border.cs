using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Border : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "karakter" || collision.gameObject.tag == "mermi" || collision.gameObject.tag == "enemy")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }

    }
}
