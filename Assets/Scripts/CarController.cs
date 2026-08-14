using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    public GameObject pickupFX;
    bool movingLeft = true;
    bool firstInput = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
        }
        if (transform.position.y <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            GameManager.instance.DiamondIncrementScore();
            Instantiate(pickupFX, other.transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void CheckInput()
    {
        if (firstInput)
        {
            firstInput = false;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 90f, 0);
            movingLeft = false;
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            movingLeft = true;
        }
    }
}
