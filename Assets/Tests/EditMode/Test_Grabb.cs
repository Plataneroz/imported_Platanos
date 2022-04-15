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

        HandleObj grabWithComponent;
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
            grabWithComponent = grabsObj.AddComponent<HandleObj>();
            addRigidComponent = ColliderRigidBodBodObj.AddComponent<Rigidbody2D>();
            addPickedUpCollider = pickedUpObjCapColliderObj.AddComponent<CapsuleCollider2D>();

            grabWithComponent.ColliderRigidBod = addRigidComponent;
            grabWithComponent.currentColliderGameObj = currentColliderGameObj;
            grabWithComponent.pickedUpObjCapCollider = addPickedUpCollider;
            grabWithComponent.pickedUpObjTrans = pickedUpObjTrans.transform;
    }



    [Test]
         public void Test_FollowPlayer()
        {
            Init();

            grabWithComponent.FollowingPlayer();
            Assert.True(grabWithComponent.pickedUpObjCapCollider.isTrigger , "pick objs collider is not a trigger");
            Assert.True(grabWithComponent.ColliderRigidBod.isKinematic, "ColliderRigidBod.kinematic is not true");
            Assert.NotNull(grabWithComponent.pickedUpObjTrans.parent,"Obj colliding was not made a child ");
            Assert.AreEqual(grabWithComponent.pickedUpObjTrans.localPosition,new Vector3(.05f,.05f,0), "picked up objs local posisition is not x:.5, y:.5,z:0");
        
        }
        [Test]
        public void Test_Drop()
    {
        Init();
        grabWithComponent.DropObj();
        Assert.False(grabWithComponent.pickedUpObjCapCollider.isTrigger, "pick objs collider is still a trigger");
        Assert.IsNull(grabWithComponent.pickedUpObjTrans, "picked ups trans is not null ");
        Assert.IsNull(grabWithComponent.ColliderRigidBod, "picked ups  collided was not released");
    }
    [Test]
    public void TestThrowing()
    {
        Init();
        grabWithComponent.Throwing(2);
        Assert.AreEqual(grabWithComponent.currentColliderGameObj.tag,"pickUpObj");
        Assert.AreEqual(currentColliderGameObj.gameObject.layer,7, "currentCollider layer was not change to 7");
        Assert.False(grabWithComponent.pickedUpObjCapCollider.isTrigger, "pick objs collider is still a trigger");
        Assert.IsNull(grabWithComponent.pickedUpObjTrans, "picked ups trans is not null ");
        Assert.IsNull(grabWithComponent.ColliderRigidBod, "picked ups  collided was not released");
       
    }

}

