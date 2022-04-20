using System.Collections;
using UnityEngine;


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
         public CapsuleCollider2D playerCCCollider;
         public BoxCollider2D palyerBoxCollider;
         public PlayerController playerController;

        private void Start()
        {
            playerCCCollider = GetComponent<CapsuleCollider2D>();

        }
        //public  SpriteRenderer sprite;
        public GameObject currentColliderGameObj;

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (!playerCCCollider.enabled) return;
            if (collision.tag == "unhackedEgg" && ColliderRigidBod == null)
            {   if(collision.transform.parent != null)
                {
                    collision.transform.root.GetComponent<HandleObj>().DropObj();
                }
                // collision.gameObject.transform.parent.gameObject
                Grab(collision);


            }
            else if (collision.tag == "peal")
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
        public void Grab(Collider2D collision)
        {
            Debug.Log(collision.gameObject.tag);
            currentColliderGameObj = collision.gameObject;
            collision.GetComponent<SpriteRenderer>().sortingOrder = 5;
            if (currentColliderGameObj.tag == "peal")
            { palyerBoxCollider = collision.GetComponent<BoxCollider2D>();
              palyerBoxCollider.isTrigger = true;
              playerController = collision.GetComponent<PlayerController>();  
            }
            pickedUpObjCapCollider = collision.GetComponent<CapsuleCollider2D>();
            ColliderRigidBod = collision.attachedRigidbody;
            pickedUpObjTrans = collision.transform;
            FollowingPlayer();
        }
        public void FollowingPlayer()
        {

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
                //playerCCCollider = null;
                pickedUpObjTrans = null;
                ColliderRigidBod = null;
            }
        }

        public void Throwing(int distance)
        {
            if (ColliderRigidBod != null)
            {

               // currentColliderGameObj.tag = "pickUpObj";
                currentColliderGameObj.gameObject.layer = 7;
                ColliderRigidBod.isKinematic = false;
                //physic.ignoreCollision not working here
                StartCoroutine(ChangeTriggerToFalse());
                //pickedUpObjCapCollider.isTrigger = false;
                pickedUpObjTrans.position = transform.GetChild(0).position;
                pickedUpObjTrans.eulerAngles = transform.GetChild(0).transform.eulerAngles;
                ColliderRigidBod.velocity = transform.GetChild(0).transform.right * distance;
                pickedUpObjTrans.parent = null;
                pickedUpObjTrans = null;
                ColliderRigidBod = null;
                if (playerController != null) {

                    Debug.Log("Thrwoing it ");
                    palyerBoxCollider.isTrigger = false;
                    playerController.bananaPeal.RevivePlatano();
                   // playerController.playerHealthComponents.Increase();
                    playerController = null;
                    palyerBoxCollider = null;
                }
            }


        }

        public IEnumerator ChangeTriggerToFalse()
        {

            yield return new WaitForSeconds(0.05f);
            pickedUpObjCapCollider.isTrigger = false;
           // playerCCCollider.isTrigger = false;
 
        }

    }




}
