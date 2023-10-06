using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInput : MonoBehaviour
{
    [SerializeField]
    private float acceleration;

    [SerializeField]
    public float value { get; private set; }

    [SerializeField]
    private KeyCode left = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode right = KeyCode.RightArrow;

    // Update is called once per frame
    void Update()
    {
        bool isLeft = Input.GetKey(left);
        bool isRight = Input.GetKey(right);

        if (!(isLeft ^ isRight))
        {
            value /= 2.0f;
        }
        else if (isLeft)
        {
            value -= Time.deltaTime * acceleration;
        }
        else if (isRight)
        {
            value += Time.deltaTime * acceleration;
        };

        //Clamp는 value를 -1부터 1까지 사이에 있었으면 좋겠다라고 하는 거에요!
        value = Mathf.Clamp(value, -1.0f, 1.0f);
    }
}
