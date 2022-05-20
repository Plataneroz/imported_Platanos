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
        public bool invisible;
        // Start is called before the first frame update
        public override void Execute()
        {
            if (trujilloComponents != null)
            {
               if(!invisible) trujilloComponents.health.Decrement();
                trujilloComponents.spriteEffects.StartToBlink();
                
                 if (trujilloComponents.health.GetCurrentHP() == 4)
                {
                    trujilloComponents.activiatePhase.Three();
                    trujilloComponents.trujilloAnimatorController.AnimatePhaseThree();
                }

                else if (trujilloComponents.health.GetCurrentHP() == 7)
                {
                    trujilloComponents.activiatePhase.Two();
                    trujilloComponents.trujilloAnimatorController.AnimatePhaseTwo();
                }

                else if (trujilloComponents.health.GetCurrentHP() == 9)
                {

                    // call trujillo
                    trujilloComponents.activiatePhase.One();
                    trujilloComponents.trujilloAnimatorController.AnimatePhaseOne();

                }


            }

        }

        
    }
}