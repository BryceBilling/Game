using UnityEngine;
using System.Collections;

public class MovementPlayerTwo : MonoBehaviour {
	
	public float speed;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.forward*rotationSpeed,rotationSpeed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(Vector3.back*rotationSpeed,rotationSpeed);
		}
		if (Input.GetKey(KeyCode.W))
		{
			rigidbody2D.AddForce(transform.up*speed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			rigidbody2D.AddForce(transform.up*-speed);;
		}
		
		
	}
}
