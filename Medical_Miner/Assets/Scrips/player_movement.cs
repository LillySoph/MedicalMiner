using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
  public float speed = 5.0f;
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

      //Jump & ForceDown not yet implemented
  		if (Input.GetKey(KeyCode.Space )|| Input.GetKey(KeyCode.W)){
        //Jump
        //if (isOnGround){ addForce.up}
  			transform.position += Vector3.up * speed * Time.deltaTime;
  		}
      if (Input.GetKey(KeyCode.S)){
        //forceDown while Jumping addForce.down
  			transform.position += Vector3.down * speed * Time.deltaTime;
  		}
  	}
}
