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
        

        private void OnEnable()
        {

            _audioSource = GetComponent<AudioSource>();
          

        }

        public void SwingSwordEffect(int swordIndex)
        {
            _audioSource.PlayOneShot(_swordSwingSound[swordIndex],_swordSwingSoundVolume[swordIndex]);
        }

       

    }

}


