using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByValue : ValueComponent
{
    public float speed;
    public float limit;

    [SerializeField]
    private Rigidbody2D rigid;

    void Update()
    {
        bool controllable = true;
        if (Mathf.Abs(rigid.velocity.x) > speed) controllable = false;

        // (value < -0.1f || value > 0.1f)
        if (Mathf.Abs(value) > 0.1f && controllable)
        {
            rigid.AddForce(Vector2.right * value * speed);
            rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -limit, limit), rigid.velocity.y);
        }
        else
        {
            if (rigid.velocity.x < -speed)
            {
                rigid.velocity = new Vector2(rigid.velocity.x + (speed / 2), rigid.velocity.y);
            }
            else if (rigid.velocity.x > speed)
            {
                rigid.velocity = new Vector2(rigid.velocity.x - (speed / 2), rigid.velocity.y);
            }
            else
            {
                rigid.velocity = new Vector2(rigid.velocity.x * 0.95f, rigid.velocity.y);
            };
        };
    }
}
