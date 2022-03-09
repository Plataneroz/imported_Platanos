using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer.Mechanics {
    public class PlayerWeaponAim : MonoBehaviour
    {
        // Start is called before the first frame update



        RaycastHit2D hit;
        // RayCastForWeapon rayCastForWeapon;
        /*  public Color c1 = Color.yellow;
          public Color c2 = Color.red;
          public int lengthOfLineRenderer = 20;
          public LineRenderer lineRenderer;
          //LineRenderer lr;
        */
        
        float angle ;
        float direction;
        Vector2 lookingDirections;
        [SerializeField]
        Transform gunAim;
        float speed = 10;
     
   

        Vector3 lookDirection;
        float lookAngle;

        private Transform crossHairTransform;
       // public float angle;
        public Transform gunPoint;
        // private Animator aimAnimator;
        // Start is called before the first frame update
        void Awake()
        {

            //rayCastForWeapon = new RayCastForWeapon();
            //gunAim = GameObject.Find("aim").transform;
           // crossHairTransform = GameObject.Find("crossHair").transform;

        }

        // Update is called once per frame
        void Update()
        {
            HandleAiming();


            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            //layerMask = ~layerMask;
            Vector3 right = gunAim.TransformDirection(Vector3.right) * 10;
            hit = Physics2D.Raycast(gunAim.position, right, 10, layerMask);
            Debug.DrawRay(gunAim.position, right, Color.green);
          

        }

        private void HandleAiming()
        {
            if (Gamepad.current != null) {
                gunAim.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(lookingDirections.y, lookingDirections.x) * 180 / -Mathf.PI); }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(lookingDirections);
                //Debug.Log("this is the mouth position " + mousePosition.normalized);
                Vector3 aimDirection = (mousePosition - transform.position).normalized;

                if (transform.localScale.x < 0)

                {
                    angle = Mathf.Atan2(-aimDirection.y, -aimDirection.x) * Mathf.Rad2Deg;
                }
                else
                {
                    angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
                }
                //send throwing object this angle 
                gunAim.eulerAngles = new Vector3(0, 0, angle);
            }
   
            
            //controllingCursor();
        }


        private void HandleAiming2()
        {
            lookDirection = Camera.main.ScreenToWorldPoint(lookingDirections);
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            gunAim.eulerAngles = new Vector3(0, 0, lookAngle);
            //controllingCursor();
        }


        public void Look(InputAction.CallbackContext context)
        {
            lookingDirections = context.ReadValue<Vector2>();
            
        }

        public void controllingCursor()
        {
            Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(lookingDirections);
            crossHairTransform.position = mouseCursorPos;
            // Debug.Log("this the mouse position :" +lookingDirections);
        }
       
   
    }
}