using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.Mechanics
{
    public class PlayerHealthComponents : Health
    {   
        public LifeBar lifeBar;
        private void Start()
        {
            ResetHP();
            
        }
        public void Decrease()
        {
            Decrement();
            //lifeBar.DecreaseBar();
        }
        public void Increase()
        {
            Increase();
            lifeBar.IncreaseBar();
        }

        public void ResetHP()
        {
            maxHP = 3;
            currentHP = 3;
        }
    }
}
