using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Die",1.8f);
	}
	
	// Update is called once per frame
	void Die () {
		Destroy (gameObject);
	}
}
