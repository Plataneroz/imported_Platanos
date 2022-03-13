using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine;
//using UnityEngine.InputSystem;
using Platformer.Gameplay;

public class Test_Trujillo
{
    float determinedSpeed;
    [Test]
    public void Test_DetermineSpeed()
    {
        var playerTransform = new GameObject().transform;
        
        var trujillo = new GameObject();
        var bossSpriteObj = new GameObject();
        var trujilloWithComponent = trujillo.AddComponent<Trujillo>();
        trujilloWithComponent.playerTransform = playerTransform;
        

        trujilloWithComponent.transform.position = new Vector3(5, 5, 0);
        playerTransform.position = new Vector3(3, 5, 0);
        trujilloWithComponent.playerTransform = playerTransform;
        determinedSpeed = trujilloWithComponent.DetermineSpeed();
        Assert.AreEqual(determinedSpeed, 12,"the distance between the player and boss is under 8 and the speed its returning is not 12");

        trujilloWithComponent.transform.position = new Vector3(13, 5, 0);
        playerTransform.position = new Vector3(3, 5, 0);
        trujilloWithComponent.playerTransform = playerTransform;
        determinedSpeed = trujilloWithComponent.DetermineSpeed();
        Assert.AreEqual(determinedSpeed, 8, "the distance between the player and boss is over 10 and the speed its returning is not 8");

        trujilloWithComponent.transform.position = new Vector3(5, 5, 0);
        playerTransform.position = new Vector3(19, 5, 0);
        trujilloWithComponent.playerTransform = playerTransform;
        determinedSpeed = trujilloWithComponent.DetermineSpeed();
        Assert.AreEqual(determinedSpeed, 6, "the distance between the player and boss is over 14 and the speed its returning is not 6");
        
    }


}
