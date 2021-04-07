using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endscreen : MonoBehaviour
{

    void Update()
    {
      if (Input.GetKey(KeyCode.Space)){
          Debug.Log("QUIT LUL");
          Application.Quit();
        }
    }
}
