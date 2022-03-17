using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay { 
public class BossAndPlayerCollision : MonoBehaviour
{
        public float xOffset = 2;
        public float yOffset = 3;
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
                    StartCoroutine(player.spriteEffects.Blink());
                   player.Teleport(new Vector3(player.transform.position.x + xOffset,
                          player.transform.position.y + yOffset, 0));
                    player.lifeBar.ChangeSprite(); }
                //
            }
    }
}

}