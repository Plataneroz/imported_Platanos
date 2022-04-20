using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Platformer.Core;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    SceneLoading sceneLoading;
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    private void Start()
    {
        //pauseMenuUI.SetActive(false);
           sceneLoading = GetComponent<SceneLoading>();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void LoadMenu()
    {

    }

 

    public void OnStartScreen( InputAction.CallbackContext context)
    {
        sceneLoading.StartScreen();
        Resume();
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (context.canceled && GameisPaused)
        { sceneLoading.RestartScene();  }
    }


    public void OnQuit(InputAction.CallbackContext context)
    {
        if (context.canceled && GameisPaused)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            GameisPaused = !GameisPaused;
            pauseMenuUI.SetActive(GameisPaused);
            Time.timeScale = GameisPaused? 0: 1;
        }
      
    }
}
