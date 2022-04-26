using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class MinionColliding : MonoBehaviour
    {

        MinionComponets minionComponets;
        

        private void Start()
        {
            minionComponets = GetComponent<MinionComponets>();
        }

        
        // Start is called before the first frame update
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (!enabled) return;
            
            if (collision.gameObject.tag == "Player")
            {
                var playerHealthComponent = collision.gameObject.GetComponent<PlayerHealthComponents>();
                var spriteEffects = collision.gameObject.GetComponent<SpriteEffects>();
                var minionAndPlayerCollision = Schedule<MinionAndPlayerCollision>();
                minionAndPlayerCollision.playerHealthComponents = playerHealthComponent;
                minionAndPlayerCollision.spriteEffects = spriteEffects;
            }

        }

    }
}