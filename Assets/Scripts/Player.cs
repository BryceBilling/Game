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
	public float maxHealth;
	Animator anim;
	public bool powerUp;
	int count=0;
	public GameObject helpImage;
	bool pause = false;

	public enum PlayerType{
		player1=0,
		player2=1,
	};
	public PlayerType playerType;
	// Use this for initialization
	void Start () {
		helpImage=GameObject.Find("Canvas");
		health = maxHealth;
		anim = GetComponent<Animator> ();
		helpImage.SetActive (false);

	}
	
	// Update is called once per frame
	void Update(){
		if(health<=0){
			Explode();
		}
		if(powerUp){//Activates powerup for a specific time
			count++;
			if(count >240){
				powerUp=false;
				count=0;
			}
		}
		if (Input.GetKey (KeyCode.H)) {//Loads the help screen
			Time.timeScale=0;//Stops movement of objects
			pause = true;
			helpImage.SetActive (pause);
		} else if (Input.GetKey (KeyCode.Escape)) {
			helpImage.SetActive (false);
			Time.timeScale=1;
			
		} else if(!pause){
			helpImage.SetActive (false);
			Time.timeScale=1;
		}

	}

	void FixedUpdate () {//Has basic movement for both player 1 and player 2
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
				if (powerUp==false && Time.time >= coolDown) {//So fired with intervals
					Shoot ();
				}else if(powerUp){//PowerUp is rapid fire
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
				if (powerUp==false && Time.time >= coolDown) {//So fired with intervals
					Shoot ();
				}else if(powerUp){//PowerUp is rapid fire
					Shoot ();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name.Equals("Enemy Bullet(Clone)")){//Checks for collision with bullet from enemy
			Bullet BulletScript =collider.gameObject.GetComponent("Bullet") as Bullet;//So can access the bullet
			health-=BulletScript.damage;
			Instantiate (bulletCollision,collider.gameObject.transform.position,collider.gameObject.transform.rotation);//Generates bullet
			Destroy (collider.gameObject);
			if(health<=0){
				Destroy (gameObject);
				Explode ();
			}
		}
		if(collider.name.Equals("X")){//Check for winning condition
			Application.LoadLevel("WinLevel");
		}
		if(collider.name.Equals("HealthPack")){//Checks for health increase
			health+=30;
			if(health>100){
				health=100;
			}
			Destroy(collider.gameObject);
		}

		if(collider.name.Equals("skull")){//Checks for collision with power up

			Destroy(collider.gameObject);
			powerUp=true;
		}
	}
	
	void Shoot(){//Shooting algorithm
		Rigidbody2D bulletFired = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody2D;//So bullet can be accessed	
		bulletFired.rigidbody2D.AddForce (transform.up*bulletSpeed);
		coolDown = Time.time + fireRate;
		gameObject.audio.Play();
	}
	
	void Explode(){
		Instantiate (explosion, transform.position, transform.rotation);

	}
}
