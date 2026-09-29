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

    public Movement player;

    public Animator cameraTransition;

    public void Start()
    {
        swap = false;
    }
    public void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "2DSwitcher")
        {
            Debug.Log("Switch2D");

            swap = true;

            CameraTransition2D(player);
        }
        else if (other.gameObject.tag == "3DSwitcher")
        {
            Debug.Log("Switch3D");

            swap = false;

            CameraTransition3D(player);
        }
    }

    public void CameraTransition2D(Movement player)
    {
        cameraTransition.SetFloat("transitionSpeed", 0.60f);
        cameraTransition.Play("CameraSmoothTransition", 0, 0.0f);
           
    }
    
    public void CameraTransition3D(Movement player)
    {
        cameraTransition.SetFloat("transitionSpeed", -0.60f);
        cameraTransition.Play("CameraSmoothTransition", 0, 1.0f);
    }
}
