using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameController : MonoBehaviour {
	public class miniW{
		public int enemyNum;
		public GameObject[] enemies;
		public Vector3[] spawn;
        public string songName;
        public float delay;

		public miniW(int eNum, GameObject[] enem, Vector3[] spawns, string song, float d) {
			enemyNum = eNum;
			enemies = enem;
			spawn = spawns;
            songName = song;
            delay = d;
		}
	}


	public miniW[] miniWave;
	public float spawnWait;
	public GameObject projectile;
    public GameObject dprojectile;
	public GameObject drone;
    public GameObject king;
	public GameObject menu;
    public GameObject player;
	public int enemyLeftInWave;

    public GameObject textPrefab;

    Vector3 getV(int i)
    {
        return new Vector3(7f * (float)Math.Cos(1.25 * Math.PI + i * Math.PI / 12), 2, 7f * (float)Math.Sin(1.25 * Math.PI + i * Math.PI / 12));
    }

    // Use this for initialization
    void Start (){
        FindObjectOfType<AudioManager>().musicPlay("Title");
		miniWave = new miniW[4];

		//10 Projectiles
		Vector3[] wave0Spawn = new Vector3[10];
        GameObject[] wave0enemies = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            wave0Spawn[i] = new Vector3(7f * (float)Math.Cos((0.2 * i - 0.5) * Math.PI), 2, 7f * (float)Math.Sin((0.2 * i - 0.5) * Math.PI));
            wave0enemies[i] = projectile;
        }
		miniW wave0 = new miniW(10, wave0enemies, wave0Spawn,"Easy", 1f);
		miniWave[0] = wave0;

        //Alternating
        Vector3[] wave1Spawn = new Vector3[10];
        GameObject[] wave1enemies = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            wave1Spawn[9 - i] = new Vector3(7f * (float)Math.Cos((0.2 * i - 0.5) * Math.PI), 2, 7f * (float)Math.Sin((0.2 * i - 0.5) * Math.PI));
            if (i % 2 == 0)
            {
                wave1enemies[i] = projectile;
            }
            else
            {
                wave1enemies[i] = dprojectile;
            }
            
        }
        miniW wave1 = new miniW(10, wave1enemies, wave1Spawn, "None", 1f);
        miniWave[1] = wave1;

        //Rhythm Blader LUL
        Vector3[] wave2spawn = new Vector3[34];
        GameObject[] wave2enemies = new GameObject[34];
        wave2spawn[0] = getV(5);
        wave2enemies[0] = projectile;
        wave2spawn[1] = getV(1);
        wave2enemies[1] = dprojectile;
        wave2spawn[2] = getV(5);
        wave2enemies[2] = projectile;
        wave2spawn[3] = getV(5);
        wave2enemies[3] = projectile;
        for (int i = 4; i < 11; i++)
        {
            wave2spawn[i] = getV(Math.Abs(7 - i));
            wave2enemies[i] = dprojectile;
        }
        for (int i = 11; i < 16; i++)
        {
            if (i % 2 == 1)
            {
                wave2spawn[i] = getV(5);
                wave2enemies[i] = projectile;
            }
            else
            {
                wave2spawn[i] = getV(4);
                wave2enemies[i] = dprojectile;
            }
        }
        wave2spawn[16] = getV(4);
        wave2spawn[17] = getV(3);
        wave2spawn[18] = getV(2);
        wave2spawn[19] = getV(3);
        wave2spawn[20] = getV(4);
        wave2spawn[21] = getV(5);
        wave2spawn[22] = getV(6);
        wave2spawn[23] = getV(5);
        wave2enemies[16] = projectile;
        wave2enemies[17] = projectile;
        wave2enemies[18] = projectile;
        wave2enemies[19] = dprojectile;
        wave2enemies[20] = dprojectile;
        wave2enemies[21] = projectile;
        wave2enemies[22] = projectile;
        wave2enemies[23] = dprojectile;

        for (int i = 24; i < 34; i++)
        {
            if (i % 2 == 0)
            {
                wave2spawn[i] = getV(4);
                wave2enemies[i] = dprojectile;
            }
            else
            {
                wave2spawn[i] = getV(5);
                wave2enemies[i] = projectile;
            }
        }

        miniW wave2 = new miniW(34, wave2enemies, wave2spawn, "None", 0.4f);
        miniWave[2] = wave2;

        //2 Drones
        /*Vector3[] wave1Spawn = new Vector3[2];
        GameObject[] wave1enemies = new GameObject[2];
        wave1enemies[0] = drone;
        wave1enemies[1] = drone;
		wave1Spawn[0] = new Vector3(6.5f, 1, 6.5f);
		wave1Spawn[1] = new Vector3(-6.5f, 1, -6.5f);
		miniW wave1 = new miniW(2, wave1enemies, wave1Spawn,"None");
		miniWave[1] = wave1;
		
        //Drone, circle balls, drone
        Vector3[] wave2spawn = new Vector3[12];
        GameObject[] wave2enemies = new GameObject[12];
        wave2enemies[0] = drone;
        wave2spawn[0] = new Vector3(7, 1, 7);
        for (int i = 0; i < 10; i++)
        {
            wave2spawn[i + 1] = new Vector3(7f * (float)Math.Cos(0.2 * i * Math.PI), 2, 7f * (float)Math.Sin(0.2 * i * Math.PI));
            wave2enemies[i + 1] = projectile;
        }
        wave2enemies[11] = drone;
        wave2spawn[11] = new Vector3(-7, 1, -7);
        miniW wave2 = new miniW(12, wave2enemies, wave2spawn,"None");
        miniWave[2] = wave2;*/

        //King
        Vector3[] wave3spawn = new Vector3[1];
        GameObject[] wave3enemies = new GameObject[1];
        wave3enemies[0] = king;
        wave3spawn[0] = new Vector3(0, 1, -5);
        miniW wave3 = new miniW(1, wave3enemies, wave3spawn,"None", 0f);
        miniWave[3] = wave3;

        StartCoroutine(spawnWave());

    }
	IEnumerator spawn (miniW miniWave){
        if(miniWave.songName != "None") FindObjectOfType<AudioManager>().musicChange(miniWave.songName);
        for (int i = 0; i<miniWave.enemyNum; i++){
			miniWave.enemies[i].transform.position = miniWave.spawn[i];
			Instantiate(miniWave.enemies[i]);
            yield return new WaitForSeconds(miniWave.delay);
		}
	}
	IEnumerator spawnWave(){
		for (int i = 0; i < miniWave.Length; i++){
            menu.transform.position = new Vector3(0, 1.5f, -1.5f);
            Instantiate(menu);
            GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave += 1;
            //Eventually change to waiting for player to hit start next wave block
            //yield return new WaitForSeconds(spawnWait);
            yield return new WaitUntil(() => enemyLeftInWave < 1);

            enemyLeftInWave = miniWave[i].enemyNum;
			StartCoroutine(spawn(miniWave[i])); //Miniwave is one miniwave. loop through the miniwaves to spawn an entire wave.
			yield return new WaitUntil(()=>enemyLeftInWave < 1);
            player.GetComponent<PlayerConstants>().health = 3;
        }
        Instantiate(textPrefab);

    }

    IEnumerator welcomeSounds ()
    {
        FindObjectOfType<AudioManager>().musicPlay("Title");
        yield return new WaitForSeconds(1);
    }
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
