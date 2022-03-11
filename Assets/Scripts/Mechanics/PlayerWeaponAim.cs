using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Platformer.Mechanics {
    public class PlayerWeaponAim : MonoBehaviour
    {
        float angle ;
        [SerializeField]
        Transform gunAim;  
        float lookAngle;
        public Transform gunPoint;

        // Update is called once per frame

        public  void HandleAiming(Vector2 lookingDirections , String device)
        {
            Debug.Log(lookingDirections);
            if (!device.Contains("Mouse")) {
                gunAim.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(lookingDirections.y, lookingDirections.x) * 180 / -Mathf.PI); }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(lookingDirections);
                Vector3 aimDirection = (mousePosition - transform.position).normalized;

                if (transform.localScale.x < 0)

                {
                    angle = Mathf.Atan2(-aimDirection.y, -aimDirection.x) * Mathf.Rad2Deg;
                }
                else
                {
                    angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
                }
                gunAim.eulerAngles = new Vector3(0, 0, angle);
            }

        }


        public void Look(InputAction.CallbackContext context)
        {

            //

            if (!context.canceled) {
                HandleAiming(context.ReadValue<Vector2>(), context.control.device.ToString());
            }

        }
    }
}