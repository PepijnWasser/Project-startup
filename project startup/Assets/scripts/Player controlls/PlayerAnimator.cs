using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAnimator;

    private void OnEnable()
    {
        PlayerController.moving += MovingAnimation;
        PlayerController.jumping += JumpingAnimation;
    }

    private void OnDisable()
    {
        PlayerController.moving -= MovingAnimation;
        PlayerController.jumping -= JumpingAnimation;
    }

    void MovingAnimation(bool val)
    {
        playerAnimator.SetBool("running", val);
    }

    void JumpingAnimation(bool val)
    {
        playerAnimator.SetBool("jumping", val);
    }
}
