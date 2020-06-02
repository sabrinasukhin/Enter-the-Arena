using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {
	private Rigidbody sword;
	private GameObject player; //Not applied yet, look at Start for more info
	private GameObject fbcam;
    private GameObject controller;
    public Material omat;
    public Material dmat;
	public float threshold = 3f;
	private bool broken = false;
	private float timer = 0;
	private Renderer rend;
	private Vector3 og;

	// Use this for initialization
	void Start() {
		//Add something in here later on that prevents the sword from hurting the person holding it
		//Physics.IgnoreCollision(sword.GetComponent<Collider>(), Player.instance.headCollider );
		fbcam = GameObject.FindWithTag("MainCamera");
        controller = GameObject.FindWithTag("RHand");
		sword = GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();
		og = gameObject.transform.localScale;
	}
	
	void Update() {
        controller = GameObject.FindWithTag("RHand");
        float sx = controller.gameObject.transform.position.x;
        float sz = controller.gameObject.transform.position.z;
        float cx = fbcam.gameObject.transform.position.x;
        float cz = fbcam.gameObject.transform.position.z;
        Vector2 s = new Vector2(sx, sz);
        Vector2 c = new Vector2(cx, cz);
        float distance = Vector2.Distance(s, c);
        //Switch to OFFENSE MODE
        if (distance > threshold && (gameObject.tag == "Untagged" || gameObject.tag == "Defense") )
        {
        	FindObjectOfType<AudioManager>().Play("ATKSword");
            gameObject.tag = "Offense";
            gameObject.GetComponent<Renderer>().material = omat;
        }
        //Switch to DEFENSE MODE
        else if (distance <= threshold && (gameObject.tag == "Untagged" || gameObject.tag == "Offense") )
        {
        	FindObjectOfType<AudioManager>().Play("DEFSword");
            gameObject.tag = "Defense";
            gameObject.GetComponent<Renderer>().material = dmat;
        }
        if (broken) {
            if (gameObject.tag == "Defense")
            {
                timer -= Time.deltaTime;
            }
			if(timer <= 0) {
				broken = false;
				timer = 0;
				gameObject.transform.localScale = og;
				rend.enabled = true;
			}
		}
	}

	void OnTriggerEnter(Collider collision) {
		if(gameObject.CompareTag("Offense")) {
			if(collision.gameObject.CompareTag("Defense")) {
				Breaker(gameObject);
			}
			else if(!collision.gameObject.CompareTag("Player")){
				Kill(collision.gameObject);
			}
		}
	}

    void Kill(GameObject o)
    {
        Destroy(o);
        GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave -= 1;
    }

    void Breaker(GameObject o)
    {
        o.GetComponent<Renderer>().enabled = false;
        broken = true;
        gameObject.transform.localScale = Vector3.zero;
        timer = 0.5f;
    }
}
