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

        public class ActiviatePhase : MonoBehaviour
        {
            
            public GameObject phaseOne;
            public GameObject phaseTwo;
            public GameObject phaseThree;
           
            // Start is called before the first frame update

        public void One()
        {
            phaseOne.SetActive(true);
                //trujillo.transform.position = new Vector3(model.player.transform.position.x, model.player.transform.position.y + 4);   
        }
        public void Two()
        {
            phaseTwo.SetActive(true);
            //trujillo.transform.position = new Vector3(model.player.transform.position.x, model.player.transform.position.y + 4);   
        }
        public void Three()
        {
            phaseThree.SetActive(true);
            //trujillo.transform.position = new Vector3(model.player.transform.position.x, model.player.transform.position.y + 4);   
        }

    }
    }
