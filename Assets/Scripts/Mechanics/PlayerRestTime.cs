using UnityEngine;
using System.Collections;

namespace Platformer.Mechanics
{
    public class PlayerRestTime : MonoBehaviour
    {

        private bool _canHarmPlayer = true;

        public bool canHarmPlayer
        {
            get
            {
                return _canHarmPlayer;
            }
        }

        // Use this for initialization

        public void HurtPlayer()
        {
            StartCoroutine(PlayerIsHurt());
        }

        IEnumerator PlayerIsHurt()
        {
            _canHarmPlayer = false;
            yield return new WaitForSeconds(1f);
            _canHarmPlayer = true;
        }
    }
}