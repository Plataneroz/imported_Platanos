using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class EggAndTrujilloCollision : Simulation.Event<EggAndTrujilloCollision>
    {
        public TrujilloComponets trujilloComponents;
        
        // Start is called before the first frame update
        public override void Execute()
        {


            
                   if (trujilloComponents != null)
            {
                trujilloComponents.health.Decrement();
                if (!trujilloComponents.health.IsAlive)
                {
                    //Schedule<EnemyDeath>().trujilloComponents = trujilloComponents;
                }
                else if (trujilloComponents.health.GetCurrentHP() == 7)
                {

                    // call trujillo
                    trujilloComponents.activateTrujillo.JumpOffKartTrujillo() ;
                    trujilloComponents.bossSprite.ChangeSprite();

                }
                else if (trujilloComponents.health.GetCurrentHP() <= 9 
                     )
                { trujilloComponents.bossSprite.ChangeSprite(); }
               
            }
            else
            {
               // Schedule<EnemyDeath>().trujilloComponents = trujilloComponents;
            }
        }
    }
}