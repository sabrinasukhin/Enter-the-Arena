using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

	public GameObject projectile;
    public GameObject player;
    public float attackThreshold;
    public float timer;
    public float speed;
	private float reset;
	void Start () 
	{
        player = GameObject.FindWithTag("Player");
        reset = timer;
	}
	
	// Update is called once per frame
	void Update () 
	{
        float kingx = gameObject.transform.position.x;
        float kingz = gameObject.transform.position.z;
        float playerx = player.gameObject.transform.position.x;
        float playerz = player.gameObject.transform.position.z;
        Vector2 k = new Vector2(kingx, kingz);
        Vector2 p = new Vector2(playerx, playerz);
        float distance = Vector2.Distance(k, p);
        if (distance <= attackThreshold)
        {
            if (timer <= 0)
            {
                fire();
                timer = reset;
            }
        }
        else
        {
            Move(k, p);
        }
        timer -=Time.deltaTime;
	}

    void Move(Vector2 current, Vector2 target)
    {
        Vector2 newXY = Vector2.MoveTowards(current, target, speed * Time.deltaTime);
        gameObject.transform.position = new Vector3(newXY.x, gameObject.transform.position.y, newXY.y);
    }

    void fire() {
		projectile.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z);
		Instantiate(projectile);
		GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave +=1;
	}
}
