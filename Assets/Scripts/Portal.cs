using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Portal : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("karakter"))
        {
            audioSource.Play();
        }
    }
}
