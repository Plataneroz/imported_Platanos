using UnityEngine;
using System.Collections;
using Platformer.Gameplay;
namespace Platformer.Mechanics
{

    public class KartComponents : MonoBehaviour
    {
        public KartStatus kartStatus;
        public ActiviatePhase activiatePhase;
        public SpriteEffects spriteEffects;
        // public TrujilloKartActions trujilloKartActions;

        void Start()
        {
            spriteEffects = GetComponent<SpriteEffects>();
            kartStatus = GetComponent<KartStatus>();
             activiatePhase = GetComponent<ActiviatePhase>();
            
        }
    }
}