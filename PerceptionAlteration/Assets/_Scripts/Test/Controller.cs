﻿using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{   
    private GameObject player;
    private UserCollisionDetection playerScript;
    private SteamVR_TrackedObject trackedObj;
    private GameObject enemyContainer;
    private PlinthSpawner enemyScript;
    public GameObject dogCatcher;

    private Valve.VR.EVRButtonId gripBtn = Valve.VR.EVRButtonId.k_EButton_Grip;
    public bool gripDown = false;
    public bool gripUp = false;
    public bool gripPressed = false;

    private Valve.VR.EVRButtonId triggerBtn = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerDown = false;
    public bool triggerUp = false;
    public bool triggerPressed = false;

    private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    public bool touchDown = false;
    private bool showCatcher = false; // show or hide Catcher

    private SteamVR_Controller.Device myController { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    void Start()
    {
        // initialise controller objects 
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<UserCollisionDetection>();
        enemyContainer = GameObject.FindGameObjectWithTag("Respawn");
        enemyScript = enemyContainer.GetComponent<PlinthSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if controller is null or not first
        if (myController == null)
        {
            Debug.LogError("Controller not found!!");
            return;
        }

        // set booleans
        gripDown = myController.GetPressDown(gripBtn);
        gripUp = myController.GetPressUp(gripBtn);
        gripPressed = myController.GetPress(gripBtn);

        triggerDown = myController.GetPressDown(triggerBtn);
        triggerUp = myController.GetPressUp(triggerBtn);
        triggerPressed = myController.GetPress(triggerBtn);

        touchDown = myController.GetTouchDown(touchPad);

        if (triggerDown)
        {
            // send ball out of room
            enemyScript.Spawn();
        }

        if (gripDown)
        {
            playerScript.CurrentScale = scaleMode.resetting;
        }

        if (touchDown)
        {
            Debug.Log("TouchDown");

            // toggle catcher
            if (dogCatcher)
            {
                showCatcher = showCatcher == true ? false : true;

                dogCatcher.SetActive(showCatcher);
            }
        }
        
    }
}
