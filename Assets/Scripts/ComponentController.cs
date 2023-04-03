using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    public static bool isFound = false;
    public GameObject ComponentText;

    // Update is called once per frame
    void Update()
    {
        if (isFound && Input.GetKeyDown(KeyCode.I))
        {
            PlayerController.componentsCount++;
            ComponentText.SetActive(true);
            gameObject.SetActive(false);
            Invoke("CloseComponentText", 2.0f);
        }
    }

    //碰撞零件，设置文本
    private void CloseComponentText()
    {
        ComponentText.SetActive(false);
        Destroy(gameObject);
    }
}
