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
    public GameObject chattingBackground;

    #region Bad end information

    public float badEndTimer;
    public GameObject badEndClip;
    public GameObject aloneClip;
    public GameObject aloneBackground;
    private bool badEndTriggered;
    public float badEndClipTime;
    private bool aloneBackgroundBool;
    public float badMiniTimerMax;
    public float badMiniTimer;


    #endregion

    #region Happy stuff

    public float goodEndTimer;
    public float goodEndTimerMax;
    public GameObject goodEndClip;
    public bool goodEndTriggered;
    public GameObject gameHands;
    public Transform gameHandsDown;
    public float handsSpeed;

    #endregion

    public SceneLoader endGameScreen;
    public float endTimer;


    void Start()
    {
        repeatInterval = 20f;
        badEndTimer = 100; //MUST BE IN 20 SECOND INCRIMENTS
        badEndTriggered = false;
        badEndClipTime = 29f;
        aloneBackgroundBool = false;
        badMiniTimerMax = 6;
        badMiniTimer = badMiniTimerMax;

        goodEndTimerMax = 15;
        goodEndTimer = goodEndTimerMax;
        goodEndTriggered = false;
        handsSpeed = 1f;

        endTimer = 15f;
        

        // Call the "RepeatingFunction" after initialDelay, then repeat every repeatInterval
        InvokeRepeating("RepeatingFunction", initialDelay, repeatInterval);
    }


    void Update()
    {
        #region bad end stuff

        badEndTimer -= Time.deltaTime;

        if (badEndTimer <= 0 && badEndTriggered == false)
        {
            TriggerBadEnd();

            //gameHands.transform.position = Vector3.MoveTowards(gameHands.transform.position, gameHandsDown.transform.position, handsSpeed * Time.deltaTime); not yet
        }
        else if (badEndTriggered == true)
        {
            goodEndTimer = 100;

            //badMiniTimer -= Time.deltaTime; not yet

        }

        if (badMiniTimer < 0)
        {
            Debug.Log("Alone screen time");
            aloneClip.SetActive(true);

            aloneBackground.SetActive(false);

            gameHands.transform.position = Vector3.MoveTowards(gameHands.transform.position, gameHandsDown.transform.position, handsSpeed * Time.deltaTime);

        }

        if (badEndTriggered == true)
        {
            badEndClipTime -= Time.deltaTime; //Countdown for friends leaving clip
            goodEndTimer = 100;
        }

        if (badEndClipTime < 29 && badEndClipTime > 27)
        {
            chattingBackground.SetActive(false);
            chosenClip.SetActive(false);
            Debug.Log("chatting background & chosen clip off");

        }
        else if (badEndClip != null && badEndClipTime <= 0) //waiting for bad end triggered
        {
            Debug.Log("Clip over?");
            aloneBackground.SetActive(true); //Turn on alone background
            aloneBackgroundBool = true;

            badEndClip.SetActive(false); //Turn off video

            //Now it's just the background and the phone

            badMiniTimer -= Time.deltaTime;


            


        }
        
        if (aloneBackgroundBool == true)
        {
            Debug.Log("alone background activated");
            aloneClip.SetActive(true);

            LoadMenu();
        }
        #endregion

        #region happy stuff

        goodEndTimer -= Time.deltaTime; //shorter than bad end, but resets on minigame click

        if (goodEndTimer <= 0 && goodEndTriggered == false)
        {
            TriggerGoodEnd();
        }
        else if (goodEndTriggered == true)
        {
            badEndTimer = 100; //Makes so the bad end can't happen?

            gameHands.transform.position = Vector3.MoveTowards(gameHands.transform.position, gameHandsDown.transform.position, handsSpeed * Time.deltaTime);

            LoadMenu();
        }


        #endregion
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
    public void TriggerBadEnd()
    {
        Debug.Log("Bad ending triggered once");
        badEndTriggered = true;

        StopRepeating();

        badEndClip.SetActive(true);


        //aloneBackground.SetActive(true);

    }
    public void TriggerGoodEnd()
    {
        Debug.Log("Good end triggered once");
        goodEndTriggered = true;

        StopRepeating();

        GameObject previousClip = chosenClip;

        if (chosenClip != null)
        {

            chosenClip.SetActive(false);
        }

        goodEndClip.SetActive(true);


    }
    public void ResetHappyTimer()
    {
        
        if (badEndTriggered == false)
        {
            goodEndTimer = goodEndTimerMax;
            Debug.Log("happy timer reset");
        }
        else
        {
            badMiniTimer = badMiniTimerMax;
            Debug.Log("Bad mini timer reset");
        }
    }
    public void LoadMenu()
    {
        endTimer -= Time.deltaTime;
        if (endTimer < 0)
        {
            endGameScreen.LoadTitleScene();
        }
    }
}
