using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
namespace Platformer.Mechanics
{
    public class MinionComponets : MonoBehaviour
    {
        public Health health; 
        public SpriteEffects spriteEffects;
        // public TrujilloKartActions trujilloKartActions;

        void Start()
        {
            spriteEffects = GetComponent<SpriteEffects>();
            health = GetComponent<Health>();
            // activiatePhase = GetComponent<ActiviatePhase>();
           // trujilloAnimatorController = GetComponent<TrujilloAnimatorController>();
        }
    }
}