using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class counteringridients : MonoBehaviour
{
    public static counteringridients instance;
    public TMP_Text ingrText;
    public int currentIngr = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateIngrText(); 
    }

    public void IncreaseIngr(int v)
    {
        currentIngr += v; 
        UpdateIngrText(); 
    }

    void UpdateIngrText()
    {
        ingrText.text = "Ingredients: " + currentIngr.ToString();
    }
}
