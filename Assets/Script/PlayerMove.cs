﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump = 6f;
    public float jump2 = 10f;
    public int key;

    int jumpCount = 0;

    public void Jump_Btn()
    {
        if (!DataManager.Instance.PlayerDie)
        {
            if (jumpCount == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                jumpCount += 1;

            }
            /* second jump
            else if (jumpCount == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                jumpCount += 1;
            }
            */
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Floor") == 0)
        {
            jumpCount = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 사망조건
        if(!DataManager.Instance.PlayerDie)
        {
            // 키입력
            if (key==1)
            {
                Jump_Btn();
                key = 0;
            }

        }
    }

    void getKey(string str)
    {
        if(str=="jump")
            key = 1;
        else
            key = 0;
    }
}