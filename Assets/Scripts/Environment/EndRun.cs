using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRun : MonoBehaviour
{
    public GameObject FoodAccount;
    public GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(2);
        FoodAccount.SetActive(false);
        EndScreen.SetActive(true);

    }
}
