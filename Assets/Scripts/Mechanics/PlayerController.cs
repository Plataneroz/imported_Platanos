using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

using UnityEngine.InputSystem;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 10;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public BoxCollider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        CapsuleCollider2D capsuleCollider2D;
        public Health health;
        public LifeBar lifeBar;
        public bool controlEnabled = true;

        bool jumpancelled;
        bool jump;
        public Vector2 move;
        public bool grabStuff;
        public bool dropStuff;
        public bool throwStuff;

        double startTime;
        int distance ;
        int pressTime;

        int grabCount;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;
        Grab grab;



        void Awake()
        {
  
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<BoxCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            //animator = GetComponent<Animator>();
            capsuleCollider2D = GetComponent<CapsuleCollider2D>();
            capsuleCollider2D.enabled = false;
            grab = GetComponent<Grab>();

        }

        protected override void Update()
        {
            if (controlEnabled)
            {

                if (jumpState == JumpState.Grounded && jump)
                    jumpState = JumpState.PrepareToJump;
                else if (jumpancelled)
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }

            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }


        public void OnMove(InputAction.CallbackContext cont)
        {

            if (controlEnabled) { move = cont.ReadValue<Vector2>(); }
            

        }

        public void OnJump(InputAction.CallbackContext context)
        {
            //print( "is it preforming " +context.performed);
            jump = context.performed;
            jumpancelled = context.canceled;
            
        }
        // use another button to drop 



        ///use another button to throw  
        public void OnGrab(InputAction.CallbackContext context)
        {
            if (!context.canceled) {capsuleCollider2D.enabled = true;}
            else { capsuleCollider2D.enabled = false; }
        }

       /* public void OnPush(InputAction.CallbackContext context)
        {
            // if (context.started) { grab.DropObj(); }
            //dropStuff = !context.canceled ? true : false;
        }
       */


        public void OnDrop(InputAction.CallbackContext context)
        {
           // if (context.started) { grab.DropObj(); }
            //dropStuff = !context.canceled ? true : false;
        }
        public void OnThrow(InputAction.CallbackContext context)
        {      
            if(context.started) { startTime = context.time; }
            if (context.canceled) {
                pressTime = Mathf.RoundToInt((float)((float)context.time - startTime));
                distance = pressTime > 2 ? 12 : pressTime * 3;
                grab.Throwing(distance ); }
        }
        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

           // animator.SetBool("grounded", IsGrounded);
          //  animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}