using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(1f, 2f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0.05f, 0f, 0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(gameObject);
        Destroy(gameObject);
    }
}
