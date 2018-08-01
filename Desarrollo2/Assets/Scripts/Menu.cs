using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	void Awake(){
		FindObjectOfType<AudioManager> ().PlayMusic ();
	}

	public void PlayGame (){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void ExitGame (){
		Debug.Log ("Quit");
		Application.Quit ();
	}
	public void ToMenu (){
		SceneManager.LoadScene (0);
		FindObjectOfType<GameManager> ().InMenu ();
	}
}
