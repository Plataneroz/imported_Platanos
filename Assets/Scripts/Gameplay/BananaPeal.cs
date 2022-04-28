using System;
using UnityEngine;
using Platformer.Mechanics;
using System.Collections;
using UnityEngine.InputSystem;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
namespace Platformer.GamePlay
{
    public class BananaPeal : MonoBehaviour
    {

        public SpriteRenderer spriteRenderer;
        Player plyrControl;
        PlayerHealthComponents playerHealthComponents;
        SpriteRenderer aim;
        public Sprite[] playerSprites;
        PlayerInput playerInput;
        float breathCount = 1.4f;
        private void OnEnable()
        {
            plyrControl = GetComponent<Player>();
            //spriteRenderer = plyrControl.gameObject.GetComponent<SpriteRenderer>();
            playerHealthComponents = GetComponent<PlayerHealthComponents>();
            plyrControl.controlEnabled = false;
            plyrControl.gameObject.tag = "peal";
            plyrControl.gameObject.layer = 15;
            playerSprites[1] = spriteRenderer.sprite;
            spriteRenderer.sprite = playerSprites[0];
            plyrControl.capsuleCollider2d.size = new Vector2(.52f, .36f);
            aim = plyrControl.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>() ;
            aim.enabled = false;
            plyrControl.enabled = false;
            StartCoroutine(Rot());
        }

        public  void PreRevive()
        {
            // player has peal and is waiting to be t
            //thrown
            // breath count stops
        }

        public void RevivePlatano()
        {
            // set position
            spriteRenderer.color = new Color(1, 1, 1);
            plyrControl.gameObject.tag = "Player";
            plyrControl.gameObject.layer = 6;
            plyrControl.controlEnabled = true;
            plyrControl.capsuleCollider2d.size = new Vector2(.52f, 1.131792f);
          
            spriteRenderer.sprite = playerSprites[1];
            playerHealthComponents.ResetHP();
            aim.enabled = true ;
            plyrControl.enabled = true;

            enabled = false;

        }

        public IEnumerator Rot()
        {
            float alphaVal = spriteRenderer.color.a;
            Color tmp = spriteRenderer.color;
             
            while (breathCount >= 0
                && playerHealthComponents.GetCurrentHP() == 0)
            {
                
                yield return new WaitForSeconds(1f); // update interval
            
                DarkenColor(tmp);
            }

            if (breathCount <= 0)
               {
               // plyrControl.gameObject.SetActive(false);
                //Schedule<PlayerDeath>();
                } 
        }
        void DarkenColor( Color tmp)
        {
            breathCount -= .2f;
            spriteRenderer.color = new Color(breathCount,breathCount,breathCount) ;
        }

    }
}
