using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	[SerializeField] Collidable player;
	[SerializeField] Text currentLives;
	[SerializeField] Text Level;
	private Vector3 startPos;
	private Quaternion startRot;

	void Awake () {
		startPos = player.transform.position;
		startRot = player.transform.rotation;
		FindObjectOfType<AudioManager> ().PlayMusic ();
	}
	void Update () {
		FindObjectOfType<GameManager> ().UpdateTexts (Level, currentLives);
	}
	public void Respawn(){
		if (!FindObjectOfType<GameManager> ().IsDead ()) {
			player.transform.position = startPos;
			player.transform.rotation = startRot;

			player.GetComponent<Animator> ().Play ("LOSE00", -1, 0f);
			FindObjectOfType<AudioManager> ().PlayDelayed ("Damage_Voice", 1);
			player.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
			player.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0f, 0f, 0f);
		}
	}

	public void ResetCheckpoint(Collider coll){
		startPos = coll.gameObject.transform.position;
		startRot = coll.gameObject.transform.rotation;
		Destroy (coll.gameObject);
	}



}
