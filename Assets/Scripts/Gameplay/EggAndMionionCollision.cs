using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class EggAndMionionCollision : Simulation.Event<EggAndMionionCollision>
    {
         public MinionComponets minionComponets;
        // Start is called before the first frame update
        public override void Execute()
        {
            if(minionComponets != null)
            {
                minionComponets.health.Decrement();
                minionComponets.spriteEffects.Blink();
                if(minionComponets.health.GetCurrentHP() <= 0)
                {
                    minionComponets.health.Die();
                }
            }
        }
    }
}