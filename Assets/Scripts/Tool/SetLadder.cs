using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetLadder : MonoBehaviour
{
    public static bool isFound = false;

    private BoxCollider2D col;
    private TilemapRenderer ren;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        ren = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFound && Input.GetKeyDown(KeyCode.I))
        {
            ren.enabled = true;
            col.isTrigger = true;
        }
    }
}
