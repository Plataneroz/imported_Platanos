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

        var stop = false;
        GameObject eggs = new GameObject();
        eggs.name = "eggs";
        GameObject TrujilloKartObj = new GameObject();
        var trujilloKartAttack = TrujilloKartObj.AddComponent<TrujilloKartAttack>() ;
        trujilloKartAttack.eggs = eggs;
     
        while ( !stop)
        {
            yield return null;
            stop = true;
        }
        trujilloKartAttack.CreateEggs(2);

        Scene scene = SceneManager.GetActiveScene();
        GameObject[] objs = scene.GetRootGameObjects();
        GameObject clone = GameObject.Find("eggs(Clone)");
        Assert.AreEqual(eggs.transform.position.y,2, "egg is not being offset in the y");
        Assert.IsNotNull(clone, "trujillo kart did not create a clone");
    }
}
