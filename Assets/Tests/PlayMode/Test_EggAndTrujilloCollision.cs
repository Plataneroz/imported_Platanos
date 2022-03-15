using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine;
//using UnityEngine.InputSystem;
using Platformer.Mechanics;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

public class Test_EggAnTruilloCollison
{
    
    [UnityTest]
    public IEnumerator Test_MoveTowardsPlayer()
    {
        
        GameObject trujilloComponents = new GameObject();
        trujilloComponents.AddComponent<TrujilloComponets>();
        trujilloComponents.AddComponent<Health>().maxHP = 10;
        trujilloComponents.AddComponent<BossSprite>();
        trujilloComponents.AddComponent<ActivateTrujillo>();

        
        var eggAndTrujilloCollision = Schedule<EggAndTrujilloCollision>();
        eggAndTrujilloCollision.trujilloComponents = trujilloComponents.GetComponent<TrujilloComponets>();
        

        yield return  null;
    }


}