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
        BossSprite bossSprite;
        [SerializeField]
        float speed =1;
        // Start is called before the first frame update
        void Start()
        {
            bossSprite =  gameObject.GetComponent<BossSprite>();
            
          
        }

        // Update is called once per frame
        void Update()
        {
            MoveTowardsPlayer(1,1);
        }
       

        void GetReadyToAttack() { bossSprite.ChangeSprite(); }

        public void MoveTowardsPlayer(float speed, float xOffset)
        {
            var targetPositon = new Vector2(playerTrans.position.x + xOffset, playerTrans.position.y);
            transform.position = Vector2.MoveTowards(transform.position,
            targetPositon, speed * Time.deltaTime);
        }
    }
}