using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFormTrujilloAnimatorController : MonoBehaviour
{

    Animator animator;
    private string currentState;
    Animation anim;
    public enum TrujillosFinalFormAnimation
    {
        HornOn,
        HornOff,
        CurvedHorn,
        Yelling,
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
    }




    public void HornBackOn()
    {
        ChangeAnimationState(TrujillosFinalFormAnimation.HornOn.ToString());
    }

    public void HornBackOff()
    {
        ChangeAnimationState(TrujillosFinalFormAnimation.HornOff.ToString());
    }

    public void CurvedHornAttack()
    {
        ChangeAnimationState(TrujillosFinalFormAnimation.CurvedHorn.ToString());
    }
    public void YellingAttack()
    {
        ChangeAnimationState(TrujillosFinalFormAnimation.Yelling.ToString());
    }
    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)  return;
        animator.Play(newState);
    }

    
}
