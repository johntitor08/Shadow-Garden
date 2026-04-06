using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class YıldızScript : MonoBehaviour
{
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.CompareTag("karakter"))
        {
            ScoreGenerator.yildizpuani_int += 1;
            audioSource.Play();
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            //circleCollider.isTrigger = false;
            Destroy(this.gameObject, 1f);
        }
    }
}
