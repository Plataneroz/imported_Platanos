using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{

        /// <summary>
        /// Grab should be used on player  
        /// A simple controller for enemies. Provides movement control over a patrol path.Gr</summary>
        /// player should be able to pick diff objs that
        /// have diff attacks
        public class Grab : MonoBehaviour
        {

       
        public Transform pickedUpObjTrans;
        Rigidbody2D rigid;
        CapsuleCollider2D pickedUpObjCapCollider;
        private SpriteRenderer sprite;
        GameObject currentColliderGameObj;

        void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.tag == "unhackedEgg" && rigid == null)
            {
                currentColliderGameObj = collision.gameObject;
                collision.GetComponent<SpriteRenderer>().sortingOrder = 5;
                pickedUpObjCapCollider = collision.GetComponent<CapsuleCollider2D>();
                rigid = collision.attachedRigidbody;
                pickedUpObjTrans = collision.transform;
                followingPlayer();

            }
        }

        void followingPlayer()
        {
 
                rigid.isKinematic = true;
                pickedUpObjTrans.SetParent(transform.GetChild(0), false);
                pickedUpObjTrans.localPosition = new Vector3(.05f, .05f, 0);
                pickedUpObjCapCollider.isTrigger = true;
            
        }

       public void DropObj()
        {
            //option to drop incase of dangerous 
            if (rigid != null)
            {
                rigid.isKinematic = false;
                pickedUpObjCapCollider.isTrigger = false;
                pickedUpObjTrans.parent = null;
                pickedUpObjTrans = null;
                rigid = null;
            }
        }

        public void Throwing( int distance)
        {
            if (rigid != null)
            {
                currentColliderGameObj.tag = "pickUpObj";
                currentColliderGameObj.gameObject.layer = 7;
                rigid.isKinematic = false;
                pickedUpObjCapCollider.isTrigger = false;
                pickedUpObjTrans.position = transform.GetChild(0).position;
                pickedUpObjTrans.eulerAngles = transform.GetChild(0).transform.eulerAngles;
                rigid.velocity = transform.GetChild(0).transform.right * distance;
                pickedUpObjTrans.parent = null;
                pickedUpObjTrans = null;
                rigid = null;
            }
        }

    }





}
