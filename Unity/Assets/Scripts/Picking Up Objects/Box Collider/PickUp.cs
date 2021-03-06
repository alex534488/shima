﻿using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    private GameObject walkedOverObject;
    private Rigidbody rb;
    private Transform characterTransform;

    private bool isPick;

    private bool guiShow;

    public OpeningClosingDoor doorInteraction;
    public OpeningClosingDrawer drawerInteraction;

    void Start ()
    {
        characterTransform = GetComponent<Transform>();

        isPick = false;
        guiShow = false;
	}

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("WalkedObject = " + walkedOverObject);             

            if (walkedOverObject != null)
            {
                switch (walkedOverObject.tag)
                {
                    case "PickUp":
                        {
                            if (isPick)
                            {
                                walkedOverObject.transform.parent = null;
                                AddWalkedOverObject(null, null);
                                rb.useGravity = true;
                                rb.isKinematic = false;
                                rb = null;
                                isPick = false;
                            }

                            else
                            {
                                walkedOverObject.transform.parent = characterTransform;
                                rb = walkedOverObject.GetComponent<Rigidbody>();
                                rb.useGravity = false;
                                rb.isKinematic = true;
                                isPick = true;
                                guiShow = false;
                            }

                            break;
                        }

                    case "Door":
                        {
                            doorInteraction.PlayAnim();
                            break;
                        }

                    case "Drawer":
                        {
                            drawerInteraction.PlayAnim(walkedOverObject.name);
                            break;
                        }

                    case "Light":
                        {
                            if (walkedOverObject.transform.GetChild(0).GetComponent<Light>().enabled == false)
                                walkedOverObject.transform.GetChild(0).GetComponent<Light>().enabled = true;

                            else
                                walkedOverObject.transform.GetChild(0).GetComponent<Light>().enabled = false;

                            walkedOverObject.GetComponent<ElectronicDevice>().ActOn();

                            break;
                        }

                    case "Electronic":
                        {
                            walkedOverObject.GetComponent<ElectronicDevice>().ActOn();
                            break;
                        }

                    default:
                        break;
                }
            }
        }
    }

    public void AddWalkedOverObject(GameObject walkedOverObjectFx, string tag)
    {
        if (walkedOverObjectFx != null)
        {
            guiShow = true;

            switch (walkedOverObjectFx.tag)
            {
                case "PickUp":
                    {
                        this.walkedOverObject = walkedOverObjectFx;
                        break;
                    }

                case "Door":
                    {
                        this.walkedOverObject = walkedOverObjectFx;
                        doorInteraction = walkedOverObject.GetComponent<OpeningClosingDoor>();
                        break;
                    }

                case "Light":
                    {
                        this.walkedOverObject = walkedOverObjectFx;
                        break;
                    }

                case "Electronic":
                    {
                        this.walkedOverObject = walkedOverObjectFx;
                        break;
                    }

                case "Drawer":
                    {
                        this.walkedOverObject = walkedOverObjectFx;
                        drawerInteraction = walkedOverObject.GetComponentInParent<OpeningClosingDrawer>();
                        break;
                    }
            }


        }

        else
        {
            isPick = false;
            guiShow = false;
            walkedOverObject = null;
        }
    }

    public GameObject GetWalkedOverObject()
    {
        return walkedOverObject;
    }

    void OnGUI()
    {
        if (walkedOverObject != null)
        {
            switch (walkedOverObject.tag)
            {
                case "PickUp":
                    {
                        if (isPick == false && guiShow == true)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Pick up object");

                        break;
                    }

                case "Door":
                    {
                        if (doorInteraction.GetStatus() == false && guiShow == true)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Open Door");

                        if (doorInteraction.GetStatus() == true && guiShow == true)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Close Door");

                        break;
                    }

                case "Light":
                    {
                        if (walkedOverObject.transform.GetChild(0).GetComponent<Light>().enabled == false && guiShow == true)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Open Light");
                            

                        if (walkedOverObject.transform.GetChild(0).GetComponent<Light>().enabled && guiShow == true)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Close Light");

                        break;
                    }

                case "Electronic":
                    {
                        if (walkedOverObject.GetComponent<ElectronicDevice>().DeviceState == ElectronicDevice.State.Off)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Open Device");

                        if (walkedOverObject.GetComponent<ElectronicDevice>().DeviceState == ElectronicDevice.State.On)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Close Device");

                        break;

                    }

                case "Drawer":
                    {
                        if (drawerInteraction.GetStatus(walkedOverObject.name) == false && guiShow == true)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Open Drawer");

                        if (drawerInteraction.GetStatus(walkedOverObject.name) == true && guiShow == true)
                            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Close Drawer");

                        break;

                    }

                default:
                    break;
            }
        }
    }      
}
