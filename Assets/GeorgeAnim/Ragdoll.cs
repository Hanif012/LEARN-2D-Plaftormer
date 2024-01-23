using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public PlayerController script;
    bool movedBone = false;
    Rigidbody2D playerRb;

    // Update is called once per frame
    void Update()
    {
        if(script.ragdoll){
            // Debug.Log("Ragdoll");
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            playerRb = script.rb;
            
            if(!movedBone){
                this.transform.GetComponent<Rigidbody2D>().velocity = playerRb.velocity + new Vector2(Random.Range(-playerRb.velocity.x,playerRb.velocity.x), Random.Range(-playerRb.velocity.y,playerRb.velocity.y));
                movedBone = true;
                if(this.transform.name == "bone_1"){
                    this.transform.position = script.transform.position;
                    StartCoroutine("CamWait", 0.3f);
                }
            }
            if(this.transform.name == "bone_1"){
                Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
            }
            this.transform.GetComponent<CapsuleCollider2D>().enabled = true;
            if(this.gameObject.GetComponent<HingeJoint2D>() != null){
                this.transform.GetComponent<HingeJoint2D>().enabled = true;
            }
        }else{
            //not ragdoll
            if(movedBone && this.transform.name == "bone_1"){
                script.transform.position = this.transform.position;
                this.transform.localPosition = new Vector3(1,18,0);
                script.transform.GetComponent<Animator>().enabled = true;
            }
            movedBone = false;
            if(this.transform.name == "bone_1"){
                Camera.main.transform.position = new Vector3(script.transform.position.x, script.transform.position.y+2.5f, Camera.main.transform.position.z);
                this.transform.localRotation = Quaternion.Euler(0,0,90f);
            }
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            this.transform.GetComponent<CapsuleCollider2D>().enabled = false;
            if(this.gameObject.GetComponent<HingeJoint2D>() != null){
                this.transform.GetComponent<HingeJoint2D>().enabled = false;
            }
        }

    }
    IEnumerator CamWait (int seconds){
        yield return new WaitForSeconds(seconds);
    }
}
