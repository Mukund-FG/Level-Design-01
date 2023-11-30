using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class SuperhotScript : MonoBehaviour
{
    [SerializeField] private float slowMo = .1f;
    [SerializeField] private float normTime = 1f;
    private bool doSlowMo = false;
        
    [SerializeField] private CharacterController player;

    private void Awake()
    {
        player = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        if (player.velocity.magnitude > 0f)
        {
            if (doSlowMo)
            {
                Time.timeScale = normTime;
                Time.fixedDeltaTime = .02f * Time.timeScale;
                doSlowMo = false;
            }
        }
        else
        {
            if (!doSlowMo)
            {
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = .02f * Time.timeScale;
                doSlowMo = true;
            }
        }
        
    }
}
