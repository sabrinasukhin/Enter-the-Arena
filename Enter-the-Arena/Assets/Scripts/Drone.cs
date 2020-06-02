using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

	public GameObject projectile;
	public float timer;
	private float reset;
	void Start () 
	{
		reset = timer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer-=Time.deltaTime;
		if (timer<=0)
		{
			fire();
			timer = reset;
		}
	}

	void fire() {
		projectile.transform.position = gameObject.transform.position;
		Instantiate(projectile);
		GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave +=1;
	}
}
