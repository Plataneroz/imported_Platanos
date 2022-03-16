using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay { 
public class TrujilloCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
                
                player.health.Decrement();
                

            if (!player.health.IsAlive) { Schedule<PlayerDeath>(); }
                else
                {
                    player.Teleport(new Vector3(player.transform.position.x + 4,
                          player.transform.position.y + 3, 0));
                    player.lifeBar.ChangeSprite(); }
                //
            }
    }
}

}