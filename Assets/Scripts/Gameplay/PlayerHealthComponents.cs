using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.Mechanics
{
    public class PlayerHealthComponents : Health
    {
        PlayerRestTime playerRest; 
        public LifeBar lifeBar;
        private void Start()
        {
            playerRest = GetComponent<PlayerRestTime>();
                maxHP = 3000;
            currentHP = 3000;

        }
        public void Decrease()
        {
            Decrement();
            lifeBar.DecreaseBar();
        }
        public void Increase()
        {
            if(!playerRest) Increase(); lifeBar.IncreaseBar();

        }

        public void ResetHP()
        {
            maxHP = 1;
            currentHP = 1;
            lifeBar.IncreaseBar();
        }
    }
}
