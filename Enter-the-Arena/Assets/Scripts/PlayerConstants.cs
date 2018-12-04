using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConstants: MonoBehaviour {
	public int health;
    
	void Update () {
		if (health<=0){
            Destroy(gameObject);
            Time.timeScale = 0;
		}
	}
	
}
