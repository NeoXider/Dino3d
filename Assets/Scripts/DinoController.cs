using UnityEngine;

public class DinoController : MonoBehaviour
{
    // сила и прыжка
    public float jumpForce = 5f;
    // скорость передвижения
    public float speed = 5f;

    // расстояние до земли для проверки на землю
    public float rayDistance = 1.1f;

    // переменная для проверки на землю
    private bool isGround = false;
    // Rigidbody для управления физикой динозавра
    public Rigidbody rb;

    // метод Update вызывается каждый кадр
    void Update()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, rayDistance);
        if (!GameController.Instance.isGameOver)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (isGround)
            {
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     Jump();
                 }
            }
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(0, jumpForce, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayDistance);
    }
}