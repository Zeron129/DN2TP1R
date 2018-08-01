using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collidable : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		switch ( col.tag ){  
		case "Death":  
			FindObjectOfType<LevelManager> ().Respawn ();  
			break;  
		case "Checkpoint":  
			FindObjectOfType<LevelManager> ().ResetCheckpoint (col);  
			break;
		case "Goal":  
			GetComponent<Animator> ().Play ("WIN00", -1, 0f);
			FindObjectOfType<AudioManager> ().Play ("Victory_Voice");
			Invoke ("NextLevelDeleay", 2f);
			break;
		default:  
			break; 
		}  
	}

	void NextLevelDeleay(){
		FindObjectOfType<GameManager>().NextLevel();
	}
}
