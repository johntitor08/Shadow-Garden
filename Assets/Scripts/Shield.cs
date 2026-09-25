using UnityEngine;

public class Shield : MonoBehaviour
{
    // Kalkana carpan oyuncu mermileri bu zamana kadar ters yone gider. Eskiden ortak
    // MermiHareket.cMermiHiz isaret degistiriliyordu; ama her yeni mermi Start'ta onu
    // 500'e sifirladigi icin geri alma islemi hizi kalici olarak ters birakabiliyordu.
    static float reverseBitis;

    public static bool reverse => Time.time < reverseBitis;

    void Start()
    {
        gameObject.transform.position = transform.parent.position;
        reverseBitis = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("characterBullet"))
        {
            // Destroy(collision.gameObject);
            reverseBitis = Time.time + 0.5f;
        }
    }
}
