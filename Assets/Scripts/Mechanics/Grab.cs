
using UnityEngine;


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
        public Rigidbody2D ColliderRigidBod;
        public CapsuleCollider2D pickedUpObjCapCollider;
        //public  SpriteRenderer sprite;
        public GameObject currentColliderGameObj;

        void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.tag == "unhackedEgg" && ColliderRigidBod == null)
            {
                currentColliderGameObj = collision.gameObject;
                collision.GetComponent<SpriteRenderer>().sortingOrder = 5;
                pickedUpObjCapCollider = collision.GetComponent<CapsuleCollider2D>();
                ColliderRigidBod = collision.attachedRigidbody;
                pickedUpObjTrans = collision.transform;
                FollowingPlayer();

            }
        }

        public void FollowingPlayer()
        {
 
                ColliderRigidBod.isKinematic = true;
                pickedUpObjTrans.SetParent(transform.GetChild(0), false);
                pickedUpObjTrans.localPosition = new Vector3(.05f, .05f, 0);
                pickedUpObjCapCollider.isTrigger = true;
            
        }

       public void DropObj()
        {
            //option to drop incase of dangerous 
            if (ColliderRigidBod != null)
            {
                ColliderRigidBod.isKinematic = false;
                pickedUpObjCapCollider.isTrigger = false;
                pickedUpObjTrans.parent = null;
                pickedUpObjTrans = null;
                ColliderRigidBod = null;
            }
        }

        public void Throwing( int distance)
        {
            if (ColliderRigidBod != null)
            {
                currentColliderGameObj.tag = "pickUpObj";
                currentColliderGameObj.gameObject.layer = 7;
                ColliderRigidBod.isKinematic = false;
                //pickedUpObjCapCollider.isTrigger = false;
                pickedUpObjTrans.position = transform.GetChild(0).position;
                pickedUpObjTrans.eulerAngles = transform.GetChild(0).transform.eulerAngles;
                ColliderRigidBod.velocity = transform.GetChild(0).transform.right * distance;
                pickedUpObjTrans.parent = null;
                pickedUpObjTrans = null;
                ColliderRigidBod = null;
            }
        }

    }





}
