using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstants: MonoBehaviour {
	public int health;

	void Update () {
		if (health<=0){
			Destroy(gameObject);
		}
	}
	
}
