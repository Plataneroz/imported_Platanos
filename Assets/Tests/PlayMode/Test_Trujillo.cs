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

    [Test]
    public void Test_DetermineSpeed()
    {
        var playerTransform = new GameObject().transform;
        playerTransform.position = new Vector3(3,5,0);
        var trujillo = new GameObject();
        trujillo.AddComponent<Trujillo>().playerTransform = playerTransform;
        var trujilloWithComponent = trujillo.AddComponent<Trujillo>() ;

        trujilloWithComponent.transform.position = new Vector3(5,5,0);
        trujilloWithComponent.playerTransform.position = new Vector3(10, 15, 0);

        var determinedSpeed =   trujilloWithComponent.DetermineSpeed();

        Assert.AreEqual(determinedSpeed,6);
    }


}
