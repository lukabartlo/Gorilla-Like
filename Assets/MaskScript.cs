using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskScript : MonoBehaviour
{

    public GameObject Player;
    public RectMask2D maskarrow;
    // Update is called once per frame
    void Update()
    {
        maskarrow.padding = new Vector4(0, 0, 400f - Player.GetComponent<Player>().force/25 * 400, 0);
    }
}
