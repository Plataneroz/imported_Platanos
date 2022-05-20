using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Platformer.Gameplay;
//using static Platformer.Core.Simulation;
namespace Platformer.Mechanics
{

        public class ActiviatePhase : MonoBehaviour
        {
            
            public GameObject phaseOne;
            public GameObject phaseTwo;
            public GameObject phaseThree;
        public Animator animator;
        // Start is called before the first frame update

        public void One()
        {
            if (phaseOne.name == "Spider")
            {
                phaseOne.transform.position = new Vector3(16.6f,3.83f,0);
                phaseOne.transform.eulerAngles = new Vector3(0, 0, 55.113f);
                animator.Play("spiderAttack");
                phaseOne.GetComponent<CreateProjectile>().enabled = true;

            }
                
                else { if (!phaseOne.activeSelf) phaseOne.SetActive(true); }
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
            if (phaseOne) phaseOne.SetActive(false);
        }
        public void TwoOff()
        {

            if (phaseTwo.activeSelf) phaseTwo.SetActive(false);
        }
        public void ThreeOff()
        {
            if (phaseThree.activeSelf) phaseThree.SetActive(false);
        }
        private void OnDestroy()
        {
            if (gameObject.name == "FinalFormTrujillo")
            {
                phaseOne.SetActive(false);
                phaseTwo.SetActive(false);
                phaseThree.SetActive(false);
            }
        }
    }

    

    }
