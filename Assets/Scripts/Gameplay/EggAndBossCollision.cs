using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class EggAndBossCollision : Simulation.Event<EggAndBossCollision>
    {
        public EnemyController enemy;
        // Start is called before the first frame update
        public override void Execute()
        {



            var enemyHealth = enemy.GetComponent<Health>();
            var bossSprite = enemy.GetComponent<BossSprite>();
            if (enemyHealth != null)
            {
                enemyHealth.Decrement();
                if (!enemyHealth.IsAlive)
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                }
                else if (enemyHealth.GetCurrentHP() == 7)
                {
                    enemy.GetComponent<AnimationController>().enabled = false;
                    // call trujillo
                    enemy.GetComponent<ActivateTrujillo>().JumpOffKartTrujillo() ;
                    bossSprite.ChangeSprite();

                }
                else if (enemyHealth.GetCurrentHP() <= 9 
                     )
                { bossSprite.ChangeSprite(); }
               
            }
            else
            {
                Schedule<EnemyDeath>().enemy = enemy;
            }
        }
    }
}