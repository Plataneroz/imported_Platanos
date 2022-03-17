using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{
    public class SamuraiMovement : MonoBehaviour
    {
        public Transform farEnd;
        private Vector3 frometh;
        private Vector3 untoeth;
        private float secondsForOneLength = 5f;
        float distanceBetweenPoints;
        SpriteRenderer spriteRen;
        float lastXVal;
        void Start()
        {
            frometh = transform.position;

            var endPoint = new Vector3(farEnd.position.x, transform.position.y, transform.position.z);
            untoeth = endPoint;
            spriteRen = GetComponent<SpriteRenderer>();

        }

        void Update()
        {
            if (transform.position.x < lastXVal)
            {
                spriteRen.flipX = true;
                lastXVal = transform.position.x;
            }

            else if (transform.position.x > lastXVal)
            {


                spriteRen.flipX = false;
                lastXVal = transform.position.x;
            }

            transform.position = Vector3.Lerp(frometh, untoeth,
             Mathf.SmoothStep(0f, 1f,
              Mathf.PingPong(Time.time / secondsForOneLength, 1f)
            ));
            
        }

       /* void OnCollisionEnter2D(Collision2D collision)
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
                    player.lifeBar.ChangeSprite();
                }
                //
            }
        }*/
    }
}