using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    public class TrujilloKartActions : MonoBehaviour
    {
       // public PlatformerModel model  = Simulation.GetModel<PlatformerModel>();;
        //[SerializeField]
        public Transform playerTrans;
        SpriteEffects spriteEffects;
        [SerializeField]
        float speed =1;
        public bool stopMovement;
        // Start is called before the first frame update
        void Start()
        {
            spriteEffects = gameObject.GetComponent<SpriteEffects>(); 
            
          
        }

        // Update is called once per frame
        void Update()
        {
            if (!stopMovement)
            {
                MoveTowardsPlayer(1, 1);
            }
        }
       

       // void GetReadyToAttack() { spriteEffects.ChangeSprite(); }

        public void MoveTowardsPlayer(float speed, float xOffset)
        {
            var targetPositon = new Vector2(playerTrans.position.x + xOffset, playerTrans.position.y);
            transform.position = Vector2.MoveTowards(transform.position,
            targetPositon, speed * Time.deltaTime);
        }
    }
}