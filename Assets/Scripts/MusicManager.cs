using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip startMusic;

    [SerializeField]
    private AudioClip gameMusic;

    [SerializeField]
    private AudioClip endMusic;

    [SerializeField]
    private AudioSource source;
    private static MusicManager instance = null;

    public static MusicManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this) //!= this means not in the scen where it was created
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject); //dont destrou objekt when new scen are loaded
    }

    private void Start()
    {
        PlayStartMusic();
    }

    static public void PlayStartMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.startMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }

    static public void PlayGameMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.gameMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }

    static public void PlayEndMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.endMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }

}


