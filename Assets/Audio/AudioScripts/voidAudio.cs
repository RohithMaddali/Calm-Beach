using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidAudio : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void VoidDissapear()
    {
        source.PlayOneShot(clip);
    }
}
