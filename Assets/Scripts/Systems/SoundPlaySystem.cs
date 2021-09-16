using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class SoundPlaySystem<TEventComponent> : IEcsRunSystem where TEventComponent : struct
    {
        private EcsFilter<TEventComponent> _soundEvents;
        private AudioSource _source;
        private List<AudioClip> _clips;

        public SoundPlaySystem(AudioSource source, List<AudioClip> clips)
        {
            _source = source;
            _clips = clips;
        }
    
        public void Run()
        {
            foreach (var i in _soundEvents)
            {
                _source.PlayOneShot(_clips[Random.Range(0, _clips.Count - 1)]);
            }
        }
    }
}