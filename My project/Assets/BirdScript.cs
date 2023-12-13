using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private bool levelStart;
    public GameObject tap;
    public GameObject pipeSpawner;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        levelStart = false;
        myRigidbody.gravityScale = 0;
        tap.GetComponent<SpriteRenderer>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive )
        {
            if (levelStart == false)
            {
                levelStart = true;
                myRigidbody.gravityScale = 5;
                pipeSpawner.GetComponent<PipeSpawnScript>().enableGeneratePipe = true;
            }
            myRigidbody.velocity = Vector2.up * flapStrength;
            tap.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
    
}
