using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseAudio : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip lightHouseEmerge;

    private void Start()
    {
        source = GetComponent<AudioSource>();

    }
    public void LightHouseEmergeSound()
    {
        source.PlayOneShot(lightHouseEmerge);
    }
}
