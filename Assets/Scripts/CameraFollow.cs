using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothValue = 1f;
    Vector3 distance;

    void Start()
    {
        distance = target.position - transform.position;
    }

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;
        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);
    }
}
