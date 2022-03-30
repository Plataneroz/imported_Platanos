using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class MinionColliding : MonoBehaviour
    {

        MinionComponets minionComponets;
        

        private void Start()
        {
            minionComponets = GetComponent<MinionComponets>();
        }
        // Start is called before the first frame update
        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var minionAndPlayerCollision = Schedule<MinionAndPlayerCollision>();
                minionAndPlayerCollision.player = player;
            }



        }

    }
}