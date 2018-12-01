using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public Rigidbody rb;
    public Vector3 displacement;
    private Vector3 direction;
    private GameObject player;
    public int speed = 1;
    private float timer;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        displacement = player.transform.position - gameObject.transform.position;
        direction = new Vector3 (displacement.x/displacement.magnitude, 0, displacement.z/displacement.magnitude);
        timer = displacement.magnitude/speed;
        rb.velocity = new Vector3 (speed*direction.x,displacement.y/timer+(4.905f)*timer,speed*direction.z);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player")) {
            Debug.Log(collision);
            player.GetComponent<PlayerConstants>().health -=1;
            Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave -=1;
        }
        else if(collision.CompareTag("Ground")){
            Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave -=1;
        }
    }

    void Update()
    {
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().enemyLeftInWave -= 1;
        }
    }
}