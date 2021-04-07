using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

  public static bool GameIsPaused = false;

  public GameObject pauseMenuUI;

  private GameMaster gameMaster;

void Start() {
	gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
}

void Update () {
  	if (Input.GetKeyDown(KeyCode.Escape)){
  		if(GameIsPaused){
  			Resume();
  		}else{
  			Pause();
  		}
  	}
}

public void Resume (){
  	pauseMenuUI.SetActive(false);
  	Time.timeScale = 1f;
  	GameIsPaused = false;
  }


public void Pause (){
  	pauseMenuUI.SetActive(true);
  	Time.timeScale = 0f;
  	GameIsPaused = true;
  }

// return to first room of level
public void Restart (){
  	Debug.Log("Restarting (: :)");
	int index = 1 + ((gameMaster.currentLevel-1) * (gameMaster.differentRoomsPerLevel+1));
	SceneManager.LoadScene(index);
	// reset score to 0
	gameMaster.score = 0;
	Resume();
  }

public void QuitGame(){
  	Debug.Log("QUIT LUL");
  	Application.Quit();
  }

}
