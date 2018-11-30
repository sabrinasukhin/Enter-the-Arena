using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour {

	public GameObject projectile

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Probably don't have to handle that here
		//Let Ricky deal with it LUL
	}

	void OnTriggerEnter(Collider collision) {
		if(collision.CompareTag("Offense")) {
			//Explode
			projectile.velocity = new Vector3(5, 1, 5);
			Instantiate(projectile);
			projectile.velocity = new Vector3(-5, 1, -5);
			Instantiate(projectile);
			projectile.velocity = new Vector3(-5, 1, 5);
			Instantiate(projectile);
			projectile.velocity = new Vector3(5, 1, -5);
			Instantiate(projectile);
		}
	}
}
