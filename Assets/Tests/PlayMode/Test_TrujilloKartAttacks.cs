using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using Platformer.Gameplay;
using Platformer.Model;

public class Test_TrujilloKartAttacks
{
    
    [UnityTest]
    public IEnumerator Test_TrujilloKartThrwoingEggs()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] objs = scene.GetRootGameObjects();
        var stop = false;
        GameObject eggs = new GameObject();
        GameObject TrujilloKartObj = new GameObject();
        var trujilloKartAttack = TrujilloKartObj.AddComponent<TrujilloKartAttack>() ;
        trujilloKartAttack.eggs = eggs;
     
        while ( !stop)
        {
            trujilloKartAttack.CreateEggs(2);
            yield return null; 
            stop = true;
        }
     
        Assert.AreEqual(eggs.transform.position.y,2, "egg is not being offset in the y");
        Assert.AreEqual(objs.Length, 3, "trujillo kart did not create a clone");
    }
}
