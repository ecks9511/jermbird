using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Time timer;
    public GameObject[] cloudTypes;
    public GameObject[] hillTypes;
    public GameObject[] blocksObjs;
    public GameObject blockObj;
    public GameObject playerObj;
    public Rigidbody2D playerRb;
    public PlayerController playerScript;
    public GameObject scoreObj;
    public Text scoreText;
    public bool dead;
    private int currentScore;
    public Vector2 playerPos;
    private bool canCreateClouds, canCreateHills;
    private float randomTimeClouds, randomYClouds, randomTimeHills, randomYHills;
    public float pipeSpeed, scenerySpeed;
    private int numTotalBlocks = 6;
    private int[,] possibleLocations = new int[,] { { 15, -4 }, { 14, -5 }, { 13, -6 }, { 12, -7 }, { 11, -8 }, { 10, -9 }, { 9, -10 }, { 8, -11 }, { 7, -12 }, { 6, -13 } };
    private int firstBlockPos, secondBlockPos = 0;
    private int randomIndex;

    // Use this for initialization
    void Start()
    {
        //Create the original few blocks
        for(int i = 0; i < numTotalBlocks/2; i++)
        {
            //Make "random" coords for possible block locations
            randomIndex = Random.Range(0, 10);
            firstBlockPos = possibleLocations[randomIndex, 0];
            secondBlockPos = possibleLocations[randomIndex, 1];

            //Making a pair of blocks
            Instantiate(blockObj, new Vector2((i * 15)+5, firstBlockPos), Quaternion.Euler(0, 0, 90));
            Instantiate(blockObj, new Vector2((i * 15)+5, secondBlockPos), Quaternion.Euler(0, 0, 90));
        }

        //Get access to player and its rigid body components
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerRb = playerObj.GetComponent<Rigidbody2D>();
        playerScript = playerObj.GetComponent<PlayerController>();

        //Get UI components
        scoreObj = GameObject.FindGameObjectWithTag("Score");

        //Scenery components
        canCreateClouds = true;
        canCreateHills = true;

        //Set initial pipe speed
        pipeSpeed = -3.0f;
        scenerySpeed = 0.003f;

        //Character not dead yet
        dead = false;

        

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Get amount of blocks currently on the screen
        blocksObjs = GameObject.FindGameObjectsWithTag("Block");

        //Make more block sets if there aren't enough
        updateBlocks();

        //Create clouds in the background
        if (canCreateClouds == true && playerScript.dead == false)
            StartCoroutine(createClouds());

        //Create hills in the background
        if (canCreateHills == true && playerScript.dead == false)
            StartCoroutine(createHills());

    }

    private void Update()
    {
        //Update score
        currentScore = playerScript.score;
        scoreText.text = currentScore.ToString();

        //Check score and do various things
        checkScore();

        //Check if the player died
        checkCharacterStatus();
    }

    void updateBlocks()
    {
        //Create blocks if there aren't enough still alive
        if (blocksObjs.Length  < numTotalBlocks)
        {
            //Make "random" coords for possible block locations
            randomIndex = Random.Range(0, 10);
            firstBlockPos = possibleLocations[randomIndex,0];
            secondBlockPos = possibleLocations[randomIndex, 1];

            //Making a pair of blocks
            Instantiate(blockObj, new Vector2(25, firstBlockPos), Quaternion.Euler(0, 0, 90));
            Instantiate(blockObj, new Vector2(25, secondBlockPos), Quaternion.Euler(0, 0, 90));
        }
    }

    IEnumerator createClouds()
    {

            //Pick a random cloud
            randomTimeClouds = Random.Range(3.0f, 5.0f);
            canCreateClouds = false;
            yield return new WaitForSeconds(randomTimeClouds);
            GameObject cloud = cloudTypes[Random.Range(0, 3)];
            randomYClouds = Random.Range(-1.0f, 7.0f);
            Instantiate(cloud, new Vector2(25, randomYClouds), Quaternion.Euler(0, 0, 0));
            canCreateClouds = true;
    }

    IEnumerator createHills()
    {
        //Pick a random hill
        randomTimeHills = Random.Range(4.0f, 8.0f);
        canCreateHills = false;
        yield return new WaitForSeconds(randomTimeHills);
        GameObject hill = hillTypes[Random.Range(0, 4)];
        randomYHills = Random.Range(-3f, -2f);
        Instantiate(hill, new Vector2(35, randomYHills), Quaternion.Euler(0, 0, 0));
        canCreateHills = true;


    }

    void checkScore()
    {
        if (currentScore >= 5 && currentScore < 10)
        {
            pipeSpeed = -4f;
            scenerySpeed = 0.004f;
        }
        else if (currentScore >= 10 && currentScore < 15)
        {
            pipeSpeed = -5f;
            scenerySpeed = 0.005f;
        }
        else if (currentScore >= 15 && currentScore < 20)
        {
            pipeSpeed = -6f;
            scenerySpeed = 0.006f;
        }
        else if (currentScore >= 20 && currentScore < 25)
        {
            pipeSpeed = -7f;
            scenerySpeed = 0.007f;
        }
    }

    void checkCharacterStatus ()
    {
        if (playerScript.dead == true)
        {
            canCreateClouds = false;
            canCreateHills = false;
            pipeSpeed = 0.0f;
            scenerySpeed = 0.0f;

        }
    }
}
