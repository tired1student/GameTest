using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject LadderText;

    public static bool isFound = false;

    // Update is called once per frame
    void Update()
    {
        if (isFound && Input.GetKeyDown(KeyCode.I))
        {
            PlayerController.isLadder = true;
            LadderText.SetActive(true);
            gameObject.SetActive(false);
            Invoke("CloseLadderText", 2.0f);
        }
    }

    private void CloseLadderText()
    {
        Destroy(LadderText);
        Destroy(gameObject);
    }
}
