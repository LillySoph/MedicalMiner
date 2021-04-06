using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
  private GameMaster gm;

  [SerializeField]
  private int value;

  [SerializeField]
  private float itemDestryDelay;

  void Start (){
    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
  }

  void OnTriggerEnter2D(Collider2D other){
    // increases global score by its value and destroys its gameObject after "itemDestryDelay" sec
    if(other.CompareTag("Player")){
      gm.score += value;
      Destroy(gameObject, itemDestryDelay);
    }
  }
}
