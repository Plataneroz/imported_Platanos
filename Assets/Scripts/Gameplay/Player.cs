using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Platformer.GamePlay;

namespace Platformer.Mechanics
{
    public class Player : MonoBehaviour
    {
        [Header("Player Control")]
        public bool controlEnabled = true;
       // public PlayerRestTime playerRestTime;

        [Header("Horizontal Movement")]
        public float moveSpeed = 10f;
        public Vector2 direction;
        public Vector2 move;
        private bool facingRight = true;
        public SpriteRenderer spriterRender;

        [Header("Vertical Movement")]
        public float jumpSpeed = 15f;
        public float jumpDelay = 0.25f;
        private float jumpTimer;
        private bool jump;
        private bool initiateJump = false;

        [Header("Components")]
        public Rigidbody2D rb;
        public Animator animator;
        public LayerMask groundLayer;
        public GameObject characterHolder;
        public BananaPeal bananaPeal;
        public PlayerRestTime playerRestTime;
        public SpriteEffects spriteEffects;

        [Header("Physics")]
        public float maxSpeed = 7f;
        public float linearDrag = 0f;
        public float gravity = 1f;
        public float fallMultiplier = 5f;

        [Header("Collision")]
        public bool onGround = false;
        public float groundLength = 0.6f;
        public Vector3 colliderOffset;
        public CapsuleCollider2D capsuleCollider2d;
        public PlayerHealthComponents playerHealthComponents;

        private void Start()
        {
            
            animator = transform.GetChild(2).GetComponent<Animator>();
            spriteEffects = GetComponent<SpriteEffects>();
            capsuleCollider2d = GetComponent<CapsuleCollider2D>();
            bananaPeal = GetComponent<BananaPeal>();
            playerRestTime = GetComponent<PlayerRestTime>();
            playerHealthComponents = GetComponent<PlayerHealthComponents>();
        }

        // Update is called once per frame
        void Update()
        {
            if (controlEnabled)
            {
               
                   
                bool wasOnGround = onGround;
                onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer)
                         || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

                if (!wasOnGround && onGround)
                {
                    //  StartCoroutine(JumpSqueeze(1.25f, 0.8f, 0.05f));
                }

                if (jump)
                {

                    jumpTimer = Time.time + jumpDelay;
                }
                if(move.x ==0 & onGround)animator.Play("PlataIdle");
                //animator.Play("onGround", onGround);
                direction = new Vector2(move.x, move.y);
            }
        }
        void FixedUpdate()
        {
            if (controlEnabled)
            {
                moveCharacter(move.x);
                if (jumpTimer > Time.time && onGround)
                {
                    
                    Jump();
                }

                modifyPhysics();
            }
        }
        void moveCharacter(float horizontal)
        {
            
            rb.AddForce(Vector2.right * horizontal * moveSpeed);
            var velocityX = Mathf.Sign(rb.velocity.x);
            if (Mathf.Abs(move.x) > 0 && onGround) {
                animator.Play("PlataRun");


                    }
           
            
            if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
            {
                Flip();
            }
            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
               
                rb.velocity = new Vector2(velocityX * maxSpeed, rb.velocity.y);
               
                // animator.speed = velocityX  ;
            }

            
        }
        void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpTimer = 0;
            // StartCoroutine(JumpSqueeze(0.5f, 1.2f, 0.1f));
        }
        void modifyPhysics()
        {
            bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

            if (onGround)
            {


                if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
                {
                    rb.drag = linearDrag;
                }
                else
                {
                    rb.drag = 0f;
                }
                rb.gravityScale = 0;
            }
            else
            {
                animator.Play("PlataJump");
                rb.gravityScale = gravity;
                rb.drag = linearDrag * 0.15f;
                if (rb.velocity.y < 0)
                {
                    
                    jump = false;
                    rb.gravityScale = gravity * fallMultiplier;
                }
                else if (rb.velocity.y > 0 && !jump)
                {

                    rb.gravityScale = gravity * (fallMultiplier / 2);
                }
            }
        }
        void Flip()
        {
            facingRight = !facingRight;
            //spriterRender.flipX
            characterHolder.transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
        }
        IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
        {
            Vector3 originalSize = Vector3.one;
            Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
            float t = 0f;
            while (t <= 1.0)
            {
                t += Time.deltaTime / seconds;
                characterHolder.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
                yield return null;
            }
            t = 0f;
            while (t <= 1.0)
            {
                t += Time.deltaTime / seconds;
                characterHolder.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
                yield return null;
            }

        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
            Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
        }

        public void OnMove(InputAction.CallbackContext cont)
        {
            
             move = cont.ReadValue<Vector2>();
            

        }

        public void OnJump(InputAction.CallbackContext context)
        {
            //print( "is it preforming " +context.performed);
            if (context.started && !initiateJump) { jump = true; initiateJump = true; }
            else if (context.canceled) { jump = false; initiateJump = false; }


        }
    }
}