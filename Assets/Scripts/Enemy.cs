using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	public float driftSpeed;
	public Transform player;
	public Transform player2;
	Transform chasePlayer;
	public Rigidbody2D bullet;
	public float bulletSpeed;
	public float fireRate;
	public float coolDown;
	public GameObject explosion;
	public float health;
	public GameObject bulletCollision;
	public bool chase;
	public float distance;
	public int rotationSpeed;
	// Use this for initialization
	void Start () {
		Invoke("ChangeDirection",rotationSpeed);
	}
	//Updates once per second
	void Update(){
		if (player2 != null && player != null) {//Checks if the players exist if so chooses the closest player to follow
			if (Vector3.Distance (transform.position, player.position) < Vector3.Distance (transform.position, player2.position)) {
				chasePlayer = player;
			} else {
				chasePlayer = player2;
			}
		} else if (player2 == null) {
			chasePlayer = player;
		} else if (player == null) {
			chasePlayer = player2;
		} else {
			chasePlayer=player;
		}
		if(player==null && player2==null){//Game Over
			Application.LoadLevel("SplashScreen");

		}
		if (Time.time >= coolDown && chase == true) {//So that there is a gap between shooting
			Shoot ();
		}

		if (chasePlayer!=null && Vector3.Distance (transform.position, chasePlayer.position) < distance) {//Determines if player is close enough to shoot
			chase=true;

		} else {//Just move randomly
			Move();
			chase=false;
		}

	}

	void ChangeDirection() {//Change the direction of movement when collision
		if(Random.value > 0.5f)  {
			rotationSpeed = -rotationSpeed;
		}
		Invoke("ChangeDirection",rotationSpeed);
	}

	void Move(){//Moves enemy randonly while not chasing player
		transform.Rotate (new Vector3 (0, 0, rotationSpeed * Time.deltaTime));
		transform.position += transform.up*driftSpeed*Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D coll)//Checks for collision so that the enemy flips its direction
	{
		if (coll.gameObject.name == "Island" || coll.gameObject.name=="Big Island" || coll.gameObject.name=="TropicalIsland"|| coll.gameObject.name=="Background")
		{
			transform.Rotate(new Vector3(0,0,180));
		}
	}

	void FixedUpdate () {
		if (chasePlayer != null && chase && Vector3.Distance (transform.position, chasePlayer.position) > 0.5) {//Chasing algorithm that just follows the player
			float direction = Mathf.Atan2 ((chasePlayer.transform.position.y - transform.position.y), (chasePlayer.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0, 0, direction);
			rigidbody2D.AddForce (gameObject.transform.up * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){//Checks for collision with the players bullet
		if(collider.name.Equals("Player Bullet(Clone)")){
			Bullet BulletScript =collider.gameObject.GetComponent("Bullet") as Bullet;
			health-=BulletScript.damage;
			Instantiate (bulletCollision,collider.gameObject.transform.position,collider.gameObject.transform.rotation);
			Destroy (collider.gameObject);
			if(health<=0){
				Destroy (gameObject);
				Explode ();
			}
		}

	}

	void Shoot(){//Fires the bullet
		Rigidbody2D bulletFired = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody2D;//So bullet can be accessed	
		bulletFired.rigidbody2D.AddForce (transform.up*bulletSpeed);
		coolDown = Time.time + fireRate;
		gameObject.audio.Play ();
	}

	void Explode(){//Blows up enemy
		Instantiate (explosion,transform.position,transform.rotation);

	}
}
