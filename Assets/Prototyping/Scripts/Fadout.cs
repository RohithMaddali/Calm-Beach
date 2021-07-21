using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadout : MonoBehaviour
{
    //Spawning/Animating variables
    public Animator skybox, beach, ocean, pier, rock, umbrella, bird, wall, rainbow;
    public int skyboxTime, beachTime, oceanTime, pierTime, rockTime, umbrellaTime, birdTime, wallTime, rainbowTime, everythingSpawnedTime;
    public bool skySpawned, beachSpawned, oceanSpawned, pierSpawned, rockSpawned, umbrellaSpawned, birdSpawned, wallSpawned, rainbowSpawned, everythingSpawned;
        
    //Timer variables
    public float timeRemaining;
    public bool timerIsRunning = false;
    public bool time;
    private int addTimer = 10;
    //Timer starts at 20 secs, after 10 secs passed, spawn sun, next 10 secs, spawn beach.
    //Timer starts at 20 secs, after 10 secs passed, spawn sun, if we untick the sun box, despawn sun and add 10 seconds.

    private void Start()
    {
        
        // Starts the timer automatically
        timerIsRunning = true;
        // Calls TestCondition after 0 seconds 
        // and repeats every 10 seconds.      

    }

    public void Update()
    {
        if (timeRemaining <= skyboxTime)
        {
            skySpawned = true;
        }
        else
        {
            skySpawned = false;
        }        

        if (timeRemaining <= beachTime)
        {
            beachSpawned = true;
            beach.SetBool("spawn", true);
            beach.SetBool("despawn", false);
        }
        else
        {
            beachSpawned = false;
            
        }

        if (timeRemaining <= oceanTime)
        {
            oceanSpawned = true;
            ocean.SetBool("spawn", true);
            ocean.SetBool("despawn", false);
        }
        else
        {
            oceanSpawned = false;
            
        }

        if (timeRemaining <= pierTime)
        {
            pierSpawned = true;
            pier.SetBool("spawn", true);
            pier.SetBool("despawn", false);
        }
        else
        {
            pierSpawned = false;
            
        }

        if (timeRemaining <= rockTime)
        {
            rockSpawned = true;
            rock.SetBool("spawn", true);
            rock.SetBool("despawn", false);
        }
        else
        {
            rockSpawned = false;
            
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
           wallSpawned  = false;
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
    }

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
        else if(!time)
        {
            timeRemaining += addTimer;
        }
        
    }

    public void OnTime()
    {
        // Enable that object that you wanted to enable.
        print("Time met!");
    }
}
