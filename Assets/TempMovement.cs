using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }
}
