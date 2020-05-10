using UnityEngine;

namespace Memo.Data
{
    [System.Serializable]
    public class AudioData
    {
        public string name;
        public AudioClip clip;
        
        [Range(0f, 1f)]
        public float volume;
        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }
}