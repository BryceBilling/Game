using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	public Transform player;
	public Rigidbody2D bullet;
	public float bulletSpeed;
	public float fireRate;
	public float coolDown;
	public GameObject explosion;
	public float health;
	public GameObject bulletCollision;
	// Use this for initialization
	void Start () {
	
	}
	void Update(){
		if(player==null){//Game Over
		}
		if (Time.time >= coolDown) {
			Shoot ();
		}


	}
	// Update is called once per frame
	void FixedUpdate () {
		if (player != null) {
			float direction = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0, 0, direction);
			rigidbody2D.AddForce (gameObject.transform.up * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D bullet){
		Debug.Log (health);
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
