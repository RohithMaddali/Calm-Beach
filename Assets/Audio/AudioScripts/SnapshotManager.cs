using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotManager : MonoBehaviour
{
    [SerializeField]
    AudioMixerSnapshot[] snapshots = new AudioMixerSnapshot[7];
    [SerializeField]
    float transitionTime;
    [SerializeField]
    int snapshotIndex;
    public void SnapshotTransition()
    {
        snapshots[snapshotIndex].TransitionTo(transitionTime);   
    }
}
