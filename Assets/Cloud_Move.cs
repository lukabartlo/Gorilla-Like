using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud_Move : MonoBehaviour
{
    [Range(-100f,100f)]
    public float ScrollSpeed = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform Cloud = transform.GetChild(i);
            Cloud.transform.position += new Vector3((ScrollSpeed / Cloud.transform.position.z) * Time.deltaTime, 0, 0);
            if (Cloud.transform.position.x > 30)
            {
                Cloud.transform.position = new Vector3(-30, Cloud.transform.position.y, Cloud.transform.position.z);
            }
        }
        
    }
}
