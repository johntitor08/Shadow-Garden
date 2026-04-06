using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MermiHareket : MonoBehaviour
{
    public Vector2 vec;
    private Rigidbody2D rb;
    public static float cMermiHiz;
    public static float eMermiHiz;
    public static float fireTime;
    public static bool fire;

    private void Start()
    {
        eMermiHiz = 500f;
        cMermiHiz = 500f;
        rb = GetComponent<Rigidbody2D>();
        fire = false;
    }

    void Update()
    {
        if (gameObject.CompareTag("characterBullet"))
        {
            rb.linearVelocity = 0.025f * cMermiHiz * new Vector2(vec.x, vec.y);
        }
        else if (gameObject.CompareTag("enemyBullet"))
        {
            rb.linearVelocity = 0.025f * eMermiHiz * new Vector2(vec.x, vec.y);
        }
        else if (gameObject.name == "fireball" && Input.GetKeyDown(KeyCode.F) && fireTime >= 0.2f)
        {
            rb.linearVelocity = 0.025f * cMermiHiz * new Vector2(2, vec.y);
            fireTime = 0;
            fire = true;
        }

        fireTime += Time.deltaTime;
    }
}
