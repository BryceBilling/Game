using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Player player;
	public Transform healthBar;
	
	// Update is called once per frame
	void Update () {
		if (player != null) {//Changes the health bar based on the current players health
			float healthPer = player.health / (float)player.maxHealth;
			healthBar.localScale = new Vector3 (healthPer, 1, 1);

		} else {
			healthBar.localScale=new Vector3(0,1,1);

		}

	}
}
