/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Gameplay;

namespace Platformer.Mechanics
{
  public class AttackingWithPickedUpObj : MonoBehaviour
   {
       Transform trans;
       CapsuleCollider2D cCollider;
       Rigidbody2D rigidbody2D;
       // Start is called before the first frame update
       void Start()
       {
           trans = transform;
           rigidbody2D = GetComponent<Rigidbody2D>();
           cCollider = GetComponent<CapsuleCollider2D>();
           transform.localPosition = new Vector3(.05f, .05f, 0);
           cCollider.isTrigger = true;
       }
       private void OnEnable()
       {
       }
       // Update is called once per frame
       void Update()
       {

       }

           void OnCollisionEnter2D(Collision2D collision)
       {
           if (collision.collider.tag == "Ground")
           { gameObject.SetActive(false); }


           else if (collision.collider.tag == "Boss")
           {
               var eggNBossColliding = Schedule<EggAndTrujilloCollision>();
               eggNBossColliding.trujilloComponents = collision.gameObject.GetComponent<TrujilloComponets>();
               gameObject.SetActive(false);
           }

           else if (collision.collider.tag == "Minion")
           {
               var mionNBossColliding = Schedule<EggAndMionionCollision>();
               mionNBossColliding.minionComponets = collision.gameObject.GetComponent<MinionComponets>();
               gameObject.SetActive(false);
           }

           else if (collision.collider.tag == "Kart")
           {
               var eggAndKartCollision = Schedule<EggAndKartCollision>();
               eggAndKartCollision.kartComponents = collision.gameObject.GetComponent<KartComponents>();
               gameObject.SetActive(false);
           }

       }

       private void OnDisable()
       {

       }
   }
}*/