using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Platformer.Gameplay;
namespace Platformer.Mechanics
{ 
public class TrujilloComponets : MonoBehaviour
 {
    public Health health;
    public BossSprite bossSprite;
    public ActivateTrujillo activateTrujillo;
   // public TrujilloKartActions trujilloKartActions;

         void Start()
        {
            health = GetComponent<Health>();
            bossSprite = GetComponent<BossSprite>();
            activateTrujillo = GetComponent<ActivateTrujillo>();
           // trujilloKartActions = GetComponent<TrujilloKartActions>();

        }
    }
}
