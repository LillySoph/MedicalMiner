using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKillsPlayer : MonoBehaviour
{

    [SerializeField] Transform checkpoint;
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {

            col.transform.position = gm.lastCheckPointPos;
            //col.transform.position = checkpoint.position;
        }

    }
}
