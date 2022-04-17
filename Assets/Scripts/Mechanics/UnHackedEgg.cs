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
        float Timer = 4;
        public bool harmFull = true;
        Rigidbody2D rigidBod;
        private IEnumerator coroutine;
        public int coroutineCounter;
        public float speedLimit = 12;
        public float launchAngleLimit = 70;
        public float forHowLongIsItDangerous = 6;
        float random;
        bool explode;
        Explosion explosion;
        // Start is called before the first frame update
        void Start()
        {
            //explosion = GetComponent<Explosion>();
            coroutine = WaitForActions(Random.Range(1, forHowLongIsItDangerous));
            StartCoroutine(coroutine);
            rigidBod = GetComponent<Rigidbody2D>();
            transform.eulerAngles = new Vector3(0, 0, Random.Range(30, launchAngleLimit));
            rigidBod.velocity = transform.right * Random.Range(8, speedLimit);

            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.red;

        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null & harmFull)
            {
                if (player.playerRestTime.canHarmPlayer)
                {
                    // Rigidbody2D rb = collision.rigidbody;



                    //   rb.AddForce(new Vector2(3, 3), ForceMode2D.Force);
                    player.playerHealthComponents.Decrease();
                    player.playerRestTime.CantHurtPlayer();
                    
                    //player.Bounce(3);
                    if (!player.playerHealthComponents.IsAlive)
                    { Schedule<PlayerDeath>(); //Debug.Log("you dead");
                                               }
                    else
                    {
                        StartCoroutine(player.spriteEffects.Blink());
                        //player.lifeBar.ChangeSprite();
                    }

                }

            }
            else if (gameObject.layer == 7)
            {
                if (collision.collider.tag == "Ground")
                { Destroy(gameObject, .01f); }


                else if (collision.collider.tag == "Boss")
                {
                    var eggNBossColliding = Schedule<EggAndTrujilloCollision>();
                    eggNBossColliding.trujilloComponents = collision.gameObject.GetComponent<TrujilloComponets>();
                    Destroy(gameObject, .01f);
                }

                else if (collision.collider.tag == "Minion")
                {
                    var mionNBossColliding = Schedule<EggAndMionionCollision>();
                    mionNBossColliding.minionComponets = collision.gameObject.GetComponent<MinionComponets>();
                    Destroy(gameObject, .01f);
                }

                else if (collision.collider.tag == "Kart")
                {
                    var eggAndKartCollision = Schedule<EggAndKartCollision>();
                    eggAndKartCollision.kartComponents = collision.gameObject.GetComponent<KartComponents>();
                    Destroy(gameObject, .01f);
                }

            }
        }



        public IEnumerator WaitForActions(float waitTime)
        {
            while (true)
            {
                explode =! explode;
             
                yield return new WaitForSeconds(6);
                explode = !explode;
                ChangeColor();
                NotHarmfull();
                
                
                StopAllCoroutines();

            }
        }


        void HatchEgg()
        {
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