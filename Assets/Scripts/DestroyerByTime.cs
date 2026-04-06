using UnityEngine;

public class DestroyerByTime : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }
}
