using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject pauseSelectedButton;
    public GameObject pause;

    private bool _isPaused;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
            if (_isPaused)
                Resume();
            else if (!_isPaused)
                Pause();
    }

    public void Resume()
    {
        pause.SetActive(false);
        _isPaused = false;
        Time.timeScale = 1f;
    }
    
    private void Pause()
    {
        pause.SetActive(true);
        _isPaused = true;
        Time.timeScale = 0f;
        pauseSelectedButton.GetComponent<Button>().Select();
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}
