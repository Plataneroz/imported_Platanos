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

        SpriteRenderer spriteRender;
        PlayerController playerController;
        PlayerHealthComponents playerHealthComponents;
        SpriteRenderer aim;
        public Sprite[] playerSprites;
        PlayerInput playerInput;
        float breathCount = 1.4f;
        private void OnEnable()
        {
            playerController = GetComponent<PlayerController>();
            playerHealthComponents = GetComponent<PlayerHealthComponents>();
            playerController.controlEnabled = false;
            //playerInput = GetComponent<PlayerInput>();
            //playerInput.DeactivateInput();
            playerController.gameObject.tag = "peal";
            playerController.gameObject.layer = 15;
            playerSprites[1] = playerController.spriteRenderer.sprite;
            playerController.spriteRenderer.sprite = playerSprites[0];
            playerController.boxCollider2d.size = new Vector2(.52f, .36f);
            aim = playerController.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>() ;
            aim.enabled = false;
            playerController.enabled = false;
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
            playerController.spriteRenderer.color = new Color(1, 1, 1);
            playerController.gameObject.tag = "Player";
            playerController.gameObject.layer = 6;
            playerController.controlEnabled = true;
            playerController.boxCollider2d.size = new Vector2(.52f, 1.131792f);
          
            playerController.spriteRenderer.sprite = playerSprites[1];
            playerHealthComponents.ResetHP();
            aim.enabled = true ;
            playerController.enabled = true;

            enabled = false;

        }

        public IEnumerator Rot()
        {
            float alphaVal = playerController.spriteRenderer.color.a;
            Color tmp = playerController.spriteRenderer.color;
             
            while (breathCount >= 0
                && playerHealthComponents.GetCurrentHP() == 0)
            {
                
                yield return new WaitForSeconds(1f); // update interval
            
                DarkenColor(tmp);
            }

            if (breathCount <= 0)
               {
               // playerController.gameObject.SetActive(false);
                //Schedule<PlayerDeath>();
                } 
        }
        void DarkenColor( Color tmp)
        {
            breathCount -= .2f;
            
            playerController.spriteRenderer.color = new Color(breathCount,breathCount,breathCount) ;
        }

    }
}
