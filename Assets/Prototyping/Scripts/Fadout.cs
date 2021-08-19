using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR.Input;
using Liminal.SDK.Core;
using UnityEngine;
using System;

public class Fadout : MonoBehaviour
{
    //Spawning/Animating variables
    public Animator skybox, GodRays,rocks, pier, boat, tree, lightHouse, sailBoat, rainbow, campfire;
    public int skyboxTime, RaysTime,rocksTime, pierTime, boatTime, campfireTime, treeTime, lightHouseTime, sailBoatTime,rainbowTime, everythingSpawnedTime;
    public int skyboxTimeInc, RaysTimeInc, rocksTimeInc, pierTimeInc, boatTimeInc, campfireTimeInc, treeTimeInc, lightHouseTimeInc, sailBoatTimeInc, rainbowTimeInc, everythingSpawnedTimeInc;
    public bool skyBoxCap, RaysCap, rockCap, pierCap, boatCap, treeCap, lightHouseCap, sailBoatCap, campCap, rainbowCap;
    public bool skySpawned, RaysSpawned,rocksSpawned, pierSpawned, boatSpawned, campfireSpawned, treeSpawned, lightHouseSpawned, sailBoatSpawned, rainbowSpawned, everythingSpawned;
    public GameObject cf;

    AudioMixerManager mixerManager;
    
    //Timer variables
    //Timer starts at 20 secs, after 10 secs passed, spawn sun, next 10 secs, spawn beach.
    //Timer starts at 20 secs, after 10 secs passed, spawn sun, if we untick the sun box, despawn sun and add 10 seconds.
    public float timeRemaining;
    public bool timerIsRunning = false;
    public bool time;
    private int addTimer = 10;
    public float timeCap;
    private float timeCounter = 3f;
    [HideInInspector] public float startingVol = -82f;
    [SerializeField] private int spawnNumber;

    public VRAvatarController PrimaryController;
    public VRAvatarController SecondaryController;

