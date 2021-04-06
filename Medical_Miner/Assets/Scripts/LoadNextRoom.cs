using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextRoom : MonoBehaviour
{
    // [SerializeField]
    private int roomAmountPerLevel = 10;

    [SerializeField]
    private int firstRoomOfLevelIndex = 1;

    [SerializeField]
    private int endscreenOfLevelIndex = 6;
    
    private GameMaster gameMaster;
    private int roomIndexOfBefore;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int roomsVisited = gameMaster.roomsVisited;
        // load next room in same level
        if (roomsVisited < roomAmountPerLevel) {
            int index = getIndexOfNextRoom();
            SceneManager.LoadScene(index);
            Debug.Log("Room Index: " + index + " | " + roomsVisited + "/" + roomAmountPerLevel);
            gameMaster.roomsVisited++;
        } 
        // load endscreen of level
        else {
            SceneManager.LoadScene(endscreenOfLevelIndex); 
            // reset room visited counter
            gameMaster.roomsVisited = 0;
        }
        
    }

    int getIndexOfNextRoom() 
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int next;
        // int before = roomIndexOfBefore
        do {
            next = Random.Range(firstRoomOfLevelIndex + 2, firstRoomOfLevelIndex + 5);
        } while (next == current);

        return next;
    }
}