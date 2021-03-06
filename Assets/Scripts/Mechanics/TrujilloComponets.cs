using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Platformer.Gameplay;
namespace Platformer.Mechanics
{ 
public class TrujilloComponets : MonoBehaviour
 {
    public Health health;
    public ActiviatePhase activiatePhase;
    public TrujilloAnimatorController trujilloAnimatorController;
        public SpriteEffects spriteEffects;
         // public TrujilloKartActions trujilloKartActions;

         void Start()
        {
            spriteEffects = GetComponent<SpriteEffects>();
            health = GetComponent<Health>();
           // activiatePhase = GetComponent<ActiviatePhase>();
            trujilloAnimatorController = GetComponent<TrujilloAnimatorController>();
        }
    }
}
