using UnityEngine;
using System.Collections;

namespace Platformer.Gameplay
{ 
public class KartStatus : MonoBehaviour
    {
       private float _hitCounter;

       public float hitCounter => _hitCounter;
    

        public void IncreaseHit()
        {
            _hitCounter++;
        }

    }
}