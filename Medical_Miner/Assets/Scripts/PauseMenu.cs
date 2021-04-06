using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

  public static bool GameIsPaused = false;

  public GameObject pauseMenuUI;

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

public void Restart (){
  	//Time.timeScale = 1f;
  	Debug.Log("Restarting (: ");
  }

public void Timer(){
  	Debug.Log("Timer (: ");
  }

public void Filler(){
  	Debug.Log("Filler (: ");
  }

public void QuitGame(){
  	Debug.Log("QUIT LUL");
  	Application.Quit();
  }

}
