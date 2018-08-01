using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] int maxLives;
	public static GameManager instance;
	int Lives;

	void Awake () {
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);
		InMenu ();
	}

	public void UpdateTexts(Text currentLives, Text Level){
		currentLives.text = "Lives: " + Lives + "/" + maxLives;
		Level.text = "Level: " + SceneManager.GetActiveScene ().buildIndex;
	}

	public void NextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public bool IsDead(){
		if (Lives > 0) {
			Lives--;
			return false;
		} else {
			GameOver ();
			return true;
		}
	}
		
	void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}

	public void InMenu(){
		Lives = maxLives;
	}


	public int GetLives(){
		return Lives;
	}


}
