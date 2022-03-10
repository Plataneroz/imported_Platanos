using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Gameplay;
namespace Platformer.Mechanics
{
    public class UnHackedEgg : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        float Timer= 4 ;
         public  bool harmFull = true;
        Rigidbody2D rigidBod;
        private IEnumerator coroutine;
        public int coroutineCounter;
        public bool triggerAction= true;
        float random; 
        // Start is called before the first frame update
        void Start()
        {
            coroutine = WaitForActions(Random.Range(4, 10.0f));
            StartCoroutine(coroutine);
            rigidBod = GetComponent<Rigidbody2D>();
            rigidBod.velocity = transform.right * 5;
            transform.eulerAngles = new Vector3(0, 0, 39);
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.red;

        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null & harmFull)
            {
                Schedule<PlayerDeath>();
            }
            if (gameObject.layer == 7)
            {
                if (collision.collider.tag == "Ground" )
                { Destroy(gameObject, .5f); }


                else if (collision.collider.tag == "Boss")
                {
                 var eggNBossColliding = Schedule<EggAndBossCollision>();
                 eggNBossColliding.enemy = collision.gameObject.GetComponent<EnemyController>();
                    Destroy(gameObject, .5f);
                }
            }    
        }
     


        public IEnumerator WaitForActions(float waitTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                ChangeColor();
                NotHarmfull();
                StopAllCoroutines();
                /* yield return new WaitForSeconds();
                 HatchEgg();
                 StopAllCoroutines();*/
            }
        }

        
        void HatchEgg() {
            // hurt enemy when hatch
        }


        public void NotHarmfull()
        {
            harmFull = false;
        }


        public void ChangeColor()
        {
                if (spriteRenderer.color != Color.white)
                {   
                    spriteRenderer.color = Color.white;
                    
                }
        }
        


        





    }
}
