using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
  private Player_Checkpoint pc;

  [SerializeField]
  private int value;

  [SerializeField]
  private float itemDestryDelay;

  void Start (){
    pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Checkpoint>();
  }

  void OnTriggerEnter2D(Collider2D other){
    // increases global score by its value and destroys its gameObject after 0.3 sec
    if(other.CompareTag("Player")){
      pc.localScore += value;
      Destroy(gameObject, itemDestryDelay);
    }
  }
}
