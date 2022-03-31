using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.SceneManagement;

namespace Platformer.GamePlay
{
    public class Escort : MonoBehaviour
    {   //[SerializeField]
        public BoxCollider2D collider2D;
        GameObject gameobj;
        [SerializeField]
        Transform target;
        [SerializeField]
        Transform secondTarget;
        [SerializeField]
        Transform finafTarget;
        bool goTofinalDestination;
        // Start is called before the first frame update
        void Start()
        {
            collider2D = GetComponent<BoxCollider2D>();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (!collider2D.enabled) { transform.position = Vector2.MoveTowards(transform.position,
                          target.position, 3 * Time.deltaTime);
                if (transform.position.x == target.position.x)
                {
                    //  turn collision2d on
                    collider2D.enabled = true;
                }
            }
        
            else if (goTofinalDestination)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                      finafTarget.position, 20 * Time.deltaTime);

            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                goTofinalDestination = true;
                player.gameObject.SetActive(false);
                StartCoroutine(LoadYourAsyncScene());
            }
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