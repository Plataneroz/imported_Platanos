using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
namespace Platformer.Gameplay
{
    public class EggAndKartCollision : Simulation.Event<EggAndKartCollision>
    {
       public  KartComponents kartComponents;
        // Start is called before the first frame update
        public override void Execute()
        {
            if (kartComponents != null)
            {
                kartComponents.kartStatus.IncreaseHit();
                kartComponents.spriteEffects.StartToBlink();
               // Debug.Log("how often getting hit :" + kartComponents.kartStatus.hitCounter);
                if (kartComponents.kartStatus.hitCounter == 4)
                {
                    kartComponents.activiatePhase.One();
                }

                else if (kartComponents.kartStatus.hitCounter == 7)
                {
                    kartComponents.activiatePhase.Two();   
                }

                else if (kartComponents.kartStatus.hitCounter == 9)
                {
                    kartComponents.activiatePhase.Three();
                }
            }

        }
    }
}