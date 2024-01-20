using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public BoxCollider2D playerCollider;
    public Animator animator;
    public bool facingRight = true;
    public Transform transform;
    [SerializeField] float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if(h > 0 && !facingRight)
            Flip();
        else if(h < 0 && facingRight)
            Flip();
        PlayerMovement();
        
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput !=0){
            animator.SetBool("isRunning",true);
        }
        else{
            animator.SetBool("isRunning",false);
        }
        animator.SetFloat("Speed",horizontalInput);
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
