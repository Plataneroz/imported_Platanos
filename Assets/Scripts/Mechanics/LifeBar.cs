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
            myIMGcomponent.sprite = spriteArray[currentSprite];
            currentSprite++;

        }


        public void IncreaseBar()
        {
            myIMGcomponent.sprite = spriteArray[currentSprite];
            currentSprite--;

        }
    }
}
