using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
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
	// Use this for initialization
	void Start () {
	
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
			chase=false;
		}

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (chasePlayer != null && chase) {
			float direction = Mathf.Atan2 ((chasePlayer.transform.position.y - transform.position.y), (chasePlayer.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0, 0, direction);
			rigidbody2D.AddForce (gameObject.transform.up * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D bullet){
		if(bullet.name.Equals("Player Bullet(Clone)")){
			Bullet BulletScript =bullet.gameObject.GetComponent("Bullet") as Bullet;
			health-=BulletScript.damage;
			Instantiate (bulletCollision,bullet.gameObject.transform.position,bullet.gameObject.transform.rotation);
			Destroy (bullet.gameObject);
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
