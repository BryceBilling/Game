using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public float length;
	public int count;
	// Use this for initialization
	void Start () {
		gameObject.audio.Play ();//Plays explosion sound
		gameObject.audio.time = 2;
	}

	void Update(){
		Invoke ("Die",length);
	}

	void Die () {//Destroys explosion
		if (!gameObject.audio.isPlaying) {
			Destroy (gameObject);
		}
	}


}
