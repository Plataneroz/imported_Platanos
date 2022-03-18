using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class BossAndPlayerCollide : MonoBehaviour
    {
        public float xOffset = 2;
        public float yOffset = 3;
        // Start is called before the first frame update
        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var bossAndPlayerCollision = Schedule<BossAndPlayerCollision>();
                bossAndPlayerCollision.player = player;
            }
        }

    }
}