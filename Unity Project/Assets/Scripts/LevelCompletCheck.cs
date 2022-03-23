using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletCheck : MonoBehaviour
{
    [SerializeField] GameObject levelComplet;
    bool condition = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && condition)
        {
            condition = false;
            levelComplet.SetActive(true);
            if (FindObjectOfType<MenuManager>().nextSceneLoad> PlayerPrefs.GetInt("LevlAt"))
            {
                PlayerPrefs.SetInt("LevlAt", FindObjectOfType<MenuManager>().nextSceneLoad);
            }
            FindObjectOfType<PlayerMovment>().FreezPlayerMovement();
        }
    }
}
