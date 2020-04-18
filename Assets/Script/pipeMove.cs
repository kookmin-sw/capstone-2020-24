using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMove : MonoBehaviour
{
    public float pipeSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.playerDie)
        {
            transform.Translate(-pipeSpeed * Time.deltaTime, 0, 0);

            if (transform.position.x <= -4f)
            {
                Destroy(gameObject);
            }
        }
    }
}
