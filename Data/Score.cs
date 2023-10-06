using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score Container = null;
    public static Score GetContainer { get { return Container; } }

    public int value = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Container == null)
        {
            Container = this;
        }
        else if (Container != this)
        {
            Destroy(this);
        };
        DontDestroyOnLoad(this.gameObject);
    }
}
