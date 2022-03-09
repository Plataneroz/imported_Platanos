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
    public void Test_UnhackedEggSimplePasses()
    {
        
        GameObject unHacked = new GameObject();
        var unHackedEgg = unHacked.AddComponent<UnHackedEgg>();
        unHackedEgg.spriteRenderer = unHacked.AddComponent<SpriteRenderer>();
        unHackedEgg.spriteRenderer.color = Color.red;
        unHackedEgg.ChangeColor(4);
        Assert.AreEqual(unHackedEgg.spriteRenderer.color,Color.white);
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
 
}
