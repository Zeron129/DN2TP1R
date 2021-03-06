﻿using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;
	public static AudioManager instance;

	void Awake () {
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) {
			
			s.source = gameObject.AddComponent<AudioSource> ();

			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void PlayMusic(){
		
		switch (SceneManager.GetActiveScene ().buildIndex) {  
		case 0:
			Debug.Log ("Playng: " + "Menu_Music");
			Play ("Menu_Music");  
			Stop ("Lvl1_Music");  
			Stop ("Lvl2_Music");  
			Stop ("Victory_Music");  
			Stop ("GameOver_Music");  
			break;  
		case 1: 
			Debug.Log ("Playng: " + "Lvl1_Music");
			Stop ("Menu_Music");  
			Play ("Lvl1_Music");  
			Stop ("Lvl2_Music");  
			Stop ("Victory_Music");  
			Stop ("GameOver_Music");
			break;   
		case 2:  
			Debug.Log ("Playng: " + "Lvl2_Music");
			Stop ("Menu_Music");  
			Stop ("Lvl1_Music");  
			Play ("Lvl2_Music");  
			Stop ("Victory_Music");  
			Stop ("GameOver_Music");
			break;   
		case 3:  
			Debug.Log ("Playng: " + "Victory_Music");
			Stop ("Menu_Music");  
			Stop ("Lvl1_Music");  
			Stop ("Lvl2_Music");  
			Play ("Victory_Music");  
			Stop ("GameOver_Music");
			break;   
		case 4:  
			Debug.Log ("Playng: " + "GameOver_Music");
			Stop ("Menu_Music");  
			Stop ("Lvl1_Music");  
			Stop ("Lvl2_Music");  
			Stop ("Victory_Music");  
			Play ("GameOver_Music");
			break; 
		default:
			break;
		}  
	}

	public void Play (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.Log ("Sound: " + name + "not found!");
			return;
		}
		s.source.Play();
	}

	public void PlayDelayed (string name, ulong delay) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.Log ("Sound: " + name + "not found!");
			return;
		}
		s.source.PlayDelayed(delay);
	}

	public void Stop (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.Log ("Sound: " + name + "not found!");
			return;
		}
		s.source.Stop();
	}
}
	 