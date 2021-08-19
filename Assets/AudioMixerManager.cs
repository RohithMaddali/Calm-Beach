using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField]
    AudioMixer masterMixer;
    [SerializeField] AudioSource lighHouseSource;
    [SerializeField] AudioClip lightHouse;
    [SerializeField] AudioMixerSnapshot fadeIntroSnapshot;
    [SerializeField] AudioMixerSnapshot mainSnapshot;
    [SerializeField]
    float wavesVol, windVol, fireVol, SynthChordsVol, arpMelodyVol, pianoMelodyVol, binuralBeatVol, boatVol, introVol, treesAndBirdsVol,lightHouseVol;
    float startVol = -80;
    [Header("Fade Time Settings")]
    [SerializeField]
    [Range(0f, 2f)]
    float lerpMod = 0.5f;
    float[] lerp = new float[10];
    bool doOnce;

    private void Start()
    {
        SetLerpValues();
    }
    void SetLerpValues()
    {
        for (int i = 0; i < lerp.Length; i++)
        {
            lerp[i] = -80;
        }
    }
    /// <summary>
    /// Controls the volume of a audio bus.
    /// </summary>
    /// <param name="isActive"></param>
    public void WindVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("WindVol", lerp[0]);
            lerp[0] = Mathf.Lerp(lerp[0], windVol, lerpMod * Time.fixedDeltaTime);
        }
        else
        {
            masterMixer.SetFloat("WindVol", lerp[0]);
            lerp[0] = Mathf.Lerp(lerp[0], startVol, lerpMod * Time.fixedDeltaTime);
        }
    }
    public void WavesVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("WavesVol", lerp[1]);
            lerp[1] = Mathf.Lerp(lerp[1], wavesVol, lerpMod * Time.fixedDeltaTime);
        }
        else
        {
            masterMixer.SetFloat("WavesVol", lerp[1]);
            lerp[1] = Mathf.Lerp(lerp[1], startVol, lerpMod * Time.fixedDeltaTime);
        }
    }
    public void SynthChordsVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("SynthChordsVol", lerp[2]);
            lerp[2] = Mathf.Lerp(lerp[2], SynthChordsVol, lerpMod * Time.fixedDeltaTime);
            IntroSynthVolumeControl(true);
        }
        else
        {
            masterMixer.SetFloat("SynthChordsVol", lerp[2]);
            lerp[2] = Mathf.Lerp(lerp[2], startVol, lerpMod * Time.fixedDeltaTime);
            IntroSynthVolumeControl(false);
        }
    }
    public void ArpMelodyVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("ArpMelodyVol", lerp[3]);
            lerp[3] = Mathf.Lerp(lerp[3], arpMelodyVol, lerpMod * Time.fixedDeltaTime);
        }
        else
        {
            masterMixer.SetFloat("ArpMelodyVol", lerp[3]);
            lerp[3] = Mathf.Lerp(lerp[3], startVol, lerpMod * Time.fixedDeltaTime);
        }
    }
    public void PianoMelodyVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("PianoMelodyVol", lerp[4]);
            lerp[4] = Mathf.Lerp(lerp[4], pianoMelodyVol, lerpMod * Time.fixedDeltaTime);
        }
        else
        {
            masterMixer.SetFloat("PianoMelodyVol", lerp[4]);
            lerp[4] = Mathf.Lerp(lerp[4], startVol, lerpMod * Time.fixedDeltaTime);
        }
    }
    public void BinuralBeatVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("BinuralBeatVol", lerp[5]);
            lerp[5] = Mathf.Lerp(lerp[5], binuralBeatVol, lerpMod * Time.fixedDeltaTime);
        }
        else
        {
            masterMixer.SetFloat("BinuralBeatVol", lerp[5]);
            lerp[5] = Mathf.Lerp(lerp[5], startVol, lerpMod * Time.fixedDeltaTime);
        }
    }
    public void CampFireVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("CampFireVol", lerp[6]);
            lerp[6] = Mathf.Lerp(lerp[6], fireVol, lerpMod * Time.fixedDeltaTime);
        }
        else
        {
            masterMixer.SetFloat("CampFireVol", lerp[6]);
            lerp[6] = Mathf.Lerp(lerp[6], startVol, lerpMod * Time.fixedDeltaTime);
        }
    }
    public void BoatVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("BoatVol", lerp[7]);
            lerp[7] = Mathf.Lerp(lerp[7], boatVol, lerpMod * Time.fixedDeltaTime);
        }
        else
        {
            masterMixer.SetFloat("BoatVol", lerp[7]);
            lerp[7] = Mathf.Lerp(lerp[7], startVol, lerpMod * Time.fixedDeltaTime);
        }
    }
    public void IntroSynthVolumeControl(bool isActive)
    {
        if (isActive)
        {
            fadeIntroSnapshot.TransitionTo(30);
        }
        else
        {
            mainSnapshot.TransitionTo(30);
        }
    }
    public void TreesAndBirdsVolumeControl(bool isActive)
    {
        if (isActive)
        {
            masterMixer.SetFloat("Trees&BirdsVol", lerp[8]);
            lerp[8] = Mathf.Lerp(lerp[8], treesAndBirdsVol, lerpMod * Time.fixedDeltaTime);
        }
        else
        {
            masterMixer.SetFloat("Trees&BirdsVol", lerp[8]);
            lerp[8] = Mathf.Lerp(lerp[8], startVol, lerpMod * Time.fixedDeltaTime);
        }
    }
}
