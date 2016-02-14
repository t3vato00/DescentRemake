using UnityEngine;
using System.Collections;

public class KamikazeEnemy : MonoBehaviour {

	public float spottingDistance = 50;
	private GameObject nearestPlayer;
	private GameObject[] players;

	private float nearestPlayerDistance = 99999;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject player in players) {
			if(Vector3.Distance(this.transform.position, player.transform.position) < nearestPlayerDistance) {
				nearestPlayerDistance = Vector3.Distance (this.transform.position, player.transform.position);
				nearestPlayer = player;
			}
		}
	}

	void FixedUpdate() {
		if (nearestPlayerDistance < spottingDistance) {
			transform.LookAt (nearestPlayer.transform);
			GetComponent<Rigidbody> ().AddForce (transform.forward * 10);
		}
	}
}
