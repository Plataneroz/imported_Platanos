using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
       // public EnemyController enemy;
        public PlayerController player;
       

        public override void Execute()
        {
              
              

               if (player.health.GetCurrentHP()  == 0)
              {
                  Schedule<PlayerDeath>();
              }
              else if (player.health.GetCurrentHP() <= 3)
              { player.health.Decrement(); }
        }
    }
      
 }

