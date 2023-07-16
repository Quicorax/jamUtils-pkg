using Services.Runtime.ServiceManagement;
using UnityEngine;

namespace Services.Runtime.Audio
{
    public class AudioSampleCaller : MonoBehaviour
    {
        private AudioService _audioService;

        private void Start()
        {
            _audioService = ServiceLocator.GetService<AudioService>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _audioService.PlayMusic("Music");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _audioService.PlaySFX("Hit");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _audioService.ClearAudio();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _audioService.StopMusic("Music", 3);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _audioService.StopMusic("Music");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _audioService.StopMusic("Music", 1, () => Debug.Log("Fade Complete"));
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                _audioService.StopAllMusics(2);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _audioService.AddMusicVolume(1);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                _audioService.AddMusicVolume(-1);
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                _audioService.MuteMusic();
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                _audioService.AddSFXVolume(1);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                _audioService.AddSFXVolume(-1);
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                _audioService.MuteSFX();
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                _audioService.AddMasterVolume(1);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                _audioService.AddMasterVolume(-1);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                _audioService.MuteMaster();
            }
        }
    }
}