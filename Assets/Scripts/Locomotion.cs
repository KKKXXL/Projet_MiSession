using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{


    //Variables pour Jump
    private Rigidbody2D rigid;
    [Header("Jump")]
    [SerializeField] private float jumpForce = 6f;
    //Variables pour le movement
    [Header("Movement")]
    [SerializeField] private float speed = 6f;
    private Vector2 refVelocity = Vector2.zero;
    [Tooltip("Delais pour atteindre la vitesse maximale")] [Range(0, 0.3f)] [SerializeField] private float smoothTime = 0.05f;
    //Variables pour le Changments de Direction
    private bool faceLeft = false;
    private SpriteRenderer sprite;
    //Variables pour Check Ground
    private bool isGrounded = false;
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    const float checkRadius = 0.2f;
    


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            GameController.Instance.ShowGameOverPanel();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Saw")
        {
            GameController.Instance.ShowGameOverPanel();
            Destroy(gameObject);
        }
    }

    public void Move(float move, bool jump)
    {
        Jumping(jump);
        Movement(move);
        CheckOrientation(move);
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    void CheckGrounded()
    {
        Collider2D col = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isGrounded = (col != null);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isGrounded ? Color.blue : Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    void Jumping(bool jump )
    {
        if (jump && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Movement(float move)
    {
        Vector2 targetVelocity = new Vector2(move * speed, rigid.velocity.y);
        rigid.velocity = Vector2.SmoothDamp(rigid.velocity, targetVelocity, ref refVelocity, smoothTime);
    }

    void CheckOrientation(float move)
    {
        if ((move > 0 && faceLeft) || (move < 0 && !faceLeft))
        {
            faceLeft = !faceLeft;
            sprite.flipX = faceLeft;
        }
    }

}
