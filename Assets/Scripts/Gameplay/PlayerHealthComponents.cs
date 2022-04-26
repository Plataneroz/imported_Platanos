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
             maxHP = 3;
            currentHP = 3;

        }
        public void Decrease()
        {
            Decrement();
            lifeBar.DecreaseBar();
        }
        public void Increase()
        {
            Increase();
            lifeBar.IncreaseBar();
        }

        public void ResetHP()
        {
            maxHP = 1;
            currentHP = 1;
            lifeBar.IncreaseBar();
        }
    }
}
