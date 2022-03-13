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
    GameObject trujillo;
    Trujillo trujilloWithComponent;
    GameObject playerobj;
    Transform playerTransform;
    bool stop = false;
    void Init()
    {
         playerobj = new GameObject();
         trujillo = new GameObject();
         trujilloWithComponent = trujillo.AddComponent<Trujillo>();
         playerTransform = playerobj.transform;
    }

    [Test]
    public void Test_DetermineSpeed()
    {
        Init();
        

        trujilloWithComponent.transform.position = new Vector3(5, 5, 0);
        playerTransform.position = new Vector3(3, 5, 0);
        trujilloWithComponent.playerTransform = playerTransform;
        determinedSpeed = trujilloWithComponent.DetermineSpeed();
        Assert.AreEqual(determinedSpeed, 12, "the distance between the player and boss is under 8 and the speed its returning is not 12");

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
    [UnityTest]
    public IEnumerator Test_MoveTowardsPlayer()
    {
        Init();
        playerTransform.position = new Vector3(200,1,0);
        trujilloWithComponent.transform.position = new Vector3(13, 1,0);
        trujilloWithComponent.xOffset = 13;
        trujilloWithComponent.playerTransform = playerTransform;
        var bossSpriteObj = new GameObject();
        trujilloWithComponent.bossSprite =  bossSpriteObj.AddComponent<BossSprite>();
        trujilloWithComponent.bossSprite.spriteRenderer = bossSpriteObj.AddComponent<SpriteRenderer>();

       

        trujilloWithComponent.MoveTowardsPlayer(1);
        yield return new WaitForSeconds(1);
        Assert.AreEqual(trujilloWithComponent.transform.position.x, playerTransform.position.x, "trjuillo is not moving in the positive direction towards player");
        Assert.AreEqual(trujilloWithComponent.xOffset,playerTransform.position.x + 7 , "Trujillo's is xoffset is not being set to positivie 7");

        
        playerTransform.position = new Vector3(-13, 1, 0);
        trujilloWithComponent.transform.position = new Vector3(200, 1, 0);
        trujilloWithComponent.xOffset = 200;
        trujilloWithComponent.MoveTowardsPlayer(1);
        yield return new WaitForSeconds(1);
        Assert.AreEqual(trujilloWithComponent.transform.position.x, playerTransform.position.x, "trjuillo is not moving in the positive direction towards player");
        Assert.AreEqual(trujilloWithComponent.xOffset, playerTransform.position.x - 7, "Trujillo's is xoffset is not being set to negative 7");
    }
}