using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] NumberImage;
    public Sprite[] Number;
    public Image TimeBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int temp = DataManager.Instance.score / 100;
        NumberImage[0].GetComponent<Image>().sprite = Number[temp];
        int temp2 = DataManager.Instance.score % 100;
        temp2 /= 10;
        NumberImage[1].GetComponent<Image>().sprite = Number[temp2];
        int temp3 = DataManager.Instance.score % 10;
        NumberImage[2].GetComponent<Image>().sprite = Number[temp3];


        if(!DataManager.Instance.PlayerDie)
        {
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;
            TimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;
            if(DataManager.Instance.playTimeCurrent <0)
            {
                DataManager.Instance.PlayerDie = true;
            }
        }
    }
}
