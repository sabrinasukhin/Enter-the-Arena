using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject player;
	public float speed;
	private Vector3 velocity;
    private Vector3 gravity = new Vector3(0f,0.001f,0f);
	// Use this for initialization
	void Start () {
		velocity = new Vector3(speed,1f,0f);
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
		velocity -= gravity;
        gameObject.transform.position += velocity;
	}
}
