using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] NumberImage;
    public Sprite[] Number;
    public Image TimeBar;
    public GameObject EndPanel;
    // Start is called before the first frame update

    public void Restart_Btn()
    {
        DataManager.Instance.score = 0;
        DataManager.Instance.PlayerDie = false;
        DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
        DataManager.Instance.margnetTimeCurrent = 0;

        SceneManager.LoadScene("2");
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

        /*
        if(!DataManager.Instance.PlayerDie)
        {
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;
            TimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;
            if(DataManager.Instance.playTimeCurrent <0)
            {
                DataManager.Instance.PlayerDie = true;
            }
            if(DataManager.Instance.margnetTimeCurrent >0)
            {
                DataManager.Instance.margnetTimeCurrent -= Time.deltaTime;
            }
        }
        */

        if(DataManager.Instance.PlayerDie)
        {
            End();
        }
    }

    public void End()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
