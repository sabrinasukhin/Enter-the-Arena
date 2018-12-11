using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {

    private Renderer rend;
    private bool damaged;
    private Material umat;
    private Material dmat;
    private GameObject player;

	// Use this for initialization
	void Start()
    {
        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
        damaged = false;
        umat = rend.materials[0];
        dmat = rend.materials[1];
        rend.material.shader = Shader.Find("Standard");
        player = GameObject.FindWithTag("Player");
    }
    
	
	// Update is called once per frame
	void Update () {
        bool pdamaged = player.GetComponent<PlayerConstants>().damaged;
        if(pdamaged != damaged)
        {
            damaged = pdamaged;
            if (damaged)
            {
                rend.material = dmat;
            }
            else
            {
                rend.material = umat;
            }
        }
    }
}
