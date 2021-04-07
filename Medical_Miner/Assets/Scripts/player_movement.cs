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
  private LayerMask groundLayer;

  [SerializeField]
  private float speed;
  [SerializeField]
  private float shamshDown;
  [SerializeField]
  private float distance;

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
  private bool facingRight = true;

  public Animator animator;

  private bool isGrounded(){
    //Box around bottom of player that checks if player is on something with the Layer "Ground"
    Vector2 position = transform.position;
    Vector2 offset = new Vector2 (0.15f, 0.0f);
    Vector2 direction = Vector2.down;

    RaycastHit2D raycastL = Physics2D.Raycast(position - offset, direction, distance, groundLayer);
    RaycastHit2D raycastR = Physics2D.Raycast(position + offset, direction, distance, groundLayer);
    return raycastL.collider != null || raycastR.collider != null;
  }

  // Time.deltaTime => time per frame
  // => movementspeed/seconds and not movementspeed/frame
  private bool isJumping = false;
  void Update () {
    bool isWalking = false;

  		if (Input.GetKey(KeyCode.D)){
        //right
        isWalking = true;
  			transform.position += Vector3.right * speed * Time.deltaTime;
            if (!facingRight && !PauseMenu.GameIsPaused)
            {
                Flip();
            }
  		}
      if (Input.GetKey(KeyCode.A)){
        //left
        isWalking = true;
        transform.position += Vector3.left * speed * Time.deltaTime;
            if (facingRight && !PauseMenu.GameIsPaused)
            {
                Flip();
            }
  		}

      if (Input.GetKey(KeyCode.S) && !isGrounded()){
        //ForceDown stops jump and speeds down
        jumping = false;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
  			transform.position += Vector3.down * shamshDown * Time.deltaTime;
  		}

      if (Input.GetKey(KeyCode.Space) && isGrounded() && !Input.GetKey(KeyCode.S) && !jumping){
        //Jump only if on Ground and not ForceDown

        // rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        rigidBody.velocity = new Vector2(rigidBody.velocity.x * Time.deltaTime, jumpSpeed);
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
            // rigidBody.velocity = new Vector2(rigidBody.velocity.x, tempJumpSpeed);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x * Time.deltaTime, tempJumpSpeed);
            startTime = Time.time;
            tempTimeToIncrease = (int) (tempTimeToIncrease/1.2);
          }
        }
  		}
      isJumping = !isGrounded();
      Debug.Log("W:" + isWalking);
      Debug.Log("J:" + isJumping);
      animator.SetBool("Walking", isWalking);
      animator.SetBool("Jumping", isJumping);
  	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}
