using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public float length;
	// Use this for initialization
	void Start () {
		Invoke ("Die",length);
	}
	
	// Update is called once per frame
	void Die () {
		Destroy (gameObject);
	}
}
