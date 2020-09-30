using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool faceRight = true;
    public float speed;
    public Rigidbody2D rb;

    private bool isGround;
    public Transform feetPos;
    public float radius;
    public float jumpForce;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);

        if (faceRight == false && MoveInput > 0)
        {
            Flip();
        }
        else if (faceRight == true && MoveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    private void Update()
    {
        isGround = Physics2D.OverlapCircle(feetPos.position, radius, whatIsGround);

        if (isGround == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
