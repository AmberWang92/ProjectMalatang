using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleControl : MonoBehaviour
{
    public static int appleCount;
    public GameObject appleCountDisplay;

    // Update is called once per frame
    void Update()
    {
        appleCountDisplay.GetComponent<Text>().text = "" + appleCount;

    }
}
