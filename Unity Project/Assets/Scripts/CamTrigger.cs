using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public GameObject camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bunny"))
        {
            camera.SetActive(false);
        }
    }
}
