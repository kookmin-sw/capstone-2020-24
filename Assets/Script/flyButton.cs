using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyButton : MonoBehaviour
{
    public float birdJump = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.playerDie)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, birdJump, 0);

                transform.rotation = Quaternion.Euler(0, 0, 30f);
            }
            transform.Rotate(0, 0, -1f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Pipe_Ground")==0)
        {
            GameManager.playerDie = true;
        }
    }
}
