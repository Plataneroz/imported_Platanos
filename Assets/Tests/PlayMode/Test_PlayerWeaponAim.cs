using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine;
//using UnityEngine.InputSystem;
using Platformer.Mechanics;

public class Test_PlayerWeaponAim
{

    [Test]
    public void Test_HandleAiming()
    {
        //var gamepad = InputSystem.AddDevice<Gamepad>();
        var playerWeaponAim = new GameObject();
        var playerWeaponAimWithComponent = playerWeaponAim.AddComponent<PlayerWeaponAim>();
        playerWeaponAimWithComponent.gunAim = new GameObject().transform;
        playerWeaponAimWithComponent.HandleAiming(new Vector2(-1,0),"GamePad");
        Assert.AreEqual(playerWeaponAimWithComponent.gunAim.eulerAngles.z,180, "GamePad left input is not giving the correct angle");        
        playerWeaponAimWithComponent.HandleAiming(new Vector2(0, 1), "GamePad");
        Assert.AreEqual(playerWeaponAimWithComponent.gunAim.eulerAngles.z, 90, "GamePad up input is not giving the correct angle");
        playerWeaponAimWithComponent.HandleAiming(new Vector2(0, -1), "GamePad");
        Assert.AreEqual(playerWeaponAimWithComponent.gunAim.eulerAngles.z, 270, "GamePad down input is not giving the correct angle");
        playerWeaponAimWithComponent.HandleAiming(new Vector2(1, -0.1f), "GamePad");
        Assert.AreEqual(playerWeaponAimWithComponent.gunAim.eulerAngles.z, 354.289398f, "GamePad right input is not giving the correct angle");

    }


}
