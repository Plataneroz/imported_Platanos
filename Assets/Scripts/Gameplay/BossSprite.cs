using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class BossSprite : MonoBehaviour
    {
        
        [SerializeField]
         SpriteRenderer spriteRenderer;
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
    }
}