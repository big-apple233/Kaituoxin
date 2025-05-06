using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetParameter(string parameterName, float value)
    {
        animator.SetFloat(parameterName, value);
    }
    public void SetParameter(string parameterName, bool value)
    { 
        animator.SetBool(parameterName, value);
    }
    public void SetParameter(string parameterName)
    { 
        animator.SetTrigger(parameterName);
    }
}
