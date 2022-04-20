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
        public PlayerHealthComponents playerHealthComponents;
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
            
             if (collision.gameObject.tag == "player")
            {
                var playerHealthComponents = collision.gameObject.GetComponent<PlayerHealthComponents>();
                var spriteEffects = collision.gameObject.GetComponent<SpriteEffects>();

                if (!playerHealthComponents.IsAlive) { Schedule<PlayerDeath>(); }
                else
                {
                   var col=  Schedule<PlayerAndProjectileCollision>();
                    col.playerHealthComponents = playerHealthComponents;
                    col.spriteEffects = spriteEffects;
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