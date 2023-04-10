using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�����õ��޸ġ���tired1student

    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D col;

    public float speed = 2.5f;

    public static bool isLadder = false;
    public static bool isShovel = false;
    public static int componentsCount = 0;

    public int debug = 0;

    //�ı�
    public GameObject HintText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //��ҵ��ƶ�
    private void Movement()
    {
        float horizontalMove, verticalMove;
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        }

        if (verticalMove != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalMove * speed);
        }

        SwitchAnim(horizontalMove, verticalMove);
    }

    //������ת��
    private void SwitchAnim(float horizontalMove, float verticalMove)
    {
        if (horizontalMove == 0 && verticalMove == 0)
        {
            anim.SetBool("Idle", true);
        } else
        {
            anim.SetBool("Idle", false);
        }

        if (horizontalMove > 0)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", true);
            anim.SetBool("Forward", false);
            anim.SetBool("Back", false);
        } else if (horizontalMove < 0)
        {
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
            anim.SetBool("Forward", false);
            anim.SetBool("Back", false);
        } else if (verticalMove > 0)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Forward", false);
            anim.SetBool("Back", true);
        } else if (verticalMove < 0)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Forward", true);
            anim.SetBool("Back", false);
        }
    }

    //�����ײTrigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            //��ײ�����ı����z��
            case "Tree":
                transform.position = new Vector3(transform.position.x, transform.position.y, 1);
                break;

            //��������
            case "Ladder":
                HintText.SetActive(true);
                Ladder.isFound = true;
                break;

            //��������
            case "Shovel":
                HintText.SetActive(true);
                Shovel.isFound = true;
                break;

            //�������
            case "Components":
                HintText.SetActive(true);
                ComponentController.isFound = true;
                break;
        }
    }

    //�Ƴ���ײ
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Tree":
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                break;

            case "Components":
                HintText.SetActive(false);
                ComponentController.isFound = false;
                break;

            case "Ladder":
                HintText.SetActive(false);
                Ladder.isFound = false;
                break;

            case "Shovel":
                HintText.SetActive(false);
                Shovel.isFound = false;
                break;

            case "SetLadder":
                HintText.SetActive(false);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SetLadder" && isLadder)
        {
            HintText.SetActive(true);
            SetLadder.isFound = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SetLadder" && isLadder)
        {
            HintText.SetActive(false);
            SetLadder.isFound = false;
        }
    }
}
