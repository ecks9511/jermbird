using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScenery : MonoBehaviour
{
    public Time timer;
    public GameObject[] cloudTypes;
    public GameObject[] hillTypes;
    public PlayerController playerScript;
    private bool canCreateClouds, canCreateHills;
    private float randomTimeClouds, randomYClouds, randomTimeHills, randomYHills;
    public float pipeSpeed, scenerySpeed;

    // Use this for initialization
    void Start()
    {
        //Scenery components
        canCreateClouds = true;
        canCreateHills = true;

        //Set scenery speed
        scenerySpeed = 0.005f;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Create clouds in the background
        if (canCreateClouds == true)
            StartCoroutine(createClouds());

        //Create hills in the background
        if (canCreateHills == true)
            StartCoroutine(createHills());

    }

    IEnumerator createClouds()
    {

        //Pick a random cloud
        randomTimeClouds = Random.Range(8.0f, 20.0f);
        canCreateClouds = false;
        yield return new WaitForSeconds(randomTimeClouds);
        GameObject cloud = cloudTypes[Random.Range(0, 3)];
        randomYClouds = Random.Range(1.5f, 8.0f);
        Instantiate(cloud, new Vector2(24.0f, randomYClouds), Quaternion.Euler(0, 0, 0));
        canCreateClouds = true;

    }

    IEnumerator createHills()
    {

        //Pick a random hill
        randomTimeHills = Random.Range(10.0f, 25.0f);
        canCreateHills = false;
        yield return new WaitForSeconds(randomTimeHills);
        GameObject hill = hillTypes[0];
        randomYHills = Random.Range(-10.0f, -7.0f);
        Instantiate(hill, new Vector2(20.0f, randomYHills), Quaternion.Euler(0, 0, 0));
        canCreateHills = true;


    }

}
