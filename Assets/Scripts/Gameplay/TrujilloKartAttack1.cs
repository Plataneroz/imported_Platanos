using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    public class TrujilloKartAttack1 : MonoBehaviour
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        //PlayerController playerController;
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

        void MoveTowardsPlayer(float speed, float xOffset)
        {
            var targetPositon = new Vector2(model.player.transform.position.x + xOffset, model.player.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position,
            targetPositon, speed * Time.deltaTime);
        }
    }
}