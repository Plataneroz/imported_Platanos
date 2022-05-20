using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField]
        AudioClip suckSound;
        [SerializeField]
        AudioClip blowSound;
        [SerializeField]
        AudioClip emptySound;


        AudioSource audioSource;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        public void SuckingSound()
        { audioSource.clip = suckSound; audioSource.Play(); }

        public void BlowSound()
        { audioSource.clip = blowSound; audioSource.Play(); }

        public void EmptySound()
        { audioSource.clip = emptySound; audioSource.Play(); }

    }
}