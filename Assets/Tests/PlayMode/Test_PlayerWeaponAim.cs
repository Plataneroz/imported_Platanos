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

    [UnityTest]
    public IEnumerator Test_HandleAiming()
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
        yield return new WaitForEndOfFrame();

        // having difficulties testing camera.ScreenToWroldPoint
        //it always returns (0,0,0)

        /*
        var root = new GameObject();
        // Attach a camera to our root game object.
        root.AddComponent(typeof(Camera));
        // Get a reference to the camera.
        var cam = root.GetComponent<Camera>();
        cam.tag = "MainCamera";
        cam.name = "Main Camera";
        //GameObject.Instantiate(cam);
        
        playerWeaponAimWithComponent.cam = cam;
    
            playerWeaponAimWithComponent.transform.position = new Vector3(3.7f, -0.3976121f, 1);
            playerWeaponAimWithComponent.HandleAiming(new Vector2(80, 262), "Mouse");
            Assert.AreEqual(playerWeaponAimWithComponent.gunAim.eulerAngles.z, 180, "aiming Mouse  left  is not giving the correct angle");
     
        playerWeaponAimWithComponent.HandleAiming(new Vector2(808, 552), "Mouse");
        Assert.AreEqual(playerWeaponAimWithComponent.gunAim.eulerAngles.z, 90.4, "aiming Mouse up is not giving the correct angle");
        playerWeaponAimWithComponent.HandleAiming(new Vector2(812, 1), "Mouse");
        Assert.AreEqual(playerWeaponAimWithComponent.gunAim.eulerAngles.z, 270, "aiming Mouse to down is not giving the correct angle");
        playerWeaponAimWithComponent.HandleAiming(new Vector2(1593, 292), "Mouse");
        Assert.AreEqual(playerWeaponAimWithComponent.gunAim.eulerAngles.z, 360, "aiming Mouse to  right is not giving the correct angle");
        */
        }


}
