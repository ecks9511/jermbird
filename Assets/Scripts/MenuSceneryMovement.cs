using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneryMovement : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start()
    {
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0));

        if (this.transform.position.x < -20.0f)
        {
            Object.Destroy(this.gameObject);
        }
    }

}
