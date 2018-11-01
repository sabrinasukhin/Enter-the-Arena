using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject player;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	private void OnTriggerEnter(Collider collision)
    {
    	if(collision.gameObject.name == "Player") {
			GameObject.Find("Player").GetComponent<PlayerConstants>().health -=1;
			Destroy(gameObject);
			GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave -=1;
		}
    }

	void Move() {
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
	}
}
