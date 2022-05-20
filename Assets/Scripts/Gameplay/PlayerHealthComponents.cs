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
        AudioController audioController;
        public SpriteEffects spriteEffects;
        PlayerRestTime playerRest; 
        public LifeBar lifeBar;
        private void Start()
        {
            
            spriteEffects = GetComponent<SpriteEffects>();
            playerRest = GetComponent<PlayerRestTime>();
                maxHP = 30;
            currentHP = 30;

        }
        public void Decrease()
        {
            if (playerRest.canHarmPlayer)
            {
                playerRest.HurtPlayer();
                Decrement();
                model.bananBar.RemoveLife();
                spriteEffects.StartMultiBlink();
            }
           
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
