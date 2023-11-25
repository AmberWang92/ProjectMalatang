using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleControl : MonoBehaviour
{
    public static int foodCount;
    public GameObject foodCountDisplay;

    // Update is called once per frame
    void Update()
    {
        foodCountDisplay.GetComponent<Text>().text = "+ foodCount";
    }
}
