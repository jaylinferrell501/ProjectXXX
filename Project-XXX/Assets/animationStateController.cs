using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    // Our Animator reference variable
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        // unsing unitys build Get component function
        animator = GetComponent<Animator>();
        // just converting our string into a int for faster data type
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        // if player is pressing w...
        if (!isWalking && forwardPressed)
        {
            // Set our isWalking boolean to true
            animator.SetBool(isWalkingHash, true);
        }

        // if the player is not pressing w...
        if (isWalking && !forwardPressed)
        {
            // Set our isWalking boolean to false
            animator.SetBool(isWalkingHash, false);
        }

        // if the player is walking and pressing left shift..
        if (!isRunning && (forwardPressed && runPressed))
        {
            // Set our isWalking boolean to false
            animator.SetBool(isRunningHash, true);
        }

        // if the player is walking and not pressing left shift...
        if (isRunning && (!forwardPressed || !runPressed))
        {
            // Set our isWalking boolean to false
            animator.SetBool(isRunningHash, false);
        }



    }
}
