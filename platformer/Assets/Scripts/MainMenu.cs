using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
    }

    public void PlayGame()
    {
      SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
      Application.Quit();
    }

}
