using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public Rigidbody2D bullet;
	public float bulletSpeed;
	public float fireRate;
	public float coolDown;
	public Animation explosion;
	public float health;
	public float bulletLife;
	public enum PlayerType{
		player1=0,
		player2=1,
	};
	public PlayerType playerType;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		if(health<=0){
			Expode();
		}

	}

	void FixedUpdate () {
		if (playerType == PlayerType.player1) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (Vector3.forward * rotationSpeed, rotationSpeed);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (Vector3.back * rotationSpeed, rotationSpeed);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				rigidbody2D.AddForce (transform.up * speed);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				rigidbody2D.AddForce (transform.up * -speed/2);//Because moving backwards is slower than forwards
				;
			}
			if (Input.GetKey (KeyCode.Space)) {
				if (Time.time >= coolDown) {
					Shoot ();
				}
			}
		} else {
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
				rigidbody2D.AddForce(transform.up*-speed/2);//Because moving backwards is slower than forwards
			}
			if (Input.GetKey (KeyCode.LeftShift)) {
				if (Time.time >= coolDown) {
					Shoot ();
				}
			}
		}
	}


	
	void Shoot(){
		Rigidbody2D bulletFired = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody2D;		
		bulletFired.rigidbody2D.AddForce (transform.up*bulletSpeed);
		coolDown = Time.time + fireRate;
	}
	
	void Expode(){

	}
}
