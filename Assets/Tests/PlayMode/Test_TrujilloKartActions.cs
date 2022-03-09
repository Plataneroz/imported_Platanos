using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine;
using Platformer.Gameplay;
using Platformer.Model;

public class Test_TrujilloKartActions
{
    
    [UnityTest]
    public IEnumerator Test_TrujilloKartFollowingPlayer()
    {
        var stop = false;

        GameObject TrujilloKartObj = new GameObject();
        GameObject player = new GameObject();
        player.transform.position = new Vector3(2,3,0);
        var trujilloKart = TrujilloKartObj.AddComponent<TrujilloKartActions>() ;
        trujilloKart.playerTrans = player.transform;


        while ( !stop)
        {
            trujilloKart.MoveTowardsPlayer(1, 1);
            yield return new WaitForSeconds(2); 
            stop = true;
        }

        Assert.True(trujilloKart.transform.position.x >1,"Trujillo Kar does not move towards player");

    }
}
