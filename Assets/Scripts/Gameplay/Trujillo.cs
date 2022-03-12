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
       
        public Transform playerTransform;
        float Timer =2;
        float bossSpeed;
        BossSprite bossSprite;
        float xOffset = 0.25777f;
        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(playerTransform.position.x,
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
           public float DetermineSpeed()
        {
            // offset is changed ever 3 seconds 
            float speed = 0;
            var distanceFromPlayer = Vector2.Distance(transform.position, playerTransform.position);
            if (distanceFromPlayer <= 8) { speed = 12; }
            else if (distanceFromPlayer <= 10) { speed = 8; }
            else if (distanceFromPlayer <= 14) { speed = 6; }

            return speed;
        }
         public   void MoveTowardsPlayer(float speed )
        {
            
            var enemyDirection = transform.InverseTransformPoint(playerTransform.position);
            if ( transform.position.x == xOffset || 0.25777f == xOffset)
            {
                
                if (enemyDirection.x < 0) { xOffset = playerTransform.position.x - 7; bossSprite.FlipSprite(); }
                else if (enemyDirection.x > 0) { xOffset = playerTransform.position.x + 7; bossSprite.FlipSprite(); }
            }

  
            var targetPositon = new Vector2(xOffset, playerTransform.position.y);
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