using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.SceneManagement;
using Platformer.Core;
namespace Platformer.GamePlay
{
    public class Escort : MonoBehaviour
    {   //[SerializeField]
        public BoxCollider2D collider2D;
        GameObject gameobj;
        [SerializeField]
        Transform firstTarget;
        [SerializeField]
        Transform secondfirstTarget;
        [SerializeField]
        Transform finalTarget;
        bool goTofinalDestination;
        bool loading;
        SceneLoading startMenu;
        // Start is called before the first frame update
        void Start()
        {
            startMenu = GetComponent<SceneLoading>();
            collider2D = GetComponent<BoxCollider2D>();
            collider2D.enabled = false;
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (!collider2D.enabled) { transform.position = Vector2.MoveTowards(transform.position,
                          firstTarget.position, 10 * Time.deltaTime);
                if (transform.position.x == firstTarget.position.x)
                {
                    //  turn collision2d on
                    collider2D.enabled = true;
                }
            }
        
            else if (goTofinalDestination && !loading)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                      finalTarget.position, 10 * Time.deltaTime);
                if (transform.position.y == finalTarget.position.y)
                {
                    loading = true;
                    startMenu.LoadingNextScene();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            
            if (collision.gameObject.tag =="Player")
            {   
                collision.gameObject.SetActive(false);
                goTofinalDestination = true;
                
            }
        }




    }

   
}