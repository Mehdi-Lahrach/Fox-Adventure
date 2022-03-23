using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysChecker : MonoBehaviour
{
   public int numberOfKeys;

    private void Update()
    {
        if (FindObjectOfType<ItemsDisplayer>().keyCounter == numberOfKeys)
            gameObject.SetActive(false);
    }
}
