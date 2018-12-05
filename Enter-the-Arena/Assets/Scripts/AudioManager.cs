using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;
    public Sound[] music;

	// Use this for initialization
	void Awake () {
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch  = s.pitch;
            s.source.spatialBlend = 1.0f;
		}
        foreach (Sound m in music)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;

            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.spatialBlend = 1.0f;
        }
		
	}
	
	public void Play (string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Play();
	}

    public void musicPlay (string name)
    {
        Sound m = Array.Find(music, sound => sound.name == name);

    }

    public void musicChange (string name)
    {
        Sound current = Array.Find(music, song => song.source.isPlaying == true);
        print(current);
   
    }
}
