using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartMenu : MonoBehaviour {

    public GameObject startButton, optionsButton, creditsButton, exitButton, musicButton, soundButton, backButton1, backButton2, creditBox;
    public bool musicOn, soundOn;
    public AudioController audioScript;
    public Vector2 backOriginalLocation;

    // Use this for initialization
    void Start() {
        backOriginalLocation = backButton1.transform.position;
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnClick(string messageName)
    {
        if (messageName == "Game")
        {
            Debug.Log("Start clicked");
            SceneManager.LoadScene("Game");
        }
        else if (messageName == "Back1")
        {
            Debug.Log("Back1 clicked");
            startButton.SetActive(true);
            optionsButton.SetActive(true);
            creditsButton.SetActive(true);
            exitButton.SetActive(true);
            musicButton.SetActive(false);
            soundButton.SetActive(false);
            backButton1.SetActive(false);
            creditBox.SetActive(false);
            backButton1.transform.position = backOriginalLocation;
        }
        else if (messageName == "Back2")
        {
            Debug.Log("Back1 clicked");
            startButton.SetActive(true);
            optionsButton.SetActive(true);
            creditsButton.SetActive(true);
            exitButton.SetActive(true);
            backButton1.SetActive(true);
            backButton2.SetActive(false);
            creditBox.SetActive(false);
        }
        else if (messageName == "Options")
        {
            Debug.Log("Options clicked");
            startButton.SetActive(false);
            optionsButton.SetActive(false);
            creditsButton.SetActive(false);
            exitButton.SetActive(false);
            musicButton.SetActive(true);
            soundButton.SetActive(true);
            backButton1.SetActive(true);

        }
        else if (messageName == "Credits")
        {
            startButton.SetActive(false);
            optionsButton.SetActive(false);
            creditsButton.SetActive(false);
            exitButton.SetActive(false);
            musicButton.SetActive(false);
            soundButton.SetActive(false);
            backButton1.SetActive(false);
            backButton2.SetActive(true);
            creditBox.SetActive(true);


        }

        else if (messageName == "Sound")
        {
            //Sound on or off
            if(audioScript.soundEffectsOn == true)
            {
                soundButton.GetComponentInChildren<Text>().text = "Sound Effects: Off";
                audioScript.soundEffectsOn = false;
                //Turn off sound
            }
            else
            {
                soundButton.GetComponentInChildren<Text>().text = "Sound Effects: On";
                audioScript.soundEffectsOn = true;
            }

        }
        else if (messageName == "Music")
        {
            //Music on or off
            if (audioScript.musicOn == true)
            {
                musicButton.GetComponentInChildren<Text>().text = "Music: Off";
                audioScript.musicOn = false;
                //Turn off sound
            }
            else
            {
                musicButton.GetComponentInChildren<Text>().text = "Music: On";
                audioScript.musicOn = true;
            }
        }
        else if (messageName == "Exit")
        {
            Application.Quit();
        }
    }

    public void OnGUI()
    {
    }

}
