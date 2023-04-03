using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [TextArea(1, 3)] public string[] DialogTextList;
    public Text DialogText;
    public GameObject panel;
    public int TextIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        DialogTextList = new string[10];
        DialogTextList[0] = "第一句话";
        DialogTextList[1] = "第二句话";
        DialogTextList[2] = "第三句话";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (TextIndex >= DialogTextList.Length)
            {
                CloseText();
            }
            panel.SetActive(true);
            DialogText.text = DialogTextList[TextIndex];
            TextIndex++;
        }
    }

    private void CloseText()
    {
        panel.SetActive(false);
    }
}
