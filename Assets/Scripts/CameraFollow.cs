using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public float distance;
	public float yheight;
	public float xheight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) {
			Vector3 pos = new Vector3 (player.position.x, player.position.y, transform.position.z);
			pos.x = Mathf.Clamp (pos.x, -xheight, xheight);
			pos.y = Mathf.Clamp (pos.y, -yheight, yheight);
			transform.position = pos;
		}
	}
}
