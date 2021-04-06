using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKillsPlayer : MonoBehaviour
{

    private Player_Checkpoint pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Checkpoint>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            pc.respawn();
        }
    }
}
