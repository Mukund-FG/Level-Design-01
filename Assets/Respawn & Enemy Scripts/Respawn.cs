using System;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    private Vector3 _lastRespawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            _lastRespawn = other.transform.position;
        }

        if (other.CompareTag("Enemy"))
        {
            CharacterController cc = GetComponent<CharacterController>();

            cc.enabled = false;
            print(transform.position);
            print("collided with enemy");
            transform.position = _lastRespawn;
            print(transform.position);
            cc.enabled = true;


        }

    }
}