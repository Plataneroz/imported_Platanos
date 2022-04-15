using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Explosion : MonoBehaviour
    {
        public float radius = 5.0F;
        public float power = 10.0F;

        public void Begin()
        {
            Debug.Log("boooom");
            Vector2 explosionPos = transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius,6);
            foreach (Collider2D obj in colliders)
            {
                Debug.Log(obj.tag);

                }
                

            
            
        }

        void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, radius);
        }

        public void Update()
        {
            
        }
    }
}