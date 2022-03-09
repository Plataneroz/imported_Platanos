using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
//using static Platformer.Core.Simulation;
namespace Platformer.Gameplay
{

        public class ActivateTrujillo : MonoBehaviour
        {
            [SerializeField]
            GameObject trujillo;
           
            // Start is called before the first frame update

            public void JumpOffKartTrujillo()
            {
                 trujillo.SetActive(true);
                 //trujillo.transform.position = new Vector3(model.player.transform.position.x, model.player.transform.position.y + 4);   
            }

    }
    }
