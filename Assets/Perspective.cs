using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Perspective : MonoBehaviour
{
    public bool swap = false;

    public float playerPosX;

    public Vector3 playerPos;

    public Camera camOne;

    public Camera camTwo;

    public Movement player;

    public Animator cameraTransition;

    public void Start()
    {
        camTwo.enabled = false;
    }
    public void Update()
    {
        ChangePerspective();
    }
    public void ChangePerspective()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Switch");

            CameraTransition(player);
        }
    }

    public void SwitchCameras(Movement player)
    {
        camOne.enabled = !camOne.enabled;
        camTwo.enabled = !camTwo.enabled;
    }

    public void CameraTransition(Movement player)
    {
        cameraTransition.SetFloat("transitionSpeed", 1.0f); 
    }
}
