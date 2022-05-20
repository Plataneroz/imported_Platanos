using System.Collections;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer.Mechanics
{

    public class HandleObj : MonoBehaviour
    {
        public float targetOffset = .7f;
        public Transform pickedUpObjTrans;
        public Rigidbody2D ColliderRigidBod;
        public CapsuleCollider2D pickedUpObjCapCollider;
        int numberOfPickedUP = 0;
        int sizeOfBasket = 10;
        Collision2D[] SavedColliders = new Collision2D[10];
        Collider[] SavedORColliders = new Collider[10];
        public CapsuleCollider2D playerCapsuleCollider;
        public Player plyrControl;
        bool triggerGrab;
        //public  SpriteRenderer sprite;
        public GameObject currentColliderGameObj;
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        AudioController audioController;
        //OnCollisionStay2d might be better for this
        private void Start()
        {

            audioController = transform.parent.GetComponent<AudioController>();

        }




            void OnCollisionEnter2D(Collision2D collision)
            {
                if (!triggerGrab) return;
                else if (numberOfPickedUP < sizeOfBasket && collision.gameObject.tag == "unhackedEgg"
                            || collision.gameObject.tag == "peal")
                {
                audioController.SuckingSound();
                collision.gameObject.SetActive(false);
                    SavedColliders[numberOfPickedUP] = collision;
                    if (SavedColliders[numberOfPickedUP].gameObject.tag == "peal")
                    {
                        plyrControl = collision.collider.GetComponent<Player>();
                        plyrControl.playerHealthComponents.ResetHP();
                        SavedColliders[numberOfPickedUP].gameObject.tag = "Player";
                    }
                    numberOfPickedUP++;
                    model.chancletaDugeon.AddToDungeon();

                    print("cuatos huevos tienes " + numberOfPickedUP);

                }
            }
          
        public void Throwing(int distance)
        {
            //print("cuatos huevos tienes before throwing" + numberOfPickedUP);
            if (numberOfPickedUP > 0)
            {
                audioController.BlowSound();
                   numberOfPickedUP--;
                model.chancletaDugeon.RemoveFromDungeon();
                var objPos = transform.position;

                var colVelocity = transform.right * distance;
                SavedColliders[numberOfPickedUP].gameObject.transform.position = new Vector3(objPos.x , objPos.y , 0);
                SavedColliders[numberOfPickedUP].gameObject.transform.eulerAngles = transform.eulerAngles;
                SavedColliders[numberOfPickedUP].gameObject.SetActive(true);
                SavedColliders[numberOfPickedUP].collider.attachedRigidbody.AddForce(colVelocity, ForceMode2D.Impulse);
                if (plyrControl != null)
                {
                    plyrControl.bananaPeal.RevivePlatano();
                    SavedColliders[numberOfPickedUP].gameObject.layer = 6;
                    StartCoroutine(ResetPlayer(colVelocity));
                }
                else
                {
                    SavedColliders[numberOfPickedUP].gameObject.layer = 7;
                    SavedColliders[numberOfPickedUP] = null;
                }
                print("cuatos huevos tienes " + numberOfPickedUP);
            }
            else { audioController.EmptySound(); }
        }


        public IEnumerator ResetPlayer(Vector2 velocity)
        {
            yield return new WaitForSeconds(.5f);
            plyrControl.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        public void OnGrab(InputAction.CallbackContext context)
        {
            //the longer its held the more you obsure 
            if (!context.canceled) { triggerGrab = true; }
            else { triggerGrab = false; }
        }

        public void OnThrow(InputAction.CallbackContext context)
        {
            if (context.started) { Throwing(14); }


        }




    }
}