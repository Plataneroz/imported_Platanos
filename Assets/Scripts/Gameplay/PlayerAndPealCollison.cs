using System;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.GamePlay;
namespace Script.Assets.Scripts.Gameplay
{
    public class PlayerAndPealCollison : Simulation.Event<PlayerAndPealCollison>
    {
        PlayerController playerController;
        public override void Execute()
        {
            playerController.bananaPeal.RevivePlatano();
        }
    }
}
