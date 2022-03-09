using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
namespace Platformer.Gameplay
{
    public class Trujillo : MonoBehaviour
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        float Timer =2;
        float bossSpeed;
        BossSprite bossSprite;
        float xOffset = 0.25777f;
        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(model.player.transform.position.x,
                  transform.position.y + 4);
            bossSprite = gameObject.GetComponent<BossSprite>();
            Invoke("GetReadyToAttack", 2);

        }

        // Update is called once per frame
        void Update()
        {
            bossSpeed = DetermineSpeed();
            MoveTowardsPlayer(bossSpeed);  
        }
            float DetermineSpeed()
        {
            // offset is changed ever 3 seconds 
            float speed = 0;
            var distanceFromPlayer = Vector2.Distance(transform.position, model.player.transform.position);
            if (distanceFromPlayer <= 8) { speed = 12; }
            else if (distanceFromPlayer <= 10) { speed = 8; }
            else if (distanceFromPlayer <= 14) { speed = 6; }
           // else if (distanceFromPlayer <= 10){ speed = 1; }
            //Debug.Log("Player speed: " + speed );
            return speed;
        }
            void MoveTowardsPlayer(float speed )
        {
            
            var enemyDirection = transform.InverseTransformPoint(model.player.transform.position);
            if ( transform.position.x == xOffset || 0.25777f == xOffset)
            {
                
                if (enemyDirection.x < 0) { xOffset = model.player.transform.position.x - 7; bossSprite.FlipSprite(); }
                else if (enemyDirection.x > 0) { xOffset = model.player.transform.position.x + 7; bossSprite.FlipSprite(); }
            }

            Debug.Log("Player offset :" + xOffset);
            var targetPositon = new Vector2(xOffset, model.player.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position,
            targetPositon , speed * Time.deltaTime);
            ResetTimerForXOffset();
        }
        void ResetTimerForXOffset()
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Timer = 2;
            }

        }
        void GetReadyToAttack() {bossSprite.ChangeSprite();}
    }
}