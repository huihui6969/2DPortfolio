using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueComponent : MonoBehaviour
{
    [Range(-1.0f, 1.0f)]
    public float value;
}