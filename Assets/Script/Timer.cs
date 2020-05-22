using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	Slider timer;
	float sliderBarTime;

	void Start()
	{
		timer = GetComponent<Slider>();
	}

	void Update()
	{
		if(timer.value > 0.0f)
			timer.value -= Time.deltaTime;
		else
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
