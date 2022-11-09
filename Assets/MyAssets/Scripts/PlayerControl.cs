using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    public bool isGround;
    PlayerAnim playerAnim;

    float x, y;
    Vector3 move;
    Rigidbody rb;
    bool running, crouch;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<PlayerAnim>();
        isGround = true;
        running = false;
        crouch = false;
    }

    private void Update()
    {
        Movement();

        if (isGround)
        {
            if(Input.GetButtonDown("Jump"))
                Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            crouch = !crouch;
            Shift(crouch);
        }
    }

    void Movement()
    {
        transform.position += transform.forward * MovementVector().y * speed * Time.deltaTime;

        if (MovementVector() != Vector2.zero && isGround && !running)
        {
            if (!crouch)
            {
                playerAnim.Run(true);
            }
            else if (crouch)
            {
                playerAnim.SneakRun(true);
            }
            running = true;
        }
        
        if(running && MovementVector() == Vector2.zero)
        {
            if (!crouch)
            {
                playerAnim.Run(false);
            }
            else if (crouch)
            {
                playerAnim.SneakRun(false);
            }
            running = false;
        }
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

    void Shift(bool state)
    {
        playerAnim.CrouchStand(state);
    }
}
