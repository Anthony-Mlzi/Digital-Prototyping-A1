using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SpotLight : MonoBehaviour
{
    public bool spotted;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") == true)
        {
            spotted = true;
            SceneManager.LoadScene(0);
        }
    }
}
