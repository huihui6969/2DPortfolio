using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container2Percentage : MonoBehaviour
{
    public ResourceContainer container;

    [SerializeField]
    private Image target;

    [SerializeField]
    private GameObject healthBack;

    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (healthBack != null)
        {
            if (container == null)
            {
                healthBack.SetActive(false);
                return;
            }
            else
            {
                healthBack.SetActive(true);
            }
        }

        float percent = (float)container.currentValue / container.maxValue;

        target.fillAmount = percent;
    }
}
