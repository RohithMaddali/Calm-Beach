using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PierAudio : MonoBehaviour
{
    [Header("AudioClips")]
    [SerializeField] AudioClip[] sounds = new AudioClip[18];
    AudioSource source;
    Animator animator;
    [SerializeField] bool testing;
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponentInChildren<AudioSource>();    
    }
    void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void Sequence(int audioclip)
    {
       PlaySound(sounds[audioclip]);
    }
}
