using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class ProjectilesCollision : MonoBehaviour
    {
        public bool dieOnImpact;

        public PlayerHealthComponents playerHealthComponents;
        // Start is called before the first frame update



        private void OnCollisionEnter2D(Collision2D collision)
        {
            
             if (collision.gameObject.tag == "Player")
            {
                var playerHealthComponents = collision.gameObject.GetComponent<PlayerHealthComponents>();
             

                if (!playerHealthComponents.IsAlive) { Schedule<PlayerDeath>(); }
                else
                {
                    var spriteEffects = collision.gameObject.GetComponent<SpriteEffects>();
                    var col=  Schedule<PlayerAndProjectileCollision>();
                    col.playerHealthComponents = playerHealthComponents;
                    col.spriteEffects = spriteEffects;
                    if (dieOnImpact)
                    {
                        
                        Destroy(gameObject);
                    }
                }


            }

            
        }
    }
}