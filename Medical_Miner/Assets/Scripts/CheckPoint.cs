using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
  private GameMaster gm;
  private Player_Checkpoint pc;
  private int checkPointScore = 0;

  void Start (){
    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Checkpoint>();
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player")){
      gm.lastCheckPointPos = transform.position;
      if(checkPointScore == 0){
        checkPointScore = pc.localScore;
      }
    }
  }
}
