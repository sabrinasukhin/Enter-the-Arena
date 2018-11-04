using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[System.Serializable] //Seems amazing
	public class miniW{
		public int enemyNum;
		public GameObject enemies;

		public miniW(int eNum, GameObject enem) {
			enemyNum = eNum;
			enemies = enem;
		}
	}
	public miniW[] miniWave;
	public float spawnWait;
	public int enemyLeftInWave;
	
	// Use this for initialization
	void Start (){
		StartCoroutine(spawnWave());
		//miniW wave;
	}
	void spawn (miniW miniWave){
		for (int i = 0; i<miniWave.enemyNum; i++){
			miniWave.enemies.transform.position = new Vector3(7, 2, 0);
			Instantiate(miniWave.enemies);
		}
	}
	IEnumerator spawnWave(){
		for (int i = 0; i < miniWave.Length; i++){
			enemyLeftInWave = miniWave[i].enemyNum;
			spawn(miniWave[i]); //Miniwave is one miniwave. loop through the miniwaves to spawn an entire wave.
			yield return new WaitUntil(()=>enemyLeftInWave < 1);
			yield return new WaitForSeconds(spawnWait);
		}		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
