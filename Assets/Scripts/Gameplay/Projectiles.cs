using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class Projectiles : MonoBehaviour
    {

        public int coroutineCounter;
        public float speedLimit = 4;
        public float launchAngleLimit = -160;
        public float forHowLongIsItDangerous = 6;

        // Start is called before the first frame update
        void Start()
        {
            transform.eulerAngles = new Vector3(0, 0, Random.Range(-120, launchAngleLimit));
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedLimit);
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {

                player.health.Decrement();
                if (!player.health.IsAlive) { Schedule<PlayerDeath>(); }
                else
                {
                    StartCoroutine(player.spriteEffects.Blink());
                    player.lifeBar.ChangeSprite();
                    Destroy(gameObject, .5f);
                }


            }
            else if

                (collision.gameObject.tag =="Ground"){
                Destroy(gameObject);
            }
            
        }
    }
}