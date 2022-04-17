using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Platformer.Core
{
    public class SceneLoading : MonoBehaviour
    {

        public void StartScreen()
        {
            SceneManager.LoadScene(0);
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

       public IEnumerator LoadNextAsyncScene(int level)
        {
            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.
            // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
            // a sceneBuildIndex of 1 as shown in Build Settings.
      
            
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + level);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
          SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex); 
             //SceneManager.UnloadSceneAsync(0); 
            Resources.UnloadUnusedAssets();
        }
    }
}