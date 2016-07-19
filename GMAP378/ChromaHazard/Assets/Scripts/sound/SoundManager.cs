using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    public SoundEffect[] sounds;
    public AudioSource[] sources;
    public AudioSource loopedSource;
    public static SoundManager instance = null;
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
    public float sfxVolume = 0.2f;

    public bool sfxOn = true;

    private bool playingLooped;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        playingLooped = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private AudioSource getSource()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            if (!sources[i].isPlaying)
            {
                return sources[i];
            }
        }

        return null;
    }

    public void StartLoopedSound(string label, float vol)
    {
        Debug.Log("Start");
        if (!playingLooped && sfxOn) 
        {
            Debug.Log("Playing");
            for (int i = 0; i < sounds.Length; i++)
            {
                if (sounds[i].label.Equals(label))
                {
                    AudioSource source = loopedSource;
                    source.clip = sounds[i].clip;
                    source.volume = vol;
                    source.loop = true;
                    source.Play();
                    playingLooped = true;
                    return;
                }
            }

            Debug.LogError("Cannot find sound labeled " + label);
        }
    }

    public void StopLoopedSound()
    {
        if (playingLooped)
        {
            loopedSource.Stop();
            playingLooped = false;
        }
    }

    public void PlaySound(string label)
    {
        if (sfxOn) 
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                if (sounds[i].label.Equals(label))
                {
                    AudioSource source = getSource();
                    if (source != null)
                    {
                        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
                        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
                        source.clip = sounds[i].clip;
                        source.pitch = randomPitch;
                        source.volume = sfxVolume;
                        source.loop = false;
                        source.Play();
                    }
                    return;
                }
            }

            Debug.LogError("Cannot find sound labeled " + label);
        }
    }

    [Serializable]
    public class SoundEffect
    {
        public AudioClip clip;
        public string label;
    }
}
