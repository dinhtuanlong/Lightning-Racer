using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    bool movingLeft = true;
    bool firstInput = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
