using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

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
        ChangePerspective(player);
    }
    public void ChangePerspective(Movement player)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Switch2D");

            CameraTransition2D(player);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Switch3D");

            CameraTransition3D(player);
        }

    }

    public void SwitchCameras(Movement player)
    {
        camOne.enabled = !camOne.enabled;
        camTwo.enabled = !camTwo.enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "2DSwitcher")
        {
            Debug.Log("Switch2D");

            CameraTransition2D(player);
        }
        else if (other.gameObject.tag == "3DSwitcher")
        {
            Debug.Log("Switch3D");

            CameraTransition3D(player);
        }
    }

    public void CameraTransition2D(Movement player)
    {
        cameraTransition.SetFloat("transitionSpeed", 0.75f);
        cameraTransition.Play("CameraSmoothTransition", 0, 0.0f);
           
    }
    
    public void CameraTransition3D(Movement player)
    {
        cameraTransition.SetFloat("transitionSpeed", -0.75f);
        cameraTransition.Play("CameraSmoothTransition", 0, 1.0f);
    }
}
