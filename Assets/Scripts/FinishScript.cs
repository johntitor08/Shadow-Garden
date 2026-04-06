using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject panel;
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.CompareTag("karakter") && ScoreGenerator.yildizpuani_int == 31)
        {
            panel.SetActive(true);
            audioSource.Play();
            Time.timeScale = 0;
        }
    }
}
