using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{

	public GameObject retryButton, exitButton, background;
	public PlayerController playerScript;
	public GameObject soundController;
	public AudioController audioScript;

	// Use this for initialization
	void Start()
	{ 
		retryButton.SetActive(false);
		exitButton.SetActive(false);
		background.SetActive(false);
		soundController = GameObject.FindGameObjectWithTag("SoundController");
		audioScript = soundController.GetComponent<AudioController>();
	}

	// Update is called once per frame
	void Update()
	{
		if(playerScript.dead == true)
        {
			Debug.Log("hit");
			retryButton.SetActive(true);
			exitButton.SetActive(true);
			background.SetActive(true);
		}
	}
	public void OnClick(string messageName)
	{
		if (messageName == "Retry")
		{
			SceneManager.LoadScene("Game");
		}
		else if (messageName == "Exit")
		{
			Destroy(soundController);
			Destroy(audioScript);
			SceneManager.LoadScene("Menu");
		}
	}
};
