using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


/*
 * Kade Hasenfus
 * DOCUMENTATION:
 * simply attach this script to each of your hands in the steamvr player rig
 * and set all rigid bodies you want to be pickupable to its own custom layer
 * (I recommend making a new named one called 'pickupable' or something). once
 * you have attached this script to each hand, in its fields on the hand object you 
 * have attached it to, configure the pickup distance (if you want), set layer for
 * pickupable objects, and then finally, in the final field 'Hand Source,' select the 
 * hand that corresponds to the hand you have added this script to (in that instance),
 * and watch the magic happen :) It should be controller-trigger to pIck up objects.
 * further documentation and explaination provided inline should you want to tweak any
 * functionality.
 * 
 * coded using things learned from https://www.youtube.com/watch?v=nodALlM_IKY (since the
 * actual steam API documentation is seemingly nonexistant, lol.
 */
public class PickUpHand : MonoBehaviour
{
    //configurable grabbing distance, with a default value
    public float pickupDistance = 0.3f;

    //the layer in which grabbable objects exist
    public LayerMask pickupableObjectsLayer;

    //the hand doing the grabbing
    public SteamVR_Input_Sources handSource;

    //bookkeeping bool about the hands state, assume open at scene start.
    bool isHandClosed = false;

    //what will ultimately be picked up
    Rigidbody targetObject;
   
    //called once per fixed framerate
    void FixedUpdate()
    {
        //checking if trigger is pulled, true if so, false otherwise. to bind the pickup action to something else, change the 'default_InteractUI' part to something else from here: https://valvesoftware.github.io/steamvr_unity_plugin/api/Valve.VR.SteamVR_Actions.html
        isHandClosed = SteamVR_Actions.default_InteractUI.GetState(handSource);

        //if hand is open, scan for objects within range (and on layer) to pick up, and...
        if (!isHandClosed)
        {
            //...add their colliders to an array
            Collider[] colliders = Physics.OverlapSphere(transform.position, pickupDistance, pickupableObjectsLayer);
            //if the colliders array contains anything, grab the firt element and make this the pickup target. otherwise, pickup target = null.
            targetObject = ((colliders.Length > 0) ? colliders[0].transform.root.GetComponent<Rigidbody>() : null);
        }
        //else the hand is closed, so...
        else
        {
            //...is there something we can grab? if so...
            if (isHandClosed)
            {
                //...move it into the hand by setting its velocity to the difference between the hands position and the objects position, over instantaneous time.
                targetObject.velocity = (transform.position - targetObject.position -new Vector3(0f, 0.05f, 0.05f)) / Time.fixedDeltaTime;
            }
        }
    }
}
