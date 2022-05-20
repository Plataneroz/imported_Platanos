using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class SpriteEffects : MonoBehaviour
    {  
         public SpriteRenderer spriteRenderer;
        SpriteRenderer[] sprites;
        Sprite[] spriteArray;
        
        int currentSprite;
        Color defaultColor;
        private void Start()
        {
            // spriteRenderer = transform.root.GetComponent<SpriteRenderer>();
            sprites = GetComponentsInChildren<SpriteRenderer>();

            defaultColor = spriteRenderer.color;
        }

        public void FlipSprite()
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        public void StartToBlink()
        {
            StartCoroutine(Blink());
        }

        public void StartMultiBlink()
        {
            StartCoroutine(BlinkMultiSprites());
        }
        public IEnumerator Blink()
        {
           
            spriteRenderer.color = new Color(1, 0, 0, .5f);

            yield return new WaitForSeconds(0.1f);

            spriteRenderer.color = defaultColor;   
        }

        public void  ChangeSprite()
        {
            spriteRenderer.sprite = spriteArray[1];
        }
         IEnumerator BlinkMultiSprites()
        {
            
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].color =  Color.red;
            }
            yield return new WaitForSeconds(0.4f);

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].color = Color.white;
            }
        }

    }
}