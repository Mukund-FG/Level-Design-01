using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ThirdPersonController))]

public class LerpedTime : MonoBehaviour
{
    [SerializeField] private float slowMo = .1f;
    [SerializeField] private float normTime = 1f;
    private bool doSlowMo = false;

    [SerializeField] private CharacterController player;
    private ThirdPersonController controller;
    private StarterAssetsInputs input;

    private void Awake()
    {
        player = GetComponent<CharacterController>();
        controller = GetComponent<ThirdPersonController>();
        input = GetComponent<StarterAssetsInputs>();

    }

    private void Update()
    {

        if (input.move.magnitude > 0f)
        {

           
                Time.timeScale = Mathf.Clamp(Mathf.Lerp(0f, 1f, input.move.magnitude), slowMo, 1f);

                Time.fixedDeltaTime = .02f * Time.timeScale;
                doSlowMo = false;
            
        }
        else
        {
           
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = .02f * Time.timeScale;
                doSlowMo = true;
            
        }


    }
}
