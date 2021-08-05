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
    public float distance;
    Quaternion lastRotation;
    float idleSeconds;
    bool isMoving = false;

    
    // Hook up if condition for ismoving and not moving
    // Get all the bools to work with the if conditions


    private void Start()
    {
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
        
            
        if(distance > 0.04)
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

        if(distance < 0.04f)
        {
            if (timeRemaining <= skyboxTime)
            {
                //if (isMoving == false)
                {
                    skySpawned = true;
                    skybox.SetBool("spawn", true);
                    Debug.Log("Skybox spawned");
                }
                //else if (isMoving == true)
                {
                    skybox.SetBool("despawn", false);

                    Debug.Log("Skybox despawned");
                }

            }
        }
        else if(distance > 0.04f)
        {
            //if (timeRemaining >= skyboxTime && skySpawned == true)
            {
                skySpawned = false;
                skybox.SetBool("despawn", true);
                Debug.Log("Skybox despawned in else if statement");
            }
        }
        

        if (distance < 0.04f)
        {
            if (timeRemaining <= beachTime)
            {
                beachSpawned = true;
                beach.SetBool("spawn", true);
                beach.SetBool("despawn", false);
            }
        }
        else if (distance > 0.04f)
        {
            //if (timeRemaining >= beachTime && beachSpawned == true)
            {
                beachSpawned = false;
                beach.SetBool("despawn", true);
            }
        }

        if (distance < 0.04f)
        {
            if (timeRemaining <= oceanTime)
            {
                oceanSpawned = true;
                ocean.SetBool("spawn", true);
                ocean.SetBool("despawn", false);
            }
        }
        else if (distance > 0.04f)
        {
            //if (timeRemaining >= oceanTime && oceanSpawned == true)
            {
                oceanSpawned = false;
                ocean.SetBool("despawn", true);
            }
        }

        if (distance < 0.04f)
        {
            if (timeRemaining <= pierTime)
            {
                pierSpawned = true;
                // pier.SetBool("spawn", true);
                // pier.SetBool("despawn", false);
            }
        }
        else if (distance > 0.04f)
        {
            //if (timeRemaining >= pierTime && pierSpawned == true)
            {
                pierSpawned = false;
                // pier.SetBool("despawn", true);

            }
        }


        if (distance < 0.04f)
        {
            if (timeRemaining <= rockTime)
            {
                rockSpawned = true;
                rock.SetBool("spawn", true);
                rock.SetBool("despawn", false);
            }
        }
        else if (distance > 0.04f)
        {
            //if (timeRemaining >= rockTime && rockSpawned == true)
            {
                rockSpawned = false;
                rock.SetBool("despawn", true);
            }
        }

        if (distance < 0.04f)
        {
            if (timeRemaining <= umbrellaTime)
            {
                umbrellaSpawned = true;
            }
        }
        else if (distance > 0.04f)
        {
             
            {
                umbrellaSpawned = false;
            }
        }

        if (distance < 0.04f)
        {

        }
        else if (distance > 0.04f)
        {

        }

        if (distance < 0.04f)
        {

        }
        else if (distance > 0.04f)
        {

        }

        if (distance < 0.04f)
        {

        }
        else if (distance > 0.04f)
        {

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
