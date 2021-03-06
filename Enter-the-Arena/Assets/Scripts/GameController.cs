﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameController : MonoBehaviour {
	public class miniW{
		public int enemyNum;
		public GameObject enemies;
		public Vector3[] spawn;

		public miniW(int eNum, GameObject enem, Vector3[] spawns) {
			enemyNum = eNum;
			enemies = enem;
			spawn = spawns;
		}
	}


	public miniW[] miniWave;
	public float spawnWait;
	public GameObject enemyType1;
	public GameObject enemyType2; 
	public GameObject menu;
	public int enemyLeftInWave;
	
	// Use this for initialization
	void Start (){
		miniWave = new miniW[2];

		//10 Projectiles
		Vector3[] wave0Spawn = new Vector3[10];
        for (int i = 0; i < 10; i++)
        {
            wave0Spawn[i] = new Vector3(7f * (float)Math.Cos(0.2 * i * Math.PI), 2, 7f * (float)Math.Sin(0.2 * i * Math.PI));
        }
		miniW wave0 = new miniW(10, enemyType1, wave0Spawn);
		miniWave[0] = wave0;

		//2 Kings
		Vector3[] wave1Spawn = new Vector3[2];
		wave1Spawn[0] = new Vector3(0.5f, 1, 0.5f);
		wave1Spawn[1] = new Vector3(-0.5f, 1, -0.5f);
		miniW wave1 = new miniW(2, enemyType2, wave1Spawn);
		miniWave[1] = wave1;
		StartCoroutine(spawnWave());
	}
	IEnumerator spawn (miniW miniWave){
		for (int i = 0; i<miniWave.enemyNum; i++){
			miniWave.enemies.transform.position = miniWave.spawn[i];
			Instantiate(miniWave.enemies);
            yield return new WaitForSeconds(1);
		}
	}
	IEnumerator spawnWave(){
		for (int i = 0; i < miniWave.Length; i++){
            menu.transform.position = new Vector3(0, 0.5f, 0);
            Instantiate(menu);
            GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave += 1;
            //Eventually change to waiting for player to hit start next wave block
            //yield return new WaitForSeconds(spawnWait);
            yield return new WaitUntil(() => enemyLeftInWave < 1);

            enemyLeftInWave = miniWave[i].enemyNum;
			StartCoroutine(spawn(miniWave[i])); //Miniwave is one miniwave. loop through the miniwaves to spawn an entire wave.
			yield return new WaitUntil(()=>enemyLeftInWave < 1);
		}		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
