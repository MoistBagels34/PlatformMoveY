using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlatformMoveY : MonoBehaviour
{

    public float topLimit = 2.5f;
    public float bottomLimit = 1.0f;
    public float speed = 2.0f;
    private int direction = 1;
    private Vector2 movement;
    private object coll;

    private static object GetDebuggerDisplay()
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        if (transform.position.y > topLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < bottomLimit)
        {
            direction = 1;
        }
        movement = Vector2.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

} 