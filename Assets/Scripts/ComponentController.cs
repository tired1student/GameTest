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

    //��ײ����������ı�
    private void CloseComponentText()
    {
        ComponentText.SetActive(false);
        Destroy(gameObject);
    }
}
