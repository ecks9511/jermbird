using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


    public int flySpeed;
    public Rigidbody2D rb;
    public AudioSource playerSounds;
    public GameObject soundController;
    public AudioController audioScript;
    public AudioClip fly, chime, death;
    public int score;
    float turnSpeed;
    public bool dead;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSounds = GetComponent<AudioSource>();
        soundController = GameObject.FindGameObjectWithTag("SoundController");
        audioScript = soundController.GetComponent<AudioController>();
        turnSpeed = 2.0f;
        score = 0;
        dead = false;

    }

	
	// Update is called once per frame
	void Update ()
    {
        //Check to see if character wants to jump
        characterJumping();

        //Check if character flew off screen
        checkIfDead();

        //Check how much of an angle the bird's sprite has
        updateSpriteRotation();
    }

    //Collision with various objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block" && !dead)
        {
            killCharacter();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal" && !dead)
        {
            if (audioScript.soundEffectsOn)
            {
                playerSounds.PlayOneShot(chime, 0.1f);
            }
            score++;
        }
    }
    private void updateSpriteRotation()
    {

            //If the character is moving down
            if (rb.velocity.y < 0)
            //Rotate character downwards
                rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0, 0, -45), turnSpeed * Time.deltaTime);
            else 
            //Rotate character upwards
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.Euler(0, 0, 45), turnSpeed * Time.deltaTime);

    }

    private void characterJumping()
    {
        if (Input.GetMouseButtonDown(0) && !dead)
        {
            if (audioScript.soundEffectsOn)
            {
                Debug.Log("Jump");
                playerSounds.PlayOneShot(fly, 0.1f);
            }
            rb.velocity = new Vector2(rb.velocity.x, flySpeed);
        }
    }

    private void checkIfDead()
    {
        //Fell bellow level, reset
        if ((rb.gameObject.transform.position.y < -8 || rb.gameObject.transform.position.y > 8) && dead == false)
        {
            killCharacter();
        }
    }

    private void killCharacter()
    {
        Debug.Log("Died");
        dead = true;
        if (audioScript.soundEffectsOn)
        {
            playerSounds.PlayOneShot(death, 0.1f);
        }
    }


}
