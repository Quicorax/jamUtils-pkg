using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Runtime.Audio
{
    [CreateAssetMenu(menuName = "Quicorax/AudioUtil/HardAudioDefinitions", fileName = "Hard Audio Definitions")]
    public class AudioDefinitions : ScriptableObject
    {
        [Serializable]
        public class AudioDefinition
        {
            public string AudioKey;
            public AudioClip AudioFile;
        }

        public List<AudioDefinition> Audios = new();
        public readonly Dictionary<string, AudioClip> SerializedAudios = new();

        public void Initialize()
        {
            foreach (var audioDefinition in Audios)
            {
                SerializedAudios.Add(audioDefinition.AudioKey, audioDefinition.AudioFile);
            }
        }
    }
}