    public float translationThreshold = 0.001f;
    public float rotationThreshold = 0.001f;
    public float distanceThreshold;
    Vector3 lastPosition;
    Vector3 currentPosition;
    public float distance;
    Quaternion lastRotation;
    float idleSeconds;
    bool isMoving = false;

 
    // Hook up if condition for ismoving and not moving
    // Get all the bools to work with the if conditions
    private void Start()
    {
        mixerManager = GetComponent<AudioMixerManager>();
        // Starts the timer automatically
        timerIsRunning = true;
        // Calls TestCondition after 0 seconds 
        // and repeats every 10 seconds.         
        var RightInput = GetInput(VRInputDeviceHand.Right);
        var LeftInput = GetInput(VRInputDeviceHand.Left);
        Debug.Log("RightInput.Pointer.transform.position");
        Debug.Log("LeftInput.Pointer.transform.position");
    }
    public void Update()
    {
        MovementCheck();
        SkyboxSpawn();
        Godrays();
        RocksSpawn();
        PierSpawn();
        BoatSpawn();
        CampFireSpawn();
        TreeSpawn();
        LightHouseSpawn();
        SailBoatSpawn();
        RainbowSpawn();
        MovementCheck();

        if (timeRemaining <= everythingSpawnedTime)
        {
            everythingSpawned = true;
        }
        else
        {
            everythingSpawned = false;
        }
    }
    void SkyboxSpawn()
    {
        if (distance < distanceThreshold)
        {
            skyBoxCap = false;
            if (timeRemaining <= skyboxTime)
            {
                spawnNumber = 1;
                mixerManager.SynthChordsVolumeControl(true);
                mixerManager.IntroSynthVolumeControl(true);
                mixerManager.WindVolumeControl(true);
                mixerManager.WavesVolumeControl(true);
                mixerManager.BinuralBeatVolumeControl(true);

                skySpawned = true;
                skybox.SetBool("Spawn", true);
                skybox.SetBool("Despawn", false);
            }
            else if (timeRemaining > skyboxTime)
            {
                mixerManager.IntroSynthVolumeControl(false);
                mixerManager.SynthChordsVolumeControl(false);
                mixerManager.WindVolumeControl(false);
                skySpawned = false;
                skybox.SetBool("Despawn", true);
            }
        }
        else if (distance > distanceThreshold && skySpawned == true && skyBoxCap == false && spawnNumber == 1)
        {
            skyBoxCap = true;
            timeRemaining += skyboxTimeInc;
        }
    }
    void Godrays()
    {
        if (distance < distanceThreshold)
        {
            RaysCap = false;
            if (timeRemaining <= RaysTime)
            {
                spawnNumber = 2;
                RaysSpawned = true;
                GodRays.SetBool("Spawn", true);
                GodRays.SetBool("Despawn", false);
            }
            else if (timeRemaining > RaysTime)
            {
                RaysSpawned = false;
                GodRays.SetBool("Despawn", true);
            }
        }
        else if (distance > distanceThreshold && RaysSpawned == true && RaysCap == false && spawnNumber == 2)
        {
            RaysCap = true;
            timeRemaining += RaysTimeInc;
        }
    }
    void RocksSpawn()
    {
        if (distance < distanceThreshold)
        {
            rockCap = false;
            if (timeRemaining <= rocksTime)
            {
                spawnNumber = 3;
                rocksSpawned = true;
                rocks.SetBool("Spawn", true);
                rocks.SetBool("Despawn", false);
            }
            else if (timeRemaining > rocksTime)
            {
                rocksSpawned = false;
            }
        }
        else if (distance > distanceThreshold && rocksSpawned == true && rockCap == false && spawnNumber == 3)
        {
            rockCap = true;
            timeRemaining += rocksTimeInc;
        }
    }
    void PierSpawn()
    {
        if (distance < distanceThreshold)
        {
            pierCap = false;
            if (timeRemaining <= pierTime)
            {
                spawnNumber = 4;
                pierSpawned = true;
                mixerManager.ArpMelodyVolumeControl(true);
                pier.SetBool("Spawn", true);
                pier.SetBool("Despawn", false);
            }
            else if (timeRemaining > pierTime)
            {
                pierSpawned = false;
                pier.SetBool("Despawn", true);
                mixerManager.ArpMelodyVolumeControl(false);

            }
        }
        else if (distance > distanceThreshold && pierSpawned == true && pierCap == false && spawnNumber == 4)
        {
            pierCap = true;
            timeRemaining += pierTimeInc;
        }
    }
    void BoatSpawn()
    {
        if (distance < distanceThreshold)
        {
            boatCap = false;
            if (timeRemaining <= boatTime)
            {
                spawnNumber = 5;
                mixerManager.BoatVolumeControl(true);
                mixerManager.PianoMelodyVolumeControl(true);
                boatSpawned = true;
                boat.SetBool("Spawn", true);
                boat.SetBool("Despawn", false);
            }
            else if (timeRemaining > boatTime)
            {
                mixerManager.BoatVolumeControl(false);
                mixerManager.PianoMelodyVolumeControl(false);
                boatSpawned = false;
                boat.SetBool("Despawn", true);

            }
        }
        else if (distance > distanceThreshold && boatSpawned == true && boatCap == false && spawnNumber == 5)
        {
            boatCap = true;
            timeRemaining += boatTimeInc;
        }
    }
    void CampFireSpawn()
    {
        if (distance < distanceThreshold)
        {
            campCap = false;
            if (timeRemaining <= campfireTime)
            {
                spawnNumber = 6;
                mixerManager.CampFireVolumeControl(true);
                campfireSpawned = true;
                campfire.SetBool("Spawn", true);
                campfire.SetBool("Despawn", false);
                cf.SetActive(true);
            }
            else if (timeRemaining > campfireTime)
            {
                cf.SetActive(false);
                campfireSpawned = false;
                campfire.SetBool("Despawn", true);
                mixerManager.CampFireVolumeControl(false);

            }
        }
        else if (distance > distanceThreshold && campfireSpawned == true && campCap == false && spawnNumber == 6)
        {
            campCap = true;
            timeRemaining += campfireTimeInc;
        }
    }
    void TreeSpawn()
    {
        if (distance < distanceThreshold)
        {
            treeCap = false;
            if (timeRemaining <= treeTime)
            {
                mixerManager.TreesAndBirdsVolumeControl(true);
                spawnNumber = 7;
                treeSpawned = true;
                tree.SetBool("Spawn", true);
                tree.SetBool("Despawn", false);
            }
            else if (timeRemaining > treeTime)
            {
                mixerManager.TreesAndBirdsVolumeControl(false);
                treeSpawned = false;
                tree.SetBool("Despawn", true);
            }
        }
        else if (distance > distanceThreshold && treeSpawned == true && treeCap == false && spawnNumber == 7)
        {
            treeCap = true;
            timeRemaining += treeTimeInc;
        }
    }
    void LightHouseSpawn()
    {
        if (distance < distanceThreshold)
        {
            lightHouseCap = false;
            if (timeRemaining <= lightHouseTime)
            {
                spawnNumber = 8;
                lightHouseSpawned = true;
                lightHouse.SetBool("Spawn", true);
                lightHouse.SetBool("Despawn", false);
            }
            else if (timeRemaining > lightHouseTime)
            {
                lightHouseSpawned = false;
                lightHouse.SetBool("Despawn", true);
            }
        }
        else if (distance > distanceThreshold && lightHouseSpawned == true && lightHouseCap == false && spawnNumber == 8)
        {
            lightHouseCap = true;
            timeRemaining += lightHouseTimeInc;
        }
    }
    void SailBoatSpawn()
    {
        if (distance < distanceThreshold)
        {
            sailBoatCap = false;
            if (timeRemaining <= sailBoatTime)
            {
                spawnNumber = 9;
                sailBoatSpawned = true;
                sailBoat.SetBool("Spawn", true);
                sailBoat.SetBool("Despawn", false);
            }
            else if (timeRemaining > sailBoatTime)
            {
                sailBoatSpawned = false;
                sailBoat.SetBool("Despawn", true);
            }
        }
        else if (distance > distanceThreshold && sailBoatSpawned == true && sailBoatCap == false && spawnNumber == 9)
        {
            sailBoatCap = true;
            timeRemaining += sailBoatTimeInc;
        }
    }
    void RainbowSpawn()
    {
        if (distance < distanceThreshold)
        {
            rainbowCap = false;
            if (timeRemaining <= rainbowTime)
            {
                spawnNumber = 10;
                rainbowSpawned = true;
                rainbow.SetBool("Spawn", true);
                rainbow.SetBool("Despawn", false);
            }
            else if (timeRemaining > rainbowTime)
            {
                rainbowSpawned = false;
                rainbow.SetBool("Despawn", true);
            }
        }
        else if (distance > distanceThreshold && rainbowSpawned == true && rainbowCap == false && spawnNumber == 10)
        {
            rainbowCap = true;
            timeRemaining += rainbowTimeInc;
        }      
    }
    void MovementCheck()
    {
        lastPosition = currentPosition;
        currentPosition = PrimaryController.transform.position;

        /*if(currentPosition == lastPosition)
        {
            Debug.Log("You're not moving");
        }
        else if(currentPosition != lastPosition)
        {
            Debug.Log("You are moving");
        }*/
        distance = Vector3.Distance(currentPosition, lastPosition);
        print("Distance to other: " + distance);


        if (distance > 0.04)
        {
            Debug.Log("You are moving");
        }
        else
        {
            Debug.Log("You're not moving");
        }
        /*//calculate the direction vector between the current position and the start position
        Vector3 direction = transform.position - originPositionsObject.transform.position;
        //calculate its length
        float distance = direction.magnitude;
        //convert the float distance to the string distance: distance.ToString()
        //and show the string in the UI-text
        textField.text = distance.ToString();*/
        /*if(Insert controller details here)
        {

        }*/

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            /*else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }*/
        }

        /*if (!timerIsRunning)
        {
            timeRemaining += Time.deltaTime;
        }*/

        if (timeRemaining >= timeCap)
        {
            timerIsRunning = true;
        }
    }

    private object GetInput(VRInputDeviceHand right)
    {
        throw new NotImplementedException();
    }
    public void TimeBeforeChanging()
    {      
        Debug.Log("TimeBeforeChanging section works");
    }
    //tell the if statement if the player moved, despawn
    //if the player stops moving, respawn
    public void Timer()
    {
        if (time)
        {
            // Condition is met, cancel the repeating invoke
            // and call OnCondition, which handle the details
            // for what to do when the condition is true.
            CancelInvoke("TestCondition");
            OnTime();
        }
        else if (!time)
        {
            timeRemaining += addTimer;
        }
    }
    public void AddTime()
    {

    }
    public void OnTime()
    {
        // Enable that object that you wanted to enable.
        print("Time met!");
    }
}
