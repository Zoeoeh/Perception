﻿using UnityEngine;
using System.Collections;

public class PlinthPhys : MonoBehaviour
{
    // get refs
    private Rigidbody[] plinthBodies;

    private bool dirty = false;

    public float[] masses;
    private float currentMass = 1f;

    // Use this for initialization
    void Start ()
    {
        plinthBodies = gameObject.GetComponentsInChildren<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
    {
        if (!dirty)
            return;
        
        // change mass
        foreach (Rigidbody rb in plinthBodies)
        {
            rb.mass = currentMass;
        }

        dirty = false;
    }

    public void SetState(int choice)
    {
        currentMass = masses[choice-1];
        dirty = true;
    }


}
