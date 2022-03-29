using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Model;
public class EnemyDeath : Simulation.Event<EnemyDeath>
{
    public GameObject enemy;
    public override void Execute()
    {
        enemy.SetActive(true) ;
    }
    }
