using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
  public static bool isPaused = false;
  public GameObject PauseMenuUI, DeathScreen, PauseActiveButton, DeathActiveButton;
  DamageControl DamageControl;

    void Start()
    {
      Time.timeScale = 1f;
      DamageControl = GameObject.FindWithTag("Player").GetComponent<DamageControl>();
    }

    void Dead()
    {
      DeathScreen.SetActive(true);
      Time.timeScale = 0f;
      DeathActiveButton.GetComponent<Button>().Select();
    }

    void Pause()
    {
      PauseMenuUI.SetActive(true);
      isPaused = true;
      Time.timeScale = 0f;
      PauseActiveButton.GetComponent<Button>().Select();
    }

    // Update is called once per frame
    public void Resume()
    {
      PauseMenuUI.SetActive(false);
      isPaused = false;
      Time.timeScale = 1f;
    }

    void Update()
    {
      if (DamageControl.dead == false)
        if (Input.GetButtonDown("Pause"))
          if (isPaused)
            Resume();
          else
            Pause();
    }

    void FixedUpdate()
    {
      if (DamageControl.dead)
        Dead();
      else
        return;
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

    public void Restart()
    {
      DamageControl.dead = false;
      DeathScreen.SetActive(false);
      SceneManager.LoadScene("SampleScene");
    }
}
