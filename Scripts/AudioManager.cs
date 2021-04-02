using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    public Sound[] stories;

    Sound storyPrev;
    private static int no_played = 0;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            //s.source.Play();
        }
        int i = 0;
        foreach (Sound s in stories)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.name = "story"+i;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            i++;
            //s.source.Play();
        }
    }
    void Start() 
    {
        Play("Theme");
    }
    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds,sound =>sound.name == name);
        if(s == null)
            return;
        Debug.Log(name);
        s.source.Play();
    }
    public void PlayStory()
    {
        while(true)
        {
            Sound s;
            if(no_played==stories.Length-1)
            {
                if(storyPrev != null)
                {storyPrev.source.Pause();}
                Play("StoryCompleted");
                s = Array.Find(sounds,sound =>sound.name == "StoryCompleted");
                storyPrev = s;
                Debug.Log("Story Line Completed");
                return;
            }
            int storyNum = (int)(UnityEngine.Random.Range(0f,1f)*stories.Length);
            name = "story"+storyNum;
            s = Array.Find(stories,sound =>sound.name == name);
            if(s == null)
            {
                Debug.Log("Story Not Found "+name);
                return;
            }
            if(s.played == false)
            {
                s.source.Play();
                if(storyPrev != null)
                {storyPrev.source.Pause();}
                storyPrev= s;
                no_played++;
                return;
            }
        }
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds,sound =>sound.name == name);
        if(s == null)
            return;
        Debug.Log(name);
        s.source.Pause();
    }
}
