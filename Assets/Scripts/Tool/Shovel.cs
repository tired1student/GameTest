using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public GameObject ShovelText;
    public GameObject Component1;

    public static bool isFound = false;

    // Update is called once per frame
    void Update()
    {
        if (isFound && Input.GetKeyDown(KeyCode.I))
        {
            PlayerController.isShovel = true;
            Component1.SetActive(true);
            ShovelText.SetActive(true);
            gameObject.SetActive(false);
            Invoke("CloseShovelText", 2.0f);
        }
    }

    private void CloseShovelText()
    {
        Destroy(ShovelText);
        Destroy(gameObject);
    }
}
