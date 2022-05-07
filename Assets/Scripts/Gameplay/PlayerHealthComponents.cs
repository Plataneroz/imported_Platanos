using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
namespace Platformer.Mechanics
{
    public class PlayerHealthComponents : Health
    {

        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        
        PlayerRestTime playerRest; 
        public LifeBar lifeBar;
        private void Start()
        {
          //  playerRest = GetComponent<PlayerRestTime>();
                maxHP = 100;
            currentHP = 100;

        }
        public void Decrease()
        {
            Decrement();
            model.bananBar.RemoveLife();
        }
        public void Increase()
        {
            if(!playerRest) Increase(); model.bananBar.AddLife();

        }

        public void ResetHP()
        {
            maxHP = 1;
            currentHP = 1;
            model.bananBar.AddLife();

        }
    }
}
