using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Platformer.Core
{
    public class SceneLoading : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame


        public void OnSubmit(InputAction.CallbackContext context)
        {
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene("tutorial2", LoadSceneMode.Additive);
            StartCoroutine(LoadYourAsyncScene());

        }

        public void LoadingNextScene()
        {
            StartCoroutine(LoadYourAsyncScene());
        }


        IEnumerator LoadYourAsyncScene()
        {
            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.
            // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
            // a sceneBuildIndex of 1 as shown in Build Settings.

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Resources.UnloadUnusedAssets();
        }
    }
}