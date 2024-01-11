using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [Inject] PlayerAction playerAction;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetAnimation();
    }

    private void SetAnimation()
    {
        if (!playerAction.isRunning && !playerAction.isSprinting)
            _animator.SetFloat("Movement", 0f);
        else if (playerAction.isRunning)
            _animator.SetFloat("Movement", 0.5f);
        else if (playerAction.isSprinting)
            _animator.SetFloat("Movement", 1f);

        if (playerAction.groundController.isGrounded)
        {
            _animator.SetBool("IsJumping", false);
        }
        else if (playerAction.isJumping && !playerAction.groundController.isGrounded)
        {
            _animator.SetBool("IsJumping", true);
        }
    }

}
