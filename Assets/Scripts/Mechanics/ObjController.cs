using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.Mechanics
{
    public class ObjController : MonoBehaviour
    {
        float playerXDir;
        float playerYDir;
        public PlayerController playerController;
        public Transform playerTrans;
        Rigidbody2D rigid;
        CapsuleCollider2D capcollider2D;
    // Start is called before the first frame update
    void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            capcollider2D = GetComponent<CapsuleCollider2D>();
        }



     


      
       
    }
}