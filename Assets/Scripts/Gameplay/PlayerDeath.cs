using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
       
        public override void Execute()
        {
            /*
            var player = model.player;
            var player2 = model.player2;
            
            
            if (!player.playerHealthComponents.IsAlive )
            {
                player.playerHealthComponents.Die();
               /* model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                 player.collider.enabled = false;
               
                player.controlEnabled = false;

                /* if (player.audioSource && player.ouchAudio)
                     player.audioSource.PlayOneShot(player.ouchAudio);
                 player.animator.SetTrigger("hurt");
                 player.animator.SetBool("dead", true);
                 


                    
            }
           else if (!player.playerHealthComponents.IsAlive
            && !player2.playerHealthComponents.IsAlive)
            {
                SceneManager.LoadScene("TrujilloLevel");
            }

            else if (!player.playerHealthComponents.IsAlive
                    && player2== null)
            {
                Simulation.Schedule<PlayerSpawn>(2);
            }
        */}
    }
}