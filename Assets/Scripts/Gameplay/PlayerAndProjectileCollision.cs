using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class PlayerAndProjectileCollision : Simulation.Event<MinionAndPlayerCollision>
    {
        public PlayerController player;
        // St art is called before the first frame update
        public override void Execute()
        {
            player.health.Decrement();


            if (!player.health.IsAlive) { Schedule<PlayerDeath>(); }
            else
            {

                // player.Teleport(new Vector3(player.transform.position.x ,
                //      player.transform.position.y + 2, 0));
                player.spriteEffects.StartToBlink();
              //  player.lifeBar.ChangeSprite();
            }
            //
        }
    }
}