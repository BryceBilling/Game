using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float direction = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (0,0,direction);
		rigidbody2D.AddForce (gameObject.transform.up*speed);
	}
}
