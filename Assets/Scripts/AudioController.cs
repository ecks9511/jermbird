using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public bool soundEffectsOn, musicOn;

	// Use this for initialization
	void Start () {
		soundEffectsOn = true;
		musicOn = true;
	}

	void Awake()
    {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
