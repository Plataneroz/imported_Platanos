using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.Mechanics
{
    public class PlayerHealth : Health
    {   
        public LifeBar lifeBar;
        private void Start()
        {
            maxHP = 3;
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
    }
}
