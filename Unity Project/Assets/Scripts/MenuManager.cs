using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public Button[] levleButtons;
    public int nextSceneLoad;
    
    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("LevlAt", 2);
        for(int i =0; i<levleButtons.Length; i++)
        {
            if(i+2 > levelAt)
            {
                levleButtons[i].interactable = false;
            }
        }
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
    public void LoadWinSceneAfterSeconds()
    {
        Invoke(nameof(LoadWinScene), 5f);
       
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadSecondLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadThirdLevel()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadFourthLevel()
    {
        SceneManager.LoadScene("Level4");
    }
    public void LoadBossLevel()
    {
        SceneManager.LoadScene("BossLevel");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void LoadNextLevel()
    {
            SceneManager.LoadScene(nextSceneLoad);
            if (nextSceneLoad > PlayerPrefs.GetInt("LevlAt"))
            {
                PlayerPrefs.SetInt("LevlAt", nextSceneLoad);
            }
    }
    public void DeleteLevelProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }
}

