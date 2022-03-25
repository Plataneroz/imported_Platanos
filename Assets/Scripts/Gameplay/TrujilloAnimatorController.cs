using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrujilloAnimatorController : MonoBehaviour
{

    Animator animator;
    private string currentState;
    
    public enum TrujillosAnimation
    {
        
        PhaseOne,
        PhaseTwo,
        PhaseThree,
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
    }




    public void AnimatePhaseOne()
    {
        ChangeAnimationState(TrujillosAnimation.PhaseOne.ToString());
    }

    public void AnimatePhaseTwo()
    {
        ChangeAnimationState(TrujillosAnimation.PhaseTwo.ToString());
    }

    public void AnimatePhaseThree()
    {
        ChangeAnimationState(TrujillosAnimation.PhaseThree.ToString());
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)  return;
        animator.Play(newState);
    }

    
}
