using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        bool isDash = context.ReadValue<float>() > 0;

        animator.SetBool("isDash", isDash);
    }

    public void SetAnimByCharacter(RuntimeAnimatorController anim)
    {
        animator.runtimeAnimatorController = anim;
    }
}
