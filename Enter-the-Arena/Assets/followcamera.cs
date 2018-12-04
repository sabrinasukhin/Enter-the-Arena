using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour {
    private GameObject camera;
	// Use this for initialization
	void Start () {
        camera = GameObject.FindWithTag("MainCamera");
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 0.7f, camera.transform.position.z);
        
    }
}
