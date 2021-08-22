using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RehtseStudio.PlayerSoundEffectsManager
{

    public class RS_PlayerSoundEffectsManager : MonoBehaviour
    {

        private AudioSource _audioSource;

        [Header("Swing Attack Sound Effects")]
        [SerializeField] private List<AudioClip> _swordSwingSound = new List<AudioClip>();
        [SerializeField] private List<float> _swordSwingSoundVolume = new List<float>();

        [Header("Footsteps Sound Effect")]
        [SerializeField] private AudioClip _footstepsSound;
        

        private void OnEnable()
        {

            _audioSource = GetComponent<AudioSource>();
          

        }

        public void SwingSwordEffect(int swordIndex)
        {

            _audioSource.PlayOneShot(_swordSwingSound[swordIndex],_swordSwingSoundVolume[swordIndex]);
           
        }

        public void FootstepsEffect()
        {
            //_audioSource.PlayOneShot(_footstepsSound);
            _audioSource.clip = _footstepsSound;
            _audioSource.PlayScheduled(0.04f);
        }

        public void CancelFootstepsEffect()
        {
            _audioSource.clip = _footstepsSound;
            _audioSource.Stop();
        }

       

    }

}


