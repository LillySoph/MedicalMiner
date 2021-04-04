using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithPlatform : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "movingPlatform")
        {
            transform.parent = other.transform;
          //  Debug.Log("We are on a moving platform");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "movingPlatform")
        {
            transform.parent = null;
        }
    }
}
