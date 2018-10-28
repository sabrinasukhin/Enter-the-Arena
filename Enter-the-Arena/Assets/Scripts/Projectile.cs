using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public Vector3 speed = new Vector3(1f,1f,0f);
    public Vector3 gravity = new Vector3(0f,.05f,0f);
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        speed -= gravity;
        gameObject.transform.position += speed;
    }
}