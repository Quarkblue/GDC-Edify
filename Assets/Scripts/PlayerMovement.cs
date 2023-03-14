using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float jmpFrc;
    public bool isGrounded;
    public LayerMask groundLayerMask;
    public float rayCastLen;

    private Animator playerAnim;
    private SpriteRenderer spr;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * 5, rb.velocity.y);
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jmpFrc);
            
        }
        if (isGrounded)
        {
            playerAnim.SetBool("isJumping", false);
        }
        else if (!isGrounded)
        {
            playerAnim.SetBool("isJumping", true);
        }

        if (rb.velocity.x != 0)
        {
            playerAnim.SetBool("isMoving", true);
        }
        else
        {
            playerAnim.SetBool("isMoving", false);
        }

        if (rb.velocity.x < 0)
        {
            spr.flipX = true;
        }
        else if(rb.velocity.x > 0)
        {
            spr.flipX = false;
        }

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayCastLen, groundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * rayCastLen, Color.red);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            other.GetComponent<Animator>().SetBool("isDestr", true);
            score += 1;
            Destroy(other.gameObject, 0.4f);
            
        }
    }



}
