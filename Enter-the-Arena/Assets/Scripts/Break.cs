using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {
	private Rigidbody sword;
	private GameObject player; //Not applied yet, look at Start for more info
	private Camera fbcam;
	public float threshold = 3f;
	private bool broken = false;
	private float timer = 0;
	private Renderer rend;
	private Vector3 og;

	// Use this for initialization
	void Start() {
		//Add something in here later on that prevents the sword from hurting the person holding it
		//Physics.IgnoreCollision(sword.GetComponent<Collider>(), Player.instance.headCollider );
		fbcam = Camera.main;
		sword = GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();
		og = gameObject.transform.position;
	}
	
	void Update() {
		if(broken) {
			timer -= Time.deltaTime;
			if(timer <= 0) {
				broken = false;
				timer = 0;
				gameObject.transform.localScale = og;
				rend.enabled = true;
			}
		}
		//Mode changing
		if(!broken) {
			fbcam = Camera.main;
			float distance = Vector3.Distance(gameObject.transform.position, fbcam.gameObject.transform.position);
			if(distance > threshold) {
				gameObject.tag = "Offense";
			}
			else if(distance <= threshold) {
				gameObject.tag = "Defense";
			}
		}
	}

	void OnTriggerEnter(Collider collision) {
		if(gameObject.CompareTag("Offense")) {
			if(collision.gameObject.CompareTag("Defense")) {
				Breaker(gameObject);
			}
			else {
				Breaker(collision.gameObject);
			}
		}
	}

	void Breaker(GameObject o) {
		o.transform.localScale = new Vector3(0, 0, 0);
		broken = true;
		timer = 3;
		rend.enabled = false;
	}
}
