using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.Gameplay;

public class TrujilloComponets : MonoBehaviour
{
    public Health health;
    public BossSprite bossSprite;
    public ActivateTrujillo activateTrujillo;

    private void Start()
    {
        health = GetComponent<Health>();
        bossSprite = GetComponent<BossSprite>();
        activateTrujillo = GetComponent<ActivateTrujillo>();
    }
}
