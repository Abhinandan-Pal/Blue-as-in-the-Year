using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
   public string name="";
   public AudioClip clip;
   public bool loop= false;
   public bool played = false;
   [Range(0f,1f)] 
   public float volume = 1;
   [Range(0.1f,3f)] 
   public float pitch = 1;

   [HideInInspector] 
   public AudioSource source;
}
