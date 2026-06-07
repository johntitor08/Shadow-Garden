using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("karakter") || collision.gameObject.CompareTag("characterBullet") || collision.gameObject.CompareTag("enemyBullet") || collision.gameObject.CompareTag("enemy"))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
