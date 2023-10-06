using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Floating : MonoBehaviour
{
    private Vector3 origin;

    private float value = 0.0f;

    [SerializeField]
    private float amp;

    [SerializeField]
    private float speed = 1.0f;

    void Start()
    {
        origin = transform.position;
    }

    void Update()
    {
        value += Time.deltaTime * speed;
        transform.position = origin + (Vector3.up * Mathf.Sin(value) * amp);

    }
}
