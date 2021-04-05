using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
  private static GameMaster instance;
  public Vector2 lastCheckPointPos;
  public int score;

  void Awake(){
    if (instance == null){
      instance = this;
      DontDestroyOnLoad(instance);
    }else{
      Destroy(gameObject);
    }
  }
}
