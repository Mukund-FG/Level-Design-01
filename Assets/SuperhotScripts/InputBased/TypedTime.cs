using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TypedTime : MonoBehaviour
{
    [SerializeField] private float slowMo = .1f;
    [SerializeField] private float runTime = 1f;
    [SerializeField] private float moveTime = .5f;
    private bool doSlowMo = false;
    [SerializeField] private float moveStart = 0f;
    [SerializeField] private float runStart = 5f;

    [SerializeField] private CharacterController player;
    private StarterAssetsInputs input;


    private void Awake()
    {
        player = GetComponent<CharacterController>();
        input = GetComponent<StarterAssetsInputs>();

    }

    private void Update()
    {

        if (input.move.magnitude > moveStart)
        {
            //if (doSlowMo)
            //{
            if (input.move.magnitude > runStart)
            {
                print("Running");
                Time.timeScale = runTime;
            }
            else
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
