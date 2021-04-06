using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextRoom : MonoBehaviour
{
    [SerializeField]
    private int roomAmountPerLevel = 10;
    
    private int differentRoomsPerLevel;
    
    private int currentLevel;
    private GameMaster gameMaster;
    private int roomIndexOfBefore;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        currentLevel = gameMaster.currentLevel;
        differentRoomsPerLevel = gameMaster.differentRoomsPerLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // get number of rooms visited and current level
        int roomsVisited = gameMaster.roomsVisited;
        

        // load next room in same level, increase room visited count
        if (roomsVisited < roomAmountPerLevel) {
            int index = getIndexOfNextRoom();
            SceneManager.LoadScene(index);
            gameMaster.roomsVisited++;
            Debug.Log("Room Index: " + index + " | " + "Level: " + currentLevel + " | " + roomsVisited + "/" + roomAmountPerLevel);
            
        } 
        // load endscreen of level, reset room count and increase level count
        else {
            int endscreenIndex = 1 + differentRoomsPerLevel + ((currentLevel-1) * (differentRoomsPerLevel+1));
            Debug.Log("Endscreen Index: " + endscreenIndex);
            SceneManager.LoadScene(endscreenIndex); 
            // reset room visited counter
            gameMaster.roomsVisited = 1;
            gameMaster.currentLevel++;
        }
        
    }

    int getIndexOfNextRoom() 
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int next;
        
        int before = roomIndexOfBefore;

        int first = 2 + ((currentLevel-1) * (differentRoomsPerLevel+1));

        do {
            next = Random.Range(first, first + (differentRoomsPerLevel-1));
        } while (next == current);

        return next;
    }
}