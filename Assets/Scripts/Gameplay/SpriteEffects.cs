using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class SpriteEffects : MonoBehaviour
    {
        
        
         public SpriteRenderer spriteRenderer;
        
        Sprite[] spriteArray;
     
        int currentSprite;
        Color defaultColor;
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            defaultColor = spriteRenderer.color;
        }
     

        public void ChangeSprite()
        {
            spriteRenderer.sprite = spriteArray[currentSprite];
            currentSprite++;

        }
        
        public void FlipSprite()
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        public void StartToBlink()
        {
            StartCoroutine(Blink());
        }

        public IEnumerator Blink()
        {
           
            

            spriteRenderer.color = new Color(1, 0, 0, .5f);

            yield return new WaitForSeconds(0.1f);

            spriteRenderer.color = defaultColor;

            
        }

     
    }
}