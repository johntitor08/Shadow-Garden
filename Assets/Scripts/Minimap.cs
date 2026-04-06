using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        transform.position = newPosition;
    }
}
