using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConstants: MonoBehaviour {
	public int health;
    public bool damaged;

    public GameObject textPrefab;

    void Start()
    {
        damaged = false;
    }
    
	void Update () {
        if(!damaged && health == 1)
        {
            FindObjectOfType<AudioManager>().Play("PLAYERHIT");
            FindObjectOfType<AudioManager>().Play("HEALTHLOW");
            damaged = true;
        }
        else if(damaged && health == 3)
        {
            damaged = false;
        }
		if (health<=0){
            FindObjectOfType<AudioManager>().Play("PLAYERHIT");
            Instantiate(textPrefab); 
            Destroy(gameObject);
            Time.timeScale = 0;
		}
	}
	
}
