using UnityEngine;

// Level6 (golge labirenti): arka plan rengi ve labirent bolgesi.
public partial class KarakterHareket
{
    private void Level6Start()
    {
        harekethizi = 14;
        ziplamahizi = 16;
        gameObject.transform.position = new Vector3(513.5f, 36, 0);
        mazeMusic = GameObject.Find("Music").GetComponent<AudioSource>();

        if (cam != null)
        {
            mazeDisiArkaPlan = cam.backgroundColor;
        }

        MazeBolgesiniHesapla();
    }

    private void Level6Update()
    {
        if (cam != null && mazeBolgesiVar)
        {
            Vector3 duzlemKonumu = new Vector3(transform.position.x, transform.position.y, mazeBolgesi.center.z);
            cam.backgroundColor = mazeBolgesi.Contains(duzlemKonumu) ? Color.black : mazeDisiArkaPlan;
        }
    }

    private void Level6TriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.name == "mazeEnter")
        {
            // Bu alanlar Level6'da inspector'da bagli degil; biri eksik diye
            // blogun geri kalani (muzik, mazeEnter'in yok edilmesi) atlanmasin.
            if (cam != null)
            {
                cam.backgroundColor = Color.black;
            }

            mazeMusic.clip = mazeMusicClip;
            mazeMusic.Play();
            Destroy(collision.gameObject);

            if (cinemachine != null)
            {
                cinemachine.SetBool("enlarge", false);
                cinemachine.SetBool("shrink", true);
            }
        }
    }

    // Maze bolgesini shadowFloor zeminlerinin kapladigi alandan cikarir; seviye tasarimi
    // degisirse elle koordinat guncellemek gerekmez.
    private void MazeBolgesiniHesapla()
    {
        GameObject[] golgeZeminler = GameObject.FindGameObjectsWithTag("shadowFloor");
        mazeBolgesiVar = false;

        for (int i = 0; i < golgeZeminler.Length; i++)
        {
            Collider2D golgeCollider = golgeZeminler[i].GetComponent<Collider2D>();

            if (golgeCollider == null)
            {
                continue;
            }

            if (!mazeBolgesiVar)
            {
                mazeBolgesi = golgeCollider.bounds;
                mazeBolgesiVar = true;
            }
            else
            {
                mazeBolgesi.Encapsulate(golgeCollider.bounds);
            }
        }

        if (mazeBolgesiVar)
        {
            // Kenarda arka planin titrememesi icin pay birak.
            mazeBolgesi.Expand(new Vector3(12f, 12f, 1000f));
        }
    }
}
