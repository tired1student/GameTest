using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rb;

    public float jumpForce = 5;
    public float speed = 5;

    private bool begin = false;
    private bool isDeath = false;
    private int count = 1;

    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Dialog()
    {

        if (Input.GetKeyDown(KeyCode.E) && count == 3)
        {
            dialog3.SetActive(false);
            begin = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && count == 2)
        {
            dialog2.SetActive(false);
            dialog3.SetActive(true);
            count++;
        }

        if (Input.GetKeyDown(KeyCode.E) && count == 1)
        {
            dialog1.SetActive(false);
            dialog2.SetActive(true);
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Dialog();

        if (begin)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && !isDeath)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        } else
        {
            rb.Sleep();
        }

        GotoNext();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Column")
        {
            isDeath = true;
        }
    }

    private void GotoNext()
    {
        if (isDeath)
        {
            SceneManager.LoadScene("Village");
        }
    }
}
