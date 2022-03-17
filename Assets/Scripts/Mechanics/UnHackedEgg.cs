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
        public float speed = 7;
        public float launchAngle = 60;
        public float secondUntilSafeToGrab = 6;
        float random; 
        // Start is called before the first frame update
        void Start()
        {
            coroutine = WaitForActions(Random.Range(1, secondUntilSafeToGrab));
            StartCoroutine(coroutine);
            rigidBod = GetComponent<Rigidbody2D>();
            transform.eulerAngles = new Vector3(0, 0, launchAngle);
            rigidBod.velocity = transform.right * speed;
            
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.red;

        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null & harmFull)
            {
                player.health.Decrement();
                player.Bounce(10);
                if (!player.health.IsAlive) { Schedule<PlayerDeath>(); }
                else { player.lifeBar.ChangeSprite(); }
            }
            if (gameObject.layer == 7)
            {
                if (collision.collider.tag == "Ground" )
                { Destroy(gameObject, .5f); }


                else if (collision.collider.tag == "Boss")
                {
                 var eggNBossColliding = Schedule<EggAndTrujilloCollision>();
                 eggNBossColliding.trujilloComponents = collision.gameObject.GetComponent<TrujilloComponets>();
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
