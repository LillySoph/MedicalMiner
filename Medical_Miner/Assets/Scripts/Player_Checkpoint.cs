using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Checkpoint : MonoBehaviour
{
  private GameMaster gm;

  void Start (){
    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    transform.position = gm.lastCheckPointPos;
  }
  void Update(){
    if(Input.GetKeyDown(KeyCode.R)){
      // Reloads Scene with existing GameMaster 
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}
