using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

	private GameObject player;
	public float speed;
	public float attackThreshold;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float kingx = gameObject.transform.position.x;
		float kingy = gameObject.transform.position.y;
		float playerx = player.gameObject.transform.position.x;
		float playery = player.gameObject.transform.position.y;
		Vector2 k = new Vector2(kingx, kingy);
		Vector2 p = new Vector2(playerx, playery);
		float distance = Vector2.Distance(k, p);
		if(distance <= attackThreshold) {
			Attack(p);
		}
		else {
			Move(k, p);
		}
	}

	void Attack(float target) {
		
	}

	void Move(float current, float target) {
		Vector2 newXY = Vector2.MoveTowards(current, target, speed * Time.deltaTime);
		gameObject.transform.position.x = newXY.x;
		gameObject.transform.position.y = newXY.y;
	}
}
