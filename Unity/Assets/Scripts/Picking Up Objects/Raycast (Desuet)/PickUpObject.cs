﻿using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

    private bool guiShow = false;
    private bool isPick = false;

    public int rayLenght;

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 position = new Vector3(transform.position.x, 12, transform.position.z);

        Debug.DrawRay(position, fwd * rayLenght, Color.green);
        //Debug.Log(fwd + "-" + transform.position);

        if (Physics.Raycast(position, fwd, out hit, rayLenght))
        {
            if (hit.collider.gameObject.tag == "PickUp")
                guiShow = true;
        }

        else
            guiShow = false;
    }

        void OnGUI()
    {
        if (guiShow == true && isPick == false)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Pick up object");
        }

    }

}
