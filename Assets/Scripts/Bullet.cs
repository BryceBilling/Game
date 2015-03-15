using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Die", 1.5f);
	}
	
	// Update is called once per frame
	void Die () {
		Destroy (gameObject);
	}
}
