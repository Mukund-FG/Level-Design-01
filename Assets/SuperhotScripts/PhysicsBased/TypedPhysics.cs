using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TypedPhysics : MonoBehaviour
{
    [SerializeField] private float slowMo = .1f;
    [SerializeField] private float runTime = 1f;
    [SerializeField] private float moveTime = .5f;
    private bool doSlowMo = false;
    [SerializeField] private float moveStart = 0f;
    [SerializeField] private float runStart = 5f;

    [SerializeField] private CharacterController player;

    private void Awake()
    {
        player = GetComponent<CharacterController>();

    }

    private void Update()
    {
       
        if (player.velocity.magnitude > moveStart)
        {
            //if (doSlowMo)
            //{
                if(player.velocity.magnitude > runStart)
                {
                print("Running");
                    Time.timeScale = runTime;
                } else
                {
                print("Walking");
                    Time.timeScale = moveTime;
                }
                Time.fixedDeltaTime = .02f * Time.timeScale;
                //doSlowMo = false;
            //}
        }
        //else if(player.velocity.magnitude > moveStart)
        //{
        //    if (doSlowMo)
        //    {
        //        Time.timeScale = moveTime;
        //        Time.fixedDeltaTime = .02f * Time.timeScale;
        //        doSlowMo = false;
        //    }
        //}
        else
        {
            //if (!doSlowMo)
            //{
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = .02f * Time.timeScale;
                doSlowMo = true;
            //}
        }

    }
}

