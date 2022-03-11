using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer.Mechanics {
    public class PlayerWeaponAim : MonoBehaviour
    {
        float angle ;
        Vector2 lookingDirections;
        [SerializeField]
        Transform gunAim;
        Vector3 lookDirection;
        float lookAngle;
        public Transform gunPoint;

        // Update is called once per frame
        void Update()
        {
            HandleAiming();
        }

        private void HandleAiming()
        {
            if (Gamepad.current != null) {
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
            lookingDirections = context.ReadValue<Vector2>();
            
        }
    }
}