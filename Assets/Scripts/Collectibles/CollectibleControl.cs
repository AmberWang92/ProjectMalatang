using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleControl : MonoBehaviour
{
    public static int appleCount;
    public GameObject appleCountDisplay;
    public GameObject appleEndDisplay;
    public static int carrotCount;
    public GameObject carrotCountDisplay;
    public GameObject carrotEndDisplay;
    public static int fishCount;
    public GameObject fishCountDisplay;
    public GameObject fishEndDisplay;

    // Update is called once per frame
    void Update()
    {
        appleCountDisplay.GetComponent<Text>().text = "" + appleCount;
        appleEndDisplay.GetComponent<Text>().text = "" + appleCount;
        carrotCountDisplay.GetComponent<Text>().text = "" + carrotCount;
        carrotEndDisplay.GetComponent<Text>().text = "" + carrotCount;
        fishCountDisplay.GetComponent<Text>().text = "" + fishCount;
        fishEndDisplay.GetComponent<Text>().text = "" + fishCount;

    }
}
