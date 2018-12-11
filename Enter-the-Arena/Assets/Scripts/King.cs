using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class King : MonoBehaviour {

	private GameObject player;
	public float speed;
	public float attackThreshold;

    private Animator _Animator;

	// Use this for initialization
	void Start () {
	    player = GameObject.FindWithTag("Player");
        _Animator = GetComponent<Animator>();
        _Animator.SetBool("UseAltAttack", Random.value <= 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		float kingx = gameObject.transform.position.x;
		float kingz = gameObject.transform.position.z;
		float playerx = player.gameObject.transform.position.x;
		float playerz = player.gameObject.transform.position.z;
		Vector2 k = new Vector2(kingx, kingz);
		Vector2 p = new Vector2(playerx, playerz);
		float distance = Vector2.Distance(k, p);
		if(distance <= attackThreshold) {
			Attack(p);
		}
		else {
			Move(k, p);
		}
	}

	void Attack(Vector2 target) {
        _Animator.SetTrigger("Attack");
	}

	void Move(Vector2 current, Vector2 target) {
		Vector2 newXY = Vector2.MoveTowards(current, target, speed * Time.deltaTime);
		gameObject.transform.position = new Vector3(newXY.x, gameObject.transform.position.y, newXY.y);
	}
}