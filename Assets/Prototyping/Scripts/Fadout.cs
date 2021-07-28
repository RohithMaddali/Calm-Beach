using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR.Input;
using Liminal.SDK.Core;
using UnityEngine;

public class Fadout : MonoBehaviour
{
    //Spawning/Animating variables
    public Animator skybox, beach, ocean, pier, rock, umbrella, bird, wall, rainbow;
    public int skyboxTime, beachTime, oceanTime, pierTime, rockTime, umbrellaTime, birdTime, wallTime, rainbowTime, everythingSpawnedTime;
    public bool skySpawned, beachSpawned, oceanSpawned, pierSpawned, rockSpawned, umbrellaSpawned, birdSpawned, wallSpawned, rainbowSpawned, everythingSpawned;

    //Timer variables
    //Timer starts at 20 secs, after 10 secs passed, spawn sun, next 10 secs, spawn beach.
    //Timer starts at 20 secs, after 10 secs passed, spawn sun, if we untick the sun box, despawn sun and add 10 seconds.
    public float timeRemaining;
    public bool timerIsRunning = false;
    public bool time;
    private int addTimer = 10;
    public float timeCap;
    private float timeCounter = 3f;
    

    public VRAvatarController PrimaryController;
    public VRAvatarController SecondaryController;

    public float translationThreshold = 0.001f;
    public float rotationThreshold = 0.001f;

    Vector3 lastPosition;
    Vector3 currentPosition;
    Quaternion lastRotation;
    float idleSeconds;
    bool isMoving = false;
    
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        // Calls TestCondition after 0 seconds 
        // and repeats every 10 seconds.              
    }

    public void Update()
    {
        
        lastPosition = currentPosition;
        currentPosition = PrimaryController.transform.position;
        
        if(currentPosition == lastPosition)
        {
            Debug.Log("You're not moving");
        }
        else if(currentPosition != lastPosition)
        {
            Debug.Log("You are moving");
        }


        if (timeRemaining <= skyboxTime)
        {
            if(isMoving == false)
            {
                skySpawned = true;
                skybox.SetBool("spawn", true);                
            }
            else if(isMoving == true)
            {
                skybox.SetBool("despawn", false);
                Debug.Log("Time section works here too");
            }
            
        }
        else if (timeRemaining >= skyboxTime && skySpawned == true)
        {
            skySpawned = false;
            skybox.SetBool("despawn", true);
        }

        if (timeRemaining <= beachTime)
        {
            beachSpawned = true;
            beach.SetBool("spawn", true);
            beach.SetBool("despawn", false);
        }
        else if (timeRemaining >= beachTime && beachSpawned == true)
        {
            beachSpawned = false;
            beach.SetBool("despawn", true);
        }

        if (timeRemaining <= oceanTime)
        {
            oceanSpawned = true;
            ocean.SetBool("spawn", true);
            ocean.SetBool("despawn", false);
        }
        else if (timeRemaining >= oceanTime && oceanSpawned == true)
        {
            oceanSpawned = false;
            ocean.SetBool("despawn", true);
        }

        if (timeRemaining <= pierTime)
        {
            pierSpawned = true;
           // pier.SetBool("spawn", true);
           // pier.SetBool("despawn", false);
        }
        else if (timeRemaining >= pierTime && pierSpawned == true)
        {
            pierSpawned = false;
           // pier.SetBool("despawn", true);

        }

        if (timeRemaining <= rockTime)
        {
            rockSpawned = true;
            rock.SetBool("spawn", true);
            rock.SetBool("despawn", false);
        }
        else if (timeRemaining >= rockTime && rockSpawned == true)
        {
            rockSpawned = false;
            rock.SetBool("despawn", true);
        }

        if (timeRemaining <= umbrellaTime)
        {
            umbrellaSpawned = true;
        }
        else
        {
            umbrellaSpawned = false;
        }

        if (timeRemaining <= birdTime)
        {
            birdSpawned = true;
        }
        else
        {
            birdSpawned = false;
        }

        if (timeRemaining <= wallTime)
        {
            wallSpawned = true;
        }
        else
        {
            wallSpawned = false;
        }

        if (timeRemaining <= rainbowTime)
        {
            rainbowSpawned = true;
        }
        else
        {
            rainbowSpawned = false;
        }

        if (timeRemaining <= everythingSpawnedTime)
        {
            everythingSpawned = true;
        }
        else
        {
            everythingSpawned = false;
        }

        /*if(Insert controller details here)
        {

        }*/

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        if (!timerIsRunning)
        {
            timeRemaining += Time.deltaTime;
        }

        if (timeRemaining >= timeCap)
        {
            timerIsRunning = true;
        }
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
