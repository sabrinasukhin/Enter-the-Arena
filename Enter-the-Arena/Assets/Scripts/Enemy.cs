using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public float speed;
	// Use this for initialization
	void Start() {
	
	}
	
	void Update() {
		Move();
	}

    void OnCollisionEnter(Collision collision) {
        if(collision.GameObject == player) {
            //Kill the fool
        }
    }

    void Move() {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
