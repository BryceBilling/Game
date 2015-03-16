using UnityEngine;
using System.Collections;

public class Ripple : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Die",0.01f);
	}
	
	// Update is called once per frame
	void Die () {
		Destroy (gameObject);
	}
}
