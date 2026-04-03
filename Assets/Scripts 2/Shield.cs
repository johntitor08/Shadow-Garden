using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public static bool reverse;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = transform.parent.position;
        reverse = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "characterBullet")
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
