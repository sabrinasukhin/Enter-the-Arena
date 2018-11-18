using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSelf : MonoBehaviour {
	public float timer;
	private float reset;
	public GameObject spawnee;
	private int counter = 1;
	private Vector3[] locations; //Location for the 4 spawnee's positions.
	public float angularVel;
	// Use this for initialization
	void Start () 
	{
		reset = timer;
		locations[0] = new Vector3(0,0,2); //Top
		locations[1] = new Vector3(2,0,0); //Right
		locations[2] = new Vector3(0,0,-2); //Bottom
		locations[3] = new Vector3(-2,0,0); //Left
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer-=Time.deltaTime;
		if (timer<=0)
		{
			spawnPawn();
			timer = reset;
			counter++;
		}
		float theta = Time.deltaTime * angularVel;
		for(int i = 0; i<4;i++)
		{
			locations[i] = new Vector3(location[i].x*Math.Cos(theta)-location[i].z*Math.Sin(theta),0,locations[i].x*Math.Sin(theta)+locations[i].z*Math.Cos(theta));
		}
	}
	void spawnPawn()
	{
		//Add if statement to check position occupation and spawn at differe positions.
		int n = 0; //This be the position number of the spawnee
		spawnee.transform.position = gameObject.transform.position+locations[n];
		Instantiate(spawnee);
		GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave +=1;
	}
}
