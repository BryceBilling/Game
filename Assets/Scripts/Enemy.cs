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
	void Update(){
		if (player2 != null && player != null) {
			if (Vector3.Distance (transform.position, player.position) < Vector3.Distance (transform.position, player2.position)) {
				chasePlayer = player;
			} else {
				chasePlayer = player2;
			}
		} else {
			chasePlayer=player;
		}
		if(player==null && player2==null){//Game Over
			Debug.Log("Game Over");
			Application.LoadLevel("SplashScreen");
		}
		if (Time.time >= coolDown && chase==true) {
			Shoot ();
		}

		if (chasePlayer!=null && Vector3.Distance (transform.position, chasePlayer.position) < distance) {
			chase=true;

		} else {
			Move();
			chase=false;
		}

	}

	void ChangeDirection() {
		if(Random.value > 0.5f)  {
			rotationSpeed = -rotationSpeed;
		}
		Invoke("ChangeDirection",rotationSpeed);
	}

	void Move(){
		transform.Rotate (new Vector3 (0, 0, rotationSpeed * Time.deltaTime));
		transform.position += transform.up*driftSpeed*Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name == "Island" || coll.gameObject.name=="Big Island" || coll.gameObject.name=="TropicalIsland")
		{
			transform.Rotate(new Vector3(0,0,180));
		}
	}

	void FixedUpdate () {
		if (chasePlayer != null && chase && Vector3.Distance (transform.position, chasePlayer.position) > 0.5) {
			float direction = Mathf.Atan2 ((chasePlayer.transform.position.y - transform.position.y), (chasePlayer.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0, 0, direction);
			rigidbody2D.AddForce (gameObject.transform.up * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
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

	void Shoot(){
		Rigidbody2D bulletFired = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody2D;		
		bulletFired.rigidbody2D.AddForce (transform.up*bulletSpeed);
		coolDown = Time.time + fireRate;
	}
	void Explode(){
		Instantiate (explosion,transform.position,transform.rotation);
	}
}
