using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject[] enemies; //array of GameObeject to spawn.
	public int[] enemyNum; //array of number of each enemy to spawn corresponding to enemy
	public int enemyCount;
	public float spawnWait;
	public int enemyLeftInWave;
	// Use this for initialization
	void Start (){
		StartCoroutine(spawnWave());
	}
	void spawn (GameObject enemy, int enemyNum){
		for (int i = 0; i<enemyNum; i++){
			enemy.transform.position = new Vector3(i*2, 10, 0);
			Instantiate(enemy);
		}
	}
	IEnumerator spawnWave(){
		for (int i = 0; i < enemies.Length; i++){
			enemyLeftInWave = enemyCount;
			spawn(enemies[i], enemyNum[i]);
			yield return new WaitUntil(()=>enemyLeftInWave < 1);
			yield return new WaitForSeconds(spawnWait);
		}

		//loop through enemy[]
		//spawn enemyNum[] enemies
		//wait until enemyleftinwave <1
		enemyLeftInWave = enemyCount;
		/*for (int i = 0; i<enemyCount; i++){
			enemy1.transform.position = new Vector3(i*2, 10, 0);
			Instantiate(enemy1);
		}
		yield return new WaitUntil(()=>enemyLeftInWave <1);
		for (int i = 0; i<enemyCount; i++){
			enemy2.transform.position = new Vector3((i*2)-4, 5, 0);
			Instantiate(enemy2);
		}*/
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
