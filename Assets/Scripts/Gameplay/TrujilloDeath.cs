using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="EnemyDeath"></typeparam>
    public class TrujilloDeath : Simulation.Event<TrujilloDeath>
    {
        public TrujilloComponets trujilloComponets;
        
        public override void Execute()
        {
           
            //trujilloComponets._collider.enabled = false;
            //enemy.control.enabled = false;
           // if (enemy._audio && enemy.ouch)
                //enemy._audio.PlayOneShot(enemy.ouch);
        }
    }
}