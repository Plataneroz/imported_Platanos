using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

public class TrujilloKartCollision : Simulation.Event<TrujilloKartCollision>
{
    public TrujilloComponets trujilloComponents;
   
    // Start is called before the first frame update
    public override void Execute()
    {
        if (trujilloComponents != null)
        {
            
            trujilloComponents.spriteEffects.StartToBlink();
             if (trujilloComponents.health.GetCurrentHP() >1) trujilloComponents.health.Decrement();
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
