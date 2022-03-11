using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Platformer.Mechanics;


public class Test_UnhackedEgg
{
  
    // A Test behaves as an ordinary method
    [Test]
    public void Test_ChangeColor()
    {
        
        GameObject unHacked = new GameObject();
        var unHackedEgg = unHacked.AddComponent<UnHackedEgg>();
        unHackedEgg.spriteRenderer = unHacked.AddComponent<SpriteRenderer>();
        unHackedEgg.spriteRenderer.color = Color.red;
        unHackedEgg.ChangeColor();
        Assert.AreEqual(unHackedEgg.spriteRenderer.color,Color.white, "Color is not changing to white");
        // Use the Assert class to test conditions
    }


    [UnityTest]
    public IEnumerator Test_WaitForActions()
    {
        GameObject unHacked = new GameObject();
        var unHackedEgg = unHacked.AddComponent<UnHackedEgg>();
        unHackedEgg.StartCoroutine(unHackedEgg.WaitForActions(0));

        while (unHackedEgg.coroutineCounter >5)
        {
            yield return null;
        }

        Assert.IsFalse(!unHackedEgg.harmFull, "unhacked egg is still harmful ");

        unHackedEgg.StartCoroutine(unHackedEgg.WaitForActions(0));

        while (unHackedEgg.coroutineCounter > 1)
        {
            yield return null;
        }

        Assert.True(unHackedEgg.harmFull, "unhacked egg is not harmful");
    }


}
