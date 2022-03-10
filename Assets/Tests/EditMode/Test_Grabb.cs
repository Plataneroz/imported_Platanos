using System.Collections;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.TestTools;


public class Test_Grab
{

    // A Test behaves as an ordinary method
   
  
        GameObject child;
        GameObject grabsObj;
        GameObject ColliderRigidBodBodObj;
        GameObject pickedUpObjTrans;
        GameObject currentColliderGameObj;
        GameObject pickedUpObjCapColliderObj;

        Grab grabWithComponent;
        Rigidbody2D addRigidComponent;
        CapsuleCollider2D addPickedUpCollider;

        
        public void Init()
        {
            child = new GameObject();
            grabsObj = new GameObject();
            ColliderRigidBodBodObj = new GameObject();
            pickedUpObjTrans = new GameObject();
            currentColliderGameObj = new GameObject();
            pickedUpObjCapColliderObj = new GameObject();
            child.transform.parent = grabsObj.transform;
            grabWithComponent = grabsObj.AddComponent<Grab>();
            addRigidComponent = ColliderRigidBodBodObj.AddComponent<Rigidbody2D>();
            addPickedUpCollider = pickedUpObjCapColliderObj.AddComponent<CapsuleCollider2D>();
        }



    [Test]
         public void Test_FollowPlayer()
        {
            Init();
            grabWithComponent.ColliderRigidBod = addRigidComponent;
            grabWithComponent.currentColliderGameObj = currentColliderGameObj;
            grabWithComponent.pickedUpObjCapCollider = addPickedUpCollider;
            grabWithComponent.pickedUpObjTrans = pickedUpObjTrans.transform;
            grabWithComponent.FollowingPlayer();
        Assert.True(grabWithComponent.pickedUpObjCapCollider.isTrigger , "pick objs collider is not a trigger");
        Assert.True(grabWithComponent.ColliderRigidBod.isKinematic, "ColliderRigidBod.kinematic is not true");
        Assert.AreEqual(grabWithComponent.transform.childCount,1,"Obj colliding was not made a child ");
        Assert.AreEqual(grabWithComponent.pickedUpObjTrans.localPosition,new Vector3(.05f,.05f,0), "picked up objs local posisition is not x:.5, y:.5,z:0");
        
        }

    }

