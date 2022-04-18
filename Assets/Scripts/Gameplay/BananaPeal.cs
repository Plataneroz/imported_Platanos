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
        GameObject aim;
        public Sprite[] playerSprites;
        PlayerInput playerInput;
        float colorCount = 1;
        private void OnEnable()
        {
            playerController = GetComponent<PlayerController>();
            playerController.controlEnabled = false;
            playerInput = GetComponent<PlayerInput>();
            playerInput.DeactivateInput();
            playerController.gameObject.tag = "peal";
            playerController.gameObject.layer = 15;

            playerController.spriteRenderer.sprite = playerSprites[0];
            playerController.boxCollider2d.size = new Vector2(.52f, .36f);
            aim = playerController.gameObject.transform.GetChild(0).gameObject ;
            aim.SetActive(false);
            playerController.enabled = false;
            StartCoroutine(Rot());
        }

        public void RevivePlatano()
        {
            // set position 
             playerController.controlEnabled = true;
            playerController.boxCollider2d.size = new Vector2(.52f, 1.131792f);
            playerController.capsuleCollider2D.enabled = true;
            playerController.spriteRenderer.sprite = playerSprites[1];
            playerController.playerHealthComponents.Increase();
            aim.SetActive(true);
            playerInput.enabled = true;
            enabled = false;

        }

        public IEnumerator Rot()
        {
            float alphaVal = playerController.spriteRenderer.color.a;
            Color tmp = playerController.spriteRenderer.color;
            //Debug.Log("this is g " + playerController.spriteRenderer.color);
            
            while (colorCount >= 0
                && playerController.playerHealthComponents.GetCurrentHP() == 0)
            {
                
                yield return new WaitForSeconds(1f); // update interval
                DarkenColor(tmp);
            }
            if (colorCount >= 0)
               {
                playerController.gameObject.SetActive(false);
                //Schedule<PlayerDeath>();
                } 
        }
        void DarkenColor( Color tmp)
        {

            //Solid white. RGBA is (1, 1, 1, 1).
            // Solid black. RGBA is (0, 0, 0, 1).
            Debug.Log("this is g " + playerController.spriteRenderer.color);
            colorCount -= .2f;
            playerController.spriteRenderer.color = new Color(colorCount,colorCount,colorCount) ;
        }

    }
}
