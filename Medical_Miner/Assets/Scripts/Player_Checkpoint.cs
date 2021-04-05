using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Checkpoint : MonoBehaviour
{
  private GameMaster gm;

  // score for player
  public int localScore;

  void Start (){
    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    transform.position = gm.lastCheckPointPos;
  }

  void Update(){
    //DEBUGING SCORE TOOLS
        if(Input.GetKeyDown(KeyCode.R)){
          respawn();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
          Debug.Log(localScore);
        }
  }

  public void respawn(){
      // Reloads Scene with existing GameMaster
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      localScore = gm.score;
  }
}
