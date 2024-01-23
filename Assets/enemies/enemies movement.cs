using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesmovement : MonoBehaviour
{
     public Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    // [SerializeField] float max = 5f;
    // [SerializeField] float min;
    // [SerializeField] float limit;
    public bool turnRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // limit=rb.position.x + max;
        // min = rb.position.x;
        if(turnRight==false){
            speed*=-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, -20);   
        // if(rb.position.x == limit && turn){
        //     speed *= -1;
        //     turn = !turn;
        // }
        // if(rb.position.x == min && !turn){
        //     speed *= -1;
        //     turn = !turn;
        //  }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player" || other.tag =="Bone"){
        }
        else{
            speed *= -1;
            turnRight = !turnRight;
        }
    }
}
