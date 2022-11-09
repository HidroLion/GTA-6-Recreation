using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float rotateSpeed;

    public bool isGround;
    PlayerAnim playerAnim;
    float sneakSpeed;

    float x, y;
    Vector3 move;
    Rigidbody rb;
    bool running, crouch;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<PlayerAnim>();
        sneakSpeed = speed / 2;

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
            if(MovementVector() == Vector2.zero)
            {
                crouch = !crouch;
                Shift(crouch);
            }
        }
    }

    void Movement()
    {
        transform.position += transform.forward * MovementVector().y * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotateSpeed * MovementVector().x * Time.deltaTime);

        if(MovementVector().y != 0 && !running)
        {
            if (crouch)
                playerAnim.SneakRun(true);
            else if (!crouch)
                playerAnim.Run(true);

            running = true;
        }
        else if(MovementVector().y == 0 && running)
        {
            if (crouch)
                playerAnim.SneakRun(false);
            else if (!crouch)
                playerAnim.Run(false);

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
        crouch = false;
        Shift(false);
        playerAnim.Jump();
    }

    void Shift(bool state)
    {
        playerAnim.CrouchStand(state);

        if (crouch)
            speed = sneakSpeed;
        else if (!crouch)
            speed = sneakSpeed * 2;
    }
}
