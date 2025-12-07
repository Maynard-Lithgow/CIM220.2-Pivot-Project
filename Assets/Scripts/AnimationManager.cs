using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    // Public array to hold AnimationClips
    public GameObject animator;
    public GameObject[] animationClipsArray;

    public float initialDelay = 0.1f; // Time before the first call
    public float repeatInterval = 20f; // Time between subsequent calls
    public GameObject chosenClip;
    public GameObject previousClip;
    void Start()
    {
        repeatInterval = 20f;

        // Call the "RepeatingFunction" after initialDelay, then repeat every repeatInterval
        InvokeRepeating("RepeatingFunction", initialDelay, repeatInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RepeatingFunction()
    {        
        GameObject previousClip = chosenClip;
                
        if (previousClip != null)
        {
            //float timer = 0.5f;
            previousClip.SetActive(false);
        }


        chosenClip = animationClipsArray[(Random.Range(0, animationClipsArray.Length))];
        chosenClip.SetActive(true);

        Debug.Log("Playing " + chosenClip);



    }
    

    // To stop the repeating call:
    public void StopRepeating()
    {
        CancelInvoke("RepeatingFunction");
    }
}
