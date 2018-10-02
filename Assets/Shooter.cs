using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Shooter : MonoBehaviour {

	public GameObject Bullet;
    public Camera myCamera;

    const float MinTimeBetweenShots = 2.0f;
    float TimeSinceLastShot = MinTimeBetweenShots;
    public float shield = 0f;
    public float heat = 0f;
    public bool inGame = false;


    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        


        TimeSinceLastShot += Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            TimeSinceLastShot = 0;
            GameObject bullet = Instantiate<GameObject>(Bullet, transform.position + transform.up / 2 + transform.right / 2 + transform.forward * 2, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = myCamera.transform.forward * 50;

            Debug.Log(Camera.main.transform.forward);
        }
		
	}

    internal void Boot()
    {
        inGame = true;
        heat = 0;
        shield = 1;
    }
}
