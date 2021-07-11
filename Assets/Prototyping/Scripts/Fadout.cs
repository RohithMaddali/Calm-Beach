using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadout : MonoBehaviour
{
    public Animator skybox, beach, ocean;
    public int skyTime, beachTime, oceanTime;
    public bool sky, oceanSpawned, beachSpawned, everythingSpawned;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(skyTime);
        skybox.SetBool("Spawn", true);
        yield return new WaitForSeconds(beachTime);
        beach.SetBool("Spawn", true);
        yield return new WaitForSeconds(oceanTime);
        ocean.SetBool("Spawn", true);
    }
}
