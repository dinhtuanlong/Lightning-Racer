using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody rb;
    string PLAYER_STRING = "Player";
    bool needToFall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y > 0)
        {
            rb.isKinematic = false;
        } else if (transform.position.y <= 0 && !needToFall)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            rb.isKinematic = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_STRING))
        {
            needToFall = true;
            Invoke("Fall", 0.2f);
        }
    }

    void Fall()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 1.5f);
    }
}
