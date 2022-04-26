using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Mechanics
{
    public class LifeBar : MonoBehaviour
    {
        // Start is called before the first frame update

        private Image myIMGcomponent;
        [SerializeField]
        Sprite[] spriteArray;
        int currentSprite;
        // Use this for initialization
        void Start()
        {
            myIMGcomponent = this.GetComponent<Image>();

        }

        public void DecreaseBar()
        {
            if (currentSprite < 2)
            {
                myIMGcomponent.sprite = spriteArray[currentSprite];
                currentSprite++;
            }

        }

       public void ResetBar()
        {

        }

        public void IncreaseBar()
        {if (currentSprite > 0)
            {
                currentSprite--;
                myIMGcomponent.sprite = spriteArray[currentSprite];
            }
           

        }
    }
}
