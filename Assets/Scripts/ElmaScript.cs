using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class ElmaScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    AudioSource audioSource;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("karakter"))
        {
            ElmaYokEt();
        }
    }

    public void ElmaYokEt()
    {
        audioSource.Play();
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
        Destroy(this.gameObject, 5f);
    }
}
