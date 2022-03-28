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
            if(!phaseOne.activeSelf) phaseOne.SetActive(true);
         }
        public void Two()
        {

            if(!phaseTwo.activeSelf)phaseTwo.SetActive(true);
        }
        public void Three()
        {
            if (!phaseThree.activeSelf)  phaseThree.SetActive(true); 
            
        }

        public void OneOff()
        {
            if (!phaseOne) phaseOne.SetActive(false);
        }
        public void TwoOff()
        {

            if (!phaseTwo.activeSelf) phaseTwo.SetActive(false);
        }
        public void ThreeOff()
        {
             phaseThree.SetActive(false);

        }

    }
    }
