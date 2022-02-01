using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject gameFinishPanel;

    public TMPro.TextMeshProUGUI attackText;


    public void OnClickHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnClickReplay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OnClickPause()
    {
        Time.timeScale = 0;
        OpenPausePanel();

    }

    public void OnClickResume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void OpenGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void OpenLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
    }

    public void OpenGameFinishPanel()
    {
        gameFinishPanel.SetActive(true);
    }


}
