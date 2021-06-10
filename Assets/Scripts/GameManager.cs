using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
    [SerializeField] Text playText;
    [SerializeField] GameObject mainMenu;

    
    [SerializeField] Text levelText;
    [SerializeField] GameObject gameMenu;
    Vector3 nextLevelTextScale;
    
    [SerializeField] GameObject levels;
    
    private void OnEnable()
    {
        EventManager.onStartGame += ChooseLevel;
        // EventManager.onLevelComplete += LevelUp;
    }
    private void OnDisable()
    {
        EventManager.onStartGame -= ChooseLevel;
        // EventManager.onLevelComplete -= LevelUp;
    }
  
    void ChooseLevel()
    {
        if (mainMenu.activeSelf)
        {
            LeanTween.cancel(playText.gameObject);
            mainMenu.SetActive(false);
        }
        if (!gameMenu.activeSelf)
            gameMenu.SetActive(true);
        
        int level = PlayerPrefs.GetInt("level", 1);

        levelText.text = "Level " + level.ToString();
        if(level==1)
            levels.transform.GetChild(0).gameObject.SetActive(true);
        // else
        // {
        //     if (levels.transform.childCount < level)
        //     {
        //         PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") - 1);
        //         level -= 1;
        //         Refresh();
        //     }
        //     levels.transform.GetChild(level-2).gameObject.SetActive(false);
        //     levels.transform.GetChild(level-1).gameObject.SetActive(true);
        // }
    }
    void LevelUp()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level",1) + 1);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Refresh()
    {
        EventManager.RefreshGame();
    }
}
