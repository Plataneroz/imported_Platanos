using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Platformer.Gameplay;
namespace Platformer.Mechanics
{ 
public class TrujilloComponets : MonoBehaviour
 {
    public Health health;
    public SpriteEffects spriteEffects;
    public ActivateTrujillo activateTrujillo;
   // public TrujilloKartActions trujilloKartActions;

         void Start()
        {
            health = GetComponent<Health>();
            spriteEffects = GetComponent<SpriteEffects>();
            activateTrujillo = GetComponent<ActivateTrujillo>();
           // trujilloKartActions = GetComponent<TrujilloKartActions>();

        }
    }
}
