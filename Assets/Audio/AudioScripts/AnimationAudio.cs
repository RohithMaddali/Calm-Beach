using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip clip;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayAnimationSound()
    {
        source.PlayOneShot(clip);
    }
}
