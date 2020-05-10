using System;
using Memo.Data;
using UnityEngine;
using UnityEngine.Audio;

namespace Memo.Controller
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController instance;
        public AudioData[] audios;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }
            
            DontDestroyOnLoad(this.gameObject);

            foreach (var audio in audios)
            {
                audio.source = gameObject.AddComponent<AudioSource>();
                audio.source.clip = audio.clip;
                audio.source.volume = audio.volume;
                audio.source.loop = audio.loop;
            }
        }

        private void Start()
        {
            Play("Song " + UnityEngine.Random.Range(1, 2));
        }

        public void Play(string audioName)
        {
            var a = Array.Find(audios, audio => audio.name == audioName);
            if (a == null)
            {
                Debug.LogWarning("El audio con nombre ("+audioName+") no existe.");
                return;
            }

            a.source.Play();
        }
    }
}