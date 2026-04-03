using UnityEngine;
using UnityEngine.SceneManagement;

public class WeakPoint : MonoBehaviour
{
    public int health;
    private Animator animator;

    void Start()
    {
        gameObject.transform.position = new Vector2(transform.parent.position.x - 0.12f, transform.parent.position.y + 0.32f);
        animator = gameObject.GetComponentInParent<Animator>();
        health = 4;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "characterBullet")
        {
            Destroy(collision.gameObject);
            health--;
            animator.SetTrigger("isDamaged");
            if (health <= 0)
            {
                Destroy(transform.parent.gameObject);
                if (SceneManager.GetActiveScene().name == "Level7")
                {
                    ScoreGenerator.scorePoint_int++;

                }
            }
        }
    }
}
