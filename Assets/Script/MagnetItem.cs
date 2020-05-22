using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    public void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("PlayerPosition");
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if (DataManager.Instance.PlayerDie == false && DataManager.Instance.margnetTimeCurrent > 0)
        {
            if (distance < 2)
            {
                Vector2 dir = player.transform.position - transform.position;
                transform.Translate(dir.normalized * DataManager.Instance.itemMoveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!DataManager.Instance.PlayerDie)
        {
            if(collision.gameObject.tag.CompareTo("Player")==0)
            {
                DataManager.Instance.margnetTimeCurrent = DataManager.Instance.margnetTimeMax;
                gameObject.SetActive(false);
            }

        }
    }
}
