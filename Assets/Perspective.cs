using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Perspective : MonoBehaviour
{
    public bool swap = false;

    public Camera camOne;

    public Camera camTwo;

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

            SwitchCameras();
        }
    }

    public void SwitchCameras()
    {
        camOne.enabled = !camOne.enabled;
        camTwo.enabled = !camTwo.enabled;
    }
}
