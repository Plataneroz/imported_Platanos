using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer.Mechanics
{

    /// <summary>
    /// Grab should be used on player  
    /// A simple controller for enemies. Provides movement control over a patrol path.Gr</summary>
    /// player should be able to pick diff objs that
    /// have diff attacks
    public class HandleObj : MonoBehaviour
    {
         public Transform pickedUpObjTrans;
         public Rigidbody2D ColliderRigidBod;
         public CapsuleCollider2D pickedUpObjCapCollider;
        
         public CapsuleCollider2D playerCapsuleCollider;
         public Player plyrControl;
        bool triggerGrab;

 
        //public  SpriteRenderer sprite;
        public GameObject currentColliderGameObj;

        void OnCollisionEnter2D(Collision2D collision)

        {
            // print(triggerGrab);
            if (!triggerGrab) return;
            if (collision.gameObject.tag == "unhackedEgg" && ColliderRigidBod == null)
            {   if(collision.transform.parent != null)
                {
                    collision.transform.root.GetComponent<HandleObj>().DropObj();
                }
                // collision.gameObject.transform.parent.gameObject
                Grab(collision);
            }
            else if (collision.gameObject.tag == "peal")
            {
                Grab(collision);
            }
        }

        public void SetAllCollidersStatus(bool active)
        {
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = active;
            }
        }
        public void Grab(Collision2D collision)
        {
            
            currentColliderGameObj = collision.gameObject;
            //collision.collider.GetComponent<SpriteRenderer>().sortingOrder = 5;
            if (currentColliderGameObj.tag == "peal")
            { playerCapsuleCollider = collision.collider.GetComponent<CapsuleCollider2D>();
              playerCapsuleCollider.isTrigger = true;
                currentColliderGameObj.gameObject.layer = 16;
                plyrControl = collision.collider.GetComponent<Player>();
                currentColliderGameObj.tag = "Player";
            }
            pickedUpObjCapCollider = collision.collider.GetComponent<CapsuleCollider2D>();
            ColliderRigidBod = collision.collider.attachedRigidbody;
            pickedUpObjTrans = collision.transform;
            FollowingPlayer();
        }
        public void FollowingPlayer()
        {
            ColliderRigidBod.velocity = new Vector2(0,0);
            ColliderRigidBod.isKinematic = true;
         
            pickedUpObjTrans.SetParent(transform.GetChild(0), true);
            pickedUpObjTrans.localPosition = new Vector3(.05f, .05f, 0);
            pickedUpObjCapCollider.isTrigger = true;

        }

        public void DropObj()
        {
            //option to drop incase of dangerous 
            if (ColliderRigidBod != null)
            {
                pickedUpObjCapCollider = null;
                pickedUpObjTrans = null;
                ColliderRigidBod = null;
            }
        }

        public void Throwing(int distance)
        {
            if (ColliderRigidBod != null)
            {
                var colVelocity = transform.GetChild(0).transform.right * distance;
                
                ColliderRigidBod.isKinematic = false;
                
                StartCoroutine(ChangeTriggerToFalse());
                pickedUpObjTrans.position = transform.GetChild(0).position;
                pickedUpObjTrans.eulerAngles = transform.GetChild(0).transform.eulerAngles;

                ColliderRigidBod.AddForce(colVelocity, ForceMode2D.Impulse);
                if (plyrControl != null)
                {
                    playerCapsuleCollider.isTrigger = false;
                    plyrControl.bananaPeal.RevivePlatano();
                    currentColliderGameObj.gameObject.layer = 6;
                    StartCoroutine(ResetPlayer(colVelocity));
                }
                else
                {
                    currentColliderGameObj.gameObject.layer = 7;
                    ColliderRigidBod = null;
                }
                pickedUpObjTrans.parent = null;
                pickedUpObjTrans = null;
             
            }
        }

        public IEnumerator ChangeTriggerToFalse()
        {
            yield return new WaitForSeconds(0.05f);
            pickedUpObjCapCollider.isTrigger = false;
        }


        public IEnumerator ResetPlayer(Vector2 velocity)
        {
            yield return new WaitForSeconds(2f);

            plyrControl.transform.eulerAngles = new Vector3(0, 0, 0);
            //plyrControl.velocity = new Vector2(0, 0);

            playerCapsuleCollider = null;
            ColliderRigidBod = null;
            plyrControl = null;
        }

        public void OnGrab(InputAction.CallbackContext context)
        {
            print("grabbbbb");
            
            if (!context.canceled) { triggerGrab = true; }
            else { triggerGrab = false; }
        }

        public void OnThrow(InputAction.CallbackContext context)
        {
            print("Trhwoooo");
            if (context.started) { Throwing(14); }

        }


    }

}
