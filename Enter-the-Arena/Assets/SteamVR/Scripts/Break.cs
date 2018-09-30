using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {
	public Rigidbody sword;

	// Use this for initialization
	void Start () {
		//Add something in here later on that prevents the sword from hurting the person holding it
		//Physics.IgnoreCollision(sword.GetComponent<Collider>(), Player.instance.headCollider );
	}
	
	void FixedUpdate () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.CompareTag("Defense")) {
			Destroy(gameObject);
		}
		else {
			Destroy(collision.gameObject);
		}
	}
}
