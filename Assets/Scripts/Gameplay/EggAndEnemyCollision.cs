using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    public class EggAndEnemyCollision : Simulation.Event<EggAndEnemyCollision>
    {
        // Start is called before the first frame update

        public EnemyController enemy;
        public PlayerController player;

        public override void Execute()
        {


           
                var enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<EnemyDeath>().enemy = enemy;

                    }
                    else
                    {

                    }
                }
                else
                {
                    Schedule<EnemyDeath>().enemy = enemy;

                }
            }
            
        }
    }
