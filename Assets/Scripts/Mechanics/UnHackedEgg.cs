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


        // Start is called before the first frame update
        void Start()
        {
            coroutine = WaitForActions(1);
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
        // Update is called once per frame

        // method some harmful others not 

       public void ChangeColor(int timer)
        {
            if (timer >= 4)
            {
                if (spriteRenderer.color != Color.white)
                {   // some red other not 
                    harmFull = false;
                    spriteRenderer.color = Color.white;
                    Timer = 3;
                    // call cracking animation
                    harmFull = false;
                }
               
            }
        }


        void HatchEgg() { }

        public IEnumerator WaitForActions(float waitTime)
        {  
            while (true)
            {
                    yield return new WaitForSeconds(waitTime);
                    coroutineCounter++;
                    ChangeColor(coroutineCounter);
                    if(coroutineCounter == 4) { harmFull = false; }
                    else if (coroutineCounter == 7) { HatchEgg(); StopCoroutine(coroutine); }

            }
           
        }



    }
}

/* Timer -= Time.deltaTime;
            if (Timer <= 0 )
            {
                if (spriteRenderer.color != Color.white)
                {
                    harmFull = false;
                    spriteRenderer.color = Color.white;
                    Timer = 3;
                    // call cracking animation
                    harmFull = false;
                }
                else {
                    // hatch
                }
            }*/