using UnityEngine;

public class Shield : MonoBehaviour
{
    public static bool reverse;

    void Start()
    {
        gameObject.transform.position = transform.parent.position;
        reverse = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("characterBullet"))
        {
            // Destroy(collision.gameObject);
            MermiHareket.cMermiHiz *= -1;
            reverse = true;
            Invoke(nameof(Reverse), 0.5f);
        }
    }

    public void Reverse()
    {
        reverse = false;
        MermiHareket.cMermiHiz *= -1;
    }
}
