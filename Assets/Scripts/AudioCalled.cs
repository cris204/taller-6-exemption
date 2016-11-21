using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class AudioCalled : MonoBehaviour
{
    [SerializeField]
    string [] SoundsNames;

    [SerializeField]
    AudioClip [] SoundsClips;

    Dictionary<string, AudioClip> Sounds;

    void Awake()
    {
        Sounds = new Dictionary<string, AudioClip>();
        for (int i = 0; i < SoundsClips.Length; i++)
        {
            Sounds.Add(SoundsNames[i], SoundsClips[i]);
        }
    }
    public void Music(string ClipName)
    {
        GetComponent<AudioSource>().PlayOneShot(Sounds[ClipName]);
    }
	
}
