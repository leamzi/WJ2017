using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Autor: Leamzi
/// Class that manage game music and sfx
/// </summary>
public class SoundManager : MonoBehaviour {

    public AudioSource sfxSource;
    public AudioSource bgmSource;
    public AudioSource randomPitchSource;

    public AudioClip[] bgmAudios;
    public AudioClip[] sfxAudios;

    public Dictionary<string, AudioClip> gameSoundList;

    public static SoundManager instance = null;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.20f;

    public bool muteSfx = false;
    public bool muteBgm = false;

    
    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        FillGameAudio();

        DontDestroyOnLoad (this.gameObject);
	}

    /// <summary>
    /// Fills up dictionary with the game sound files
    /// </summary>
    private void FillGameAudio()
    {
        gameSoundList = new Dictionary<string, AudioClip>();

        if(bgmAudios.Length > 0)
        {
            foreach (AudioClip audio in bgmAudios)
            {
                gameSoundList.Add(audio.name, audio);
            }
        }

        if (sfxAudios.Length > 0)
        {
            foreach (AudioClip audio in sfxAudios)
            {
                gameSoundList.Add(audio.name, audio);
            }
        }
        
    }

    /// <summary>
    /// To play sound effects
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySfx(AudioClip clip)
    {
        if (muteSfx)
            return;

        sfxSource.pitch = 1.0f;
        sfxSource.PlayOneShot(clip);
    }

    // this plays a sfx passing either the audio clip or name
    public void PlaySfx(string _clipName)
    {
        if (muteSfx)
            return;

        if (gameSoundList.ContainsKey(_clipName))
            sfxSource.PlayOneShot(gameSoundList[_clipName]);
    }

    public void RandomizeSfx(params string[] clipsNames)
    {
        if (muteSfx)
            return;

        int randomIndex = Random.Range(0, clipsNames.Length);

        if (gameSoundList.ContainsKey(clipsNames[randomIndex]))
        {
            sfxSource.PlayOneShot(gameSoundList[clipsNames[randomIndex]], 0.5f);
        }
    }

    public void RandomizeSfxAndPitch(params AudioClip [] clips)
    {
        if (muteSfx)
            return;

        int randomIndex = Random.Range (0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        randomPitchSource.pitch = randomPitch;
        randomPitchSource.PlayOneShot(clips[randomIndex], 0.3f);
    }

    public void RandomizeSfxAndPitch(params string [] clipsNames)
    {
        if(muteSfx)
            return;

        int randomIndex = Random.Range(0, clipsNames.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        if(gameSoundList.ContainsKey(clipsNames[randomIndex]))
        {
            randomPitchSource.pitch = randomPitch;
            randomPitchSource.PlayOneShot(gameSoundList[clipsNames[randomIndex]], 0.3f);
        }
        
    }

    public void StopSfx()
    {
        sfxSource.Stop();
        randomPitchSource.Stop();
    }

    /// <summary>
    /// To play background music
    /// </summary>
    /// <param name="clip"></param>
    public void PlayBgm(AudioClip clip)
    {
        if (muteBgm)
            return;

        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void PlayBgm(string _clipName)
    {
        if (muteBgm)
            return;

        if (gameSoundList.ContainsKey(_clipName))
        {
            bgmSource.clip = gameSoundList[_clipName];
            bgmSource.Play();
        }
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }
}
