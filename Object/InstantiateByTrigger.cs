using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateByTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Vector3 location;

    [SerializeField]
    private bool islocalPosition;

    [SerializeField]
    private string targetTag;

    [SerializeField]
    private float destoryTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            GameObject result = Instantiate(prefab);

            result.transform.position = location;

            if (islocalPosition)
            {
                result.transform.position += transform.position;
            };

            Destroy(result, destoryTime);
        };
        
    }
}
