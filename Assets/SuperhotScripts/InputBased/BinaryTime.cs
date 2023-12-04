using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class BinaryTime : MonoBehaviour
{
    [SerializeField] private float slowMo = .1f;
    [SerializeField] private float normTime = 1f;
    private bool doSlowMo = false;

    [SerializeField] private CharacterController player;
    private StarterAssetsInputs input;


    private void Awake()
    {
        player = GetComponent<CharacterController>();
        input = GetComponent<StarterAssetsInputs>();

    }

    private void Update()
    {
        if (input.move.magnitude > 0f)
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
