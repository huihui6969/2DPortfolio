using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceContainer : MonoBehaviour
{
    [SerializeField]
    public float currentValue;
    public float maxValue;
    public float minValue;

    void Update()
    {
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        if (maxValue < currentValue)
        {
            currentValue = maxValue;
        }
        if (minValue > currentValue)
        {
            currentValue = minValue;
        }

    }
}
