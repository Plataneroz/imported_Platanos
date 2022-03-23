using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFormTrujilloAnimatorController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    Animator animator;
    [SerializeField]
    GameObject projectile2;
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
       // projectileAnimation = projectile.GetComponent<Animation>();
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

    public void PauseAnimation()
    {
        animator.speed = 0;
    }

    public void UnPauseAnimation()
    {
        animator.speed = 1;
    }

    public void OneHornAttack()
    {
        projectile.SetActive(true);
    }

    public void BothHornsAttack()
    {
        projectile.SetActive(true);
        projectile2.SetActive(true);
    }
    public IEnumerator ResetHorn()
    {

        yield return new WaitForSeconds(3);

        projectile.SetActive(false);
        HornBackOff();
    }

}
