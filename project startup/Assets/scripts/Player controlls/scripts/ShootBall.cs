using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Shoot")]
public class ShootBall : Ability
{
    Vector2 startPos;
    Vector2 endPos;

    public float shootDistance;

    public float lerpTimeShoot = 0.5f;
    private float currentLerpTimeShoot;

    bool BallIsFlying = false;
    bool BallReachedHalfWay = false;
    SpriteRenderer renderer;

    public override void HandleAbility(GameObject player, GameObject light)
    {
        renderer = player.GetComponent<SpriteRenderer>();
        if (Input.GetKeyDown(KeyCode.Q) && BallIsFlying == false)
        {
            startPos = light.transform.position;
            if (renderer.flipX)
            {
                endPos = light.transform.position + new Vector3(-shootDistance, 0, 0);
            }
            else
            {
                endPos = light.transform.position + new Vector3(shootDistance, 0, 0);
            }

            BallIsFlying = true;
        }
        if (BallIsFlying)
        {
            currentLerpTimeShoot += Time.deltaTime;
            if (currentLerpTimeShoot >= lerpTimeShoot)
            {
                currentLerpTimeShoot = lerpTimeShoot;
            }
            float percentage = currentLerpTimeShoot / lerpTimeShoot;

            if (!BallReachedHalfWay)
            {
                if (light.transform.position == new Vector3(endPos.x, endPos.y, 0))
                {
                    BallReachedHalfWay = true;
                    startPos = light.transform.position;
                    currentLerpTimeShoot = 0;
                }
            }
            else
            {
                endPos = player.transform.position;
                if (light.transform.position == new Vector3(endPos.x, endPos.y, 0))
                {
                    BallReachedHalfWay = false;
                    BallIsFlying = false;
                    currentLerpTimeShoot = 0;
                }
            }
            light.transform.position = Vector3.Lerp(startPos, endPos, percentage);
        }
    }
}
