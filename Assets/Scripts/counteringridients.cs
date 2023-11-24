using UnityEngine;
using TMPro;

public class counteringridients : MonoBehaviour
{
    public static counteringridients instance; // Add this line

    public TMP_Text ingrText;
    public int currentIngr = 0;

    void Awake()
    {
        instance = this; // Add this line
    }

    void Start()
    {
        UpdateIngrText();
    }

    public void IncreaseIngr(int v)
    {
        currentIngr += v;
        UpdateIngrText();
        Debug.Log("Ingredients increased. Current count: " + currentIngr);
    }

    public void DecreaseIngr(int v)
    {
        currentIngr -= v;
        UpdateIngrText();
        Debug.Log("Ingredients decreased. Current count: " + currentIngr);
    }

    void UpdateIngrText()
    {
        ingrText.text = "Ingredients: " + currentIngr.ToString();
    }
}
