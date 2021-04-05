using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKillsPlayer : MonoBehaviour
{

    [SerializeField] Transform checkpoint;
    private GameMaster gm;
    private Player_Checkpoint pc;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Checkpoint>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            // reloads Scene
            // pc.respawn();
            // only transforms position
            col.transform.position = gm.lastCheckPointPos;
            // col.transform.position = checkpoint.position;
        }

    }
}
