using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;

public class cameratrigger : MonoBehaviour
{
    
    public CinemachineVirtualCamera virtualCamera;
    public float zoomedOutSize = 20f;  
    public float zoomedInSize = 6f;  
    public float zoomSpeed = 0.01f;      

    private float targetSize;
    private bool isZoomedOut = false;

    void Start()
    {
        // Ensure that a CinemachineVirtualCamera is assigned
        if (virtualCamera == null)
        {
            Debug.LogError("CinemachineVirtualCamera not assigned!");
            return;
        }

        // Initialize the target size with the default size
        targetSize = 6f;
    }

    void Update()
    {
        // Smoothly interpolate towards the target size
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(
            virtualCamera.m_Lens.OrthographicSize,
            targetSize,
            Time.deltaTime * zoomSpeed
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Change "Player" to the tag of your player GameObject
        {
            if (!isZoomedOut)
            {
                ZoomOut();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isZoomedOut)
            {
                ZoomIn();
            }
            
        }
    }

    void ZoomOut()
    {
        targetSize = zoomedOutSize;
        isZoomedOut = true;
    }

    void ZoomIn()
    {
        // Set the target size back to the default size
        targetSize = zoomedInSize;
        isZoomedOut = false;
    }

}
