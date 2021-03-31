using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
  [SerializeField] // <-- private but still shows up in Unity GUI
  private float speed = 5.0f;
  [SerializeField]
  private float jumpSpeed = 8f;
  [SerializeField]
  private Rigidbody2D rigidBody;
  [SerializeField]
  private BoxCollider2D boxCollider2d;
  [SerializeField]
  private LayerMask groudLayer;

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
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
  			transform.position += Vector3.down * speed * Time.deltaTime;
  		}
      if (Input.GetKey(KeyCode.Space) && isGrounded() && !Input.GetKey(KeyCode.S)){
        //Jump only if on Ground and not ForceDown
        rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
  		}
  	}


}
