using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWhenInSphere : MonoBehaviour
{
    public LayerMask layerMask;

    private void Update()
    {
        Vector2 bottomLeftCorner = new Vector2(transform.position.x, transform.position.y) - new Vector2(transform.localScale.x / 2, transform.localScale.y / 2);
        Vector2 topRightCorner = new Vector2(transform.position.x, transform.position.y) + new Vector2(transform.localScale.x / 2, transform.localScale.y / 2);

        Collider2D collider = Physics2D.OverlapArea(bottomLeftCorner, topRightCorner, layerMask);
        if (collider != null)
        {
            Destroy(this.gameObject);
        }

    }
}
