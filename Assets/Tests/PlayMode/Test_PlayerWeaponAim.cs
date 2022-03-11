using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class Test_PlayerWeaponAim
{
    
    [UnityTest]
    public IEnumerator Test_TrujilloKartThrwoingEggs()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] objs = scene.GetRootGameObjects();
        var stop = false;
        var player = new GameObject();
        var ps4Controller = InputSystem.AddDevice<DualShockGamepad>();
        var keyboard = InputSystem.AddDevice<Keyboard>();
        var mouse = InputSystem.AddDevice<Mouse>();
        var playerInput = player.AddComponent<PlayerInput>();
        playerInput.defaultActionMap = "Gameplay";
        playerInput.defaultControlScheme = "Keyboard&Mouse";

        //var action = new InputAction(binding: "<Gamepad>/leftStick");
        //var gamepad = InputSystem.AddDevice<Gamepad>();
        //var action = new InputAction(binding: "<Gamepad>/buttonSouth", interactions: "hold");

        player.SetActive(true);
        
        player.SetActive(false); // Avoid PlayerInput grabbing devices before we have its configuration in place.
        Assert.That(playerInput.devices, Is.EquivalentTo(new InputDevice[] { keyboard, mouse }));

        while ( !stop)
        {
          
            yield return null; 
            stop = true;
        }
     
       
    }
}
