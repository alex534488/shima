﻿using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    Rigidbody rgbd;

    float massColliderEnter;
    float massColliderExit;
    float massTotale;

    bool pressureOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(massTotale);
        Debug.Log(pressureOn);
	}

    void OnCollisionEnter(Collision other)
    {
        rgbd = other.gameObject.GetComponent<Rigidbody>();
        massColliderEnter = rgbd.mass;

        massTotale = massTotale + massColliderEnter;
        
        if (massTotale != 0)
        {
            pressureOn = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        massColliderExit = other.gameObject.GetComponent<Rigidbody>().mass;
        massTotale = massTotale - massColliderExit;

        if (massTotale == 0)
        {
            pressureOn = false;
        }

    }
}