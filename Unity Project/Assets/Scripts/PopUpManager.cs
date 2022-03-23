using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpManager : MonoBehaviour
{

    public string text;
    [SerializeField] GameObject popUp;
    [SerializeField] TextMeshProUGUI textMesh;
    private bool condition = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && condition)
        {
            popUp.SetActive(true);
            textMesh.text = text;
            condition = false;  
        }
    }

    public void Ok()
    {
        popUp.SetActive(false);
        textMesh.text = "";
    }
   
}
