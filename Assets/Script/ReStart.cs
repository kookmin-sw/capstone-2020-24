using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public void RePlay()
    {
    	DataManager.Instance.PlayerDie = false;
    	DataManager.Instance.score = 0;
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
