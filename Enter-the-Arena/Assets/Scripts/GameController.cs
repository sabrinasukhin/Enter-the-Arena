using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[System.Serializable]
	public class miniW{
		public int enemyNum;
		public GameObject enemies;

		public miniW(int eNum, GameObject enem) {
			enemyNum = eNum;
			enemies = enem;
		}
	}
	public miniW[] miniWave;
	public int enemyCount;
	public float spawnWait;
	public int enemyLeftInWave;
	
	// Use this for initialization
	void Start (){
		StartCoroutine(spawnWave());
		//miniW wave;
	}
	void spawn (miniW miniWave){
		for (int i = 0; i<miniWave.enemyNum; i++){
			miniWave.enemies.transform.position = new Vector3(i*2, 10, 0);
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

		enemyLeftInWave = enemyCount;		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
