using System;
using Services.Runtime.ServiceManagement;
using UnityEngine;

namespace Services.Runtime.Audio
{
    public class AudioService : IService
    {
        private AudioNest _audioNest;

        public void PlaySFX(string key) => _audioNest.PlaySFX(key);
        public void PlayMusic(string key) => _audioNest.PlayMusic(key);
        public void StopMusic(string key, float fadeTime = 0, Action onComplete = null) =>
            _audioNest.StopMusic(key, fadeTime, onComplete);
        public void StopAllMusics(float fadeTime) => _audioNest.StopAllMusics(fadeTime);
        
        public void AddMasterVolume(float additiveValue) => _audioNest.Volume.AddMasterVolume(additiveValue);
        public void AddMusicVolume(float additiveValue) => _audioNest.Volume.AddMusicVolume(additiveValue);
        public void AddSFXVolume(float additiveValue) => _audioNest.Volume.AddSFXVolume(additiveValue);
        
        public void MuteMaster() => _audioNest.Volume.MuteMaster();
        public void MuteMusic() => _audioNest.Volume.MuteMusic();
        public void MuteSFX() => _audioNest.Volume.MuteSFX();
        
        public void ClearAudio() => _audioNest.ClearAudio();

        public void Initialize()
        {
            var data = FetchDependencies();
            
            _audioNest = new GameObject().AddComponent<AudioNest>()
                .Initialize(data.AudioDefinitions, data.AudioMixer, data.MusicMixer, data.SFXMixer);
        }

        public void Clear()
        {
        }

        private AudioDependencies FetchDependencies() => 
            Resources.Load<AudioDependencies>("AudioDependencies");
    }
}