using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public Rigidbody2D rb;

    public CapsuleCollider2D playerCollider;
    public Animator animator;
    public bool ragdoll = false;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;

    public bool isJumpPressed = false;
    public bool facingRight = true;
    public Transform transform;
    public GameObject childObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isJumpPressed = true;
            animator.SetTrigger("nigger");
            Debug.Log("Update Jump");
        }  
    }

    void FixedUpdate()
    {
         if (isJumpPressed)
        {
            Debug.Log("FixedUpdate Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);   
            isJumpPressed = false;
        }
         if(rb.velocity.y < 0.02 &&rb.velocity.y > -0.02 ){
            animator.SetBool("grounded",true);
        }
        else
            animator.SetBool("grounded",false);

        animator.SetFloat("yaxis",rb.velocity.y );
        if(Input.GetKeyDown(KeyCode.Z)){
            ragdoll=!ragdoll;
        }
        if(ragdoll){
            // childCollider.enabled = false;
            animator.enabled=false;
        }
        else{
           animator.enabled=true;
           
        }
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
