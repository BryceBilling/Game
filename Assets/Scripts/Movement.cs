using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(new Vector3(-speed,0,0)*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(new Vector3(0,speed,0)*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(new Vector3(0,-speed,0)*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(new Vector3(speed,0,0)*Time.deltaTime);
		}
	}
}
