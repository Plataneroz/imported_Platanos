using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Platformer.Core;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    SceneLoading sceneLoading;
    public static bool GameisPaused = false;
    public static bool GameIsOver = false;
    public GameObject pauseMenuUI;
    public GameObject gameOver ;
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        sceneLoading = GetComponent<SceneLoading>();
        gameOver.SetActive(false); ;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }


    
    public  void GameOver()
    {
        GameIsOver = true;
        pauseMenuUI.SetActive(true); ;
        gameOver.SetActive(true);
        Pause();
    }
 
 

    public void OnStartScreen( InputAction.CallbackContext context)
    {
        GameIsOver = false;
        sceneLoading.StartScreen();
        Resume();
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (context.canceled )
        {  if(GameIsOver || GameisPaused)sceneLoading.RestartScene(); Time.timeScale = 1f; }
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
        if (context.canceled && !GameIsOver)
        {
            GameisPaused = !GameisPaused;
            pauseMenuUI.SetActive(GameisPaused);
            Time.timeScale = GameisPaused? 0: 1;
        }
      
    }

    public void Resume()
    {
        if (!GameIsOver)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameisPaused = false;
        }
    }
}
