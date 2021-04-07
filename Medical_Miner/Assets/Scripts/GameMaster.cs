using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
  [SerializeField]
  public int differentRoomsPerLevel = 6;

  private static GameMaster instance;
  public Vector2 lastCheckPointPos;
  public int score;
  public int roomsVisited = 1;
  public int currentLevel = 1;

  void Awake(){
    if (instance == null){
      instance = this;
      DontDestroyOnLoad(instance);
    } else{
      Destroy(gameObject);
    }
  }
}
