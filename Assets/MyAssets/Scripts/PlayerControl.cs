using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    public bool isGround;

    float x, y;
    Vector3 move;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isGround = true;
    }

    private void Update()
    {
        Movement();

        if (isGround)
        {
            if(Input.GetButtonDown("Jump"))
                Jump();
        }
    }

    void Movement()
    {
        transform.position += transform.forward * MovementVector().y * speed * Time.deltaTime;
    }

    public Vector2 MovementVector()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        move = new Vector2(x, y);

        return move;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
}
