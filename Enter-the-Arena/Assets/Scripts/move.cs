using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public GameObject testSphere;

public class move : MonoBehaviour {
   public GameObject enemy;
    // Use this for initialization
    void Start () {
       // enemy = GameObject.Find("enemy");
        transform.position = new Vector3(0f, 5f, 0f);
        //test = Resources.Load("enemy") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0.05f, 0f, 0f);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(enemy);
        Destroy(gameObject);     
    }
}
