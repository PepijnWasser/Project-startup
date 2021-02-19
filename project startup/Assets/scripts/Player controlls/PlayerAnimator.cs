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
        CheckPushing.pushing += PushingAnimation;
    }

    private void OnDisable()
    {
        PlayerController.moving -= MovingAnimation;
        PlayerController.jumping -= JumpingAnimation;
        CheckPushing.pushing -= PushingAnimation;
    }

    void MovingAnimation(bool val)
    {
        playerAnimator.SetBool("running", val);
    }

    void JumpingAnimation(bool val)
    {
        playerAnimator.SetBool("jumping", val);
    }

    void PushingAnimation(bool val)
    {
        playerAnimator.SetBool("pushing", val);
    }
}
