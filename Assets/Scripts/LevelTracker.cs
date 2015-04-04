using UnityEngine;
using System.Collections;

public class LevelTracker : MonoBehaviour {

	public int level;
	public bool twoPlayers;
	//Keeps track of levels
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
}
