using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;


    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rigidB;
    private Vector3 velocity = Vector3.zero;



    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidB.velocity.y);
        rigidB.velocity = Vector3.SmoothDamp(rigidB.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rigidB.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}
