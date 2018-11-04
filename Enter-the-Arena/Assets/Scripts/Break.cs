using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {
	private Rigidbody sword;
	private GameObject player; //Not applied yet, look at Start for more info
	private Camera fbcam;
    private GameObject controller;
	public float threshold = 3f;
	private bool broken = false;
	private float timer = 0;
    public Renderer rend;
    private Vector3 originalSize;

	// Use this for initialization
	void Start() {
		//Add something in here later on that prevents the sword from hurting the person holding it
		//Physics.IgnoreCollision(sword.GetComponent<Collider>(), Player.instance.headCollider );
		fbcam = Camera.main;
        controller = GameObject.FindWithTag("RHand");
		sword = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        originalSize = gameObject.transform.localScale;
	}
	
	void Update() {
        controller = GameObject.FindWithTag("RHand");
        fbcam = Camera.main;
        float sx = controller.gameObject.transform.position.x;
        float sz = controller.gameObject.transform.position.z;
        float cx = fbcam.gameObject.transform.position.x;
        float cz = fbcam.gameObject.transform.position.z;
        Vector2 s = new Vector2(sx, sz);
        Vector2 c = new Vector2(cx, cz);
        float distance = Vector2.Distance(s, c);
        if (distance > threshold)
        {
            gameObject.tag = "Offense";
        }
        else if (distance <= threshold)
        {
            gameObject.tag = "Defense";
        }
        if (broken) {
            if (gameObject.tag == "Defense") {
                timer -= Time.deltaTime;
            }
			if(timer <= 0) {
				broken = false;
				timer = 0;
                rend.enabled = true;
                gameObject.transform.localScale = originalSize;
			}
		}
    }

	void OnTriggerEnter(Collider collision) {
        Debug.Log("Collision detected");
		if(gameObject.CompareTag("Offense")) {
            Debug.Log("Is in offense");
			if(collision.gameObject.CompareTag("Defense") || collision.gameObject.CompareTag("Offense")) {
                Debug.Log("Hit defense");
				Breaker(gameObject);
			}
			else {
				Breaker(collision.gameObject);
			}
		}
	}

	void Breaker(GameObject o) {
        o.GetComponent<Renderer>().enabled = false;
        if (o == gameObject)
        {
            broken = true;
            gameObject.transform.localScale = Vector3.zero;
            timer = 0.5f;
        }
	}
}
