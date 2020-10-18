using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour {
    public float horizontalSpeed;
    public GameObject controller;
    public GameController controllerScript;
    public Rigidbody2D rb = new Rigidbody2D();

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        controller = GameObject.FindGameObjectWithTag("GameController");
        controllerScript = controller.GetComponent<GameController>();

    }
	
	// Update is called once per frame
	void Update () {

        horizontalSpeed = controllerScript.pipeSpeed;

        rb.velocity = new Vector2(horizontalSpeed, 0);

        if (rb.position.x < -20.0f)
            Destroy(gameObject);

    }
}
