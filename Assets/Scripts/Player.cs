using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public Rigidbody2D bullet;
	public float bulletSpeed;
	public float fireRate;
	public float coolDown;
	public GameObject explosion;
	public float health;
	public GameObject bulletCollision;
	Animator anim;

	public enum PlayerType{
		player1=0,
		player2=1,
	};
	public PlayerType playerType;
	// Use this for initialization
	void Start () {
		health = 100;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update(){
		if(health<=0){
			Explode();
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
				rigidbody2D.AddForce (transform.up * -speed / 2);//Because moving backwards is slower than forwards

			}
			if (Input.GetKey (KeyCode.Space)) {
				if (Time.time >= coolDown) {
					Shoot ();
				}
			}
		}
		else {
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

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name.Equals("Enemy Bullet(Clone)")){
			Bullet BulletScript =collider.gameObject.GetComponent("Bullet") as Bullet;//So can access the 
			health-=BulletScript.damage;
			Instantiate (bulletCollision,collider.gameObject.transform.position,collider.gameObject.transform.rotation);
			Destroy (collider.gameObject);
			if(health<=0){
				Destroy (gameObject);
				Explode ();
			}
		}
		if(collider.name.Equals("X")){
			Application.LoadLevel("WinLevel");
		}
	}
	
	void Shoot(){
		Rigidbody2D bulletFired = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody2D;		
		bulletFired.rigidbody2D.AddForce (transform.up*bulletSpeed);
		coolDown = Time.time + fireRate;
	}
	
	void Explode(){
		Instantiate (explosion, transform.position, transform.rotation);

	}
}
