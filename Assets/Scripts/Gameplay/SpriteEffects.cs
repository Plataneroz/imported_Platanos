using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class SpriteEffects : MonoBehaviour
    {
        
        
         public SpriteRenderer spriteRenderer;
        [SerializeField]
        Sprite[] spriteArray;
        [SerializeField]
        int currentSprite;


        public void ChangeSprite()
        {
            spriteRenderer.sprite = spriteArray[currentSprite];
            currentSprite++;

        }
        
        public void FlipSprite()
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        public IEnumerator Blink()
        {
            Debug.Log("Calling blink");
            Color defaultColor = spriteRenderer.color;

            spriteRenderer.color = new Color(1, 0, 0, .5f);

            yield return new WaitForSeconds(0.05f);

            spriteRenderer.color = defaultColor;

            yield return new WaitForSeconds(0.05f);

            spriteRenderer.color = new Color(1, 0, 0, .5f);

            yield return new WaitForSeconds(0.05f);

            spriteRenderer.color = defaultColor;
        }

     
    }
}