using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {
	public Rigidbody sword;
	public GameObject player;
	public Camera fbcam;
	private int threshold = 3;

	// Use this for initialization
	void Start() {
		//Add something in here later on that prevents the sword from hurting the person holding it
		//Physics.IgnoreCollision(sword.GetComponent<Collider>(), Player.instance.headCollider );
		fbcam = Camera.main;
	}
	
	void Update() {
		fbcam = Camera.main;
		float distance = Vector3.Distance(gameObject.transform.position, fbcam.gameObject.transform.position);
		if(gameObject.CompareTag("Defense") && distance > threshold) {
			gameObject.tag = "Offense";
		}
		else if(gameObject.CompareTag("Offense") && distance <= threshold) {
			gameObject.tag = "Defense";
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(gameObject.CompareTag("Offense")) {
			if(collision.gameObject.CompareTag("Defense")) {
				Destroy(gameObject);
			}
			else {
				Destroy(collision.gameObject);
			}
		}
	}
}
