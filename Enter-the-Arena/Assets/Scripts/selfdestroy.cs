using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestroy : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
    	GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave -=1;
    	Destroy(gameObject);
    }

}
