using Platformer.Core;
using Platformer.GamePlay;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player health reaches 0. This usually would result in a 
    /// PlayerDeath event.
    /// </summary>
    /// <typeparam name="HealthIsZero"></typeparam>
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;
       // public PlayerController playerController;
        public override void Execute()
        {
            var plyr = health.GetComponent<Player>();
            if (plyr != null)
            {
                plyr.bananaPeal.enabled = true;
                 Schedule<PlayerDeath>();

            }


        }
    }
}