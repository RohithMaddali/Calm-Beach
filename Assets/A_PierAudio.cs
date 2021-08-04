using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PierAudio : MonoBehaviour
{
    [Header("AudioClips")]
    [SerializeField] AudioClip[] pillar = new AudioClip[4];
    [SerializeField] AudioClip[] pillarSupports = new AudioClip[4];
    [SerializeField] AudioClip[] plank = new AudioClip[4];
    AudioSource source;
    Animator animator;
    int index;
    [SerializeField] bool testing;
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        if (testing)
        {
            StartCoroutine(Timer());
        }    
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        animator.SetBool("start", true);
    }
    void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void Sequence(string soundArray)
    {
        if (soundArray == "pillar")
        {
            PlaySound(pillar[index]);
            index++;
            IndexReset(pillar.Length);
        }
        if (soundArray == "support")
        {
            PlaySound(pillarSupports[index]);
            index++;
            IndexReset(pillarSupports.Length);
        }
        if (soundArray == "plank")
        {
            PlaySound(plank[index]);
            index++;
            IndexReset(plank.Length);
        }
    }
    void IndexReset(int array)
    {
        if (index >= array)
        {
            index = 0;
        }
    }
}
