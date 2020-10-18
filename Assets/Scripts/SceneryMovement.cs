using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryMovement : MonoBehaviour {

    float speed;
    public GameObject controller;
    public PlayerController controllerScript;

    // Use this for initialization
    void Start () {
        speed = 0.003f;
    }
	
	// Update is called once per frame
	void Update () {

        if (controllerScript.dead)
            speed = 0;


        this.transform.Translate(-speed, 0, 0);

        if (this.transform.position.x < -20.0f)
            Destroy(gameObject);


    }
}
