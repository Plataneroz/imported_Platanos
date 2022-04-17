using System;
using UnityEngine;
using Platformer.Mechanics;
using System.Collections;

namespace Platformer.GamePlay
{
    public class BananaPeal : MonoBehaviour
    {

        SpriteRenderer spriteRender;
        PlayerController playerController;
        GameObject aim;
        public Sprite[] playerSprites;


        private void Start()
        {
            playerController = GetComponent<PlayerController>();
            playerController.controlEnabled = false;
            // spriteEffects = GetComponent<SpriteEffects>();
            spriteRender.sprite = playerSprites[0];
            playerController.boxCollider2d.size = new Vector2(.52f, .36f);
            aim = playerController.gameObject.transform.GetChild(0).gameObject ;
            aim.SetActive(false);
            StartCoroutine(Rot());
        }

        void RevivePlatano()
        {
            playerController.controlEnabled = true;
            playerController.boxCollider2d.size = new Vector2(.52f, 1.131792f);
            spriteRender.sprite = playerSprites[1];
            aim.SetActive(true);
        }
        private void Update()
        {
            
        }
        public IEnumerator Rot()
        {
            float alphaVal = spriteRender.color.a;
            Color tmp = spriteRender.color;

            while (spriteRender.color.a < 1)
            { FadeColor(alphaVal, tmp);
                yield return new WaitForSeconds(1f); // update interval
            }
             

        }
        void FadeColor(float alphaVal, Color tmp)
        {
            alphaVal += 0.25f;
            tmp.a = alphaVal;
            spriteRender.color = tmp;
        }

    }
}
