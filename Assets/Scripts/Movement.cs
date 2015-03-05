﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.forward*rotationSpeed,rotationSpeed);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.back*rotationSpeed,rotationSpeed);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			rigidbody2D.AddForce(transform.up*speed);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			rigidbody2D.AddForce(transform.up*-speed);;
		}


	}
}
