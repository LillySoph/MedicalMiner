using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
  [SerializeField]// <-- private but still shows up in Unity GUI
  private Rigidbody2D rigidBody;
  [SerializeField]
  private BoxCollider2D boxCollider2d;
  [SerializeField]
  private LayerMask groudLayer;

  [SerializeField]
  private float speed;
  [SerializeField]
  private float shamshDown;

  [SerializeField]
  private float jumpIncrease;
  [SerializeField]
  private float maxJumpSpeed;
  [SerializeField]
  private float timeToIncrease;
  [SerializeField]
  private float jumpSpeed;
  private bool jumping = false;
  private float startTime;
  private float tempJumpSpeed;
  private float tempTimeToIncrease;


  private bool isGrounded(){
    float extraHeight = 0.02f;
    //Box around bottom of player that checks if player is on something with the Layer "Ground"
    RaycastHit2D raycast = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,0f, Vector2.down, extraHeight, groudLayer);
    return raycast.collider != null;
  }

  // Time.deltaTime => time per frame
  // => movementspeed/seconds and not movementspeed/frame
  void Update () {
  		if (Input.GetKey(KeyCode.D)){
        //right
  			transform.position += Vector3.right * speed * Time.deltaTime;
  		}
      if (Input.GetKey(KeyCode.A)){
        //left
        transform.position += Vector3.left * speed * Time.deltaTime;
  		}

      if (Input.GetKey(KeyCode.S) && !isGrounded()){
        //ForceDown stops jump and speeds down
        jumping = false;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
  			transform.position += Vector3.down * shamshDown * Time.deltaTime;
  		}

      if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && !Input.GetKey(KeyCode.S)){
        //Jump only if on Ground and not ForceDown
        if(!jumping){
          rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        jumping = true;
        tempJumpSpeed = jumpSpeed;
        tempTimeToIncrease = timeToIncrease;
        startTime = Time.time;
  		}
      if (Input.GetKeyUp(KeyCode.Space)){
        //Resets everything for next Jump
        tempJumpSpeed = jumpSpeed;
        tempTimeToIncrease = timeToIncrease;
        jumping = false;
      }
      if (Input.GetKey(KeyCode.Space) && jumping){
        //longjump
        if(Time.time - startTime > tempTimeToIncrease){
          if(tempJumpSpeed + jumpIncrease > maxJumpSpeed){
            jumping = false;
          }else{
            tempJumpSpeed = tempJumpSpeed + jumpIncrease;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, tempJumpSpeed);
            startTime = Time.time;
            tempTimeToIncrease = (int) (tempTimeToIncrease/1.5);
          }
        }
  		}
  	}


}
