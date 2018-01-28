﻿using UnityEngine;
using UnityEngine.UI;

public class PowerGaugeController : MonoBehaviour {


	public Image power_gauge;
	public Image gauge_background;

	public AudioClip electric_current_sound;

	public bool power_up_time;
	private bool power_up_sound;

	TrainPath trainPath;

	void Start() 
	{

		power_up_time = false;
		power_up_sound = false;
		trainPath = this.GetComponent<TrainPath>();
	}
	
	void Update() 
	{
		if(Input.GetKeyDown(KeyCode.Space) && power_up_time == false && trainPath.moving == false)
		{

			power_gauge.gameObject.SetActive(true);
			gauge_background.gameObject.SetActive(true);
			power_up_time = true;

			if(power_up_sound == false)
			{
				GetComponent<AudioSource>().clip = electric_current_sound;
				GetComponent<AudioSource>().Play();
				power_up_sound = true;
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space) && power_up_time == true && trainPath.moving == false)
		{

			power_up_time = false;
			power_gauge.gameObject.SetActive(false);
			gauge_background.gameObject.SetActive(false);
			trainPath.power = power_gauge.fillAmount * 50;
			trainPath.moving = true;
		}

		if(power_up_time == true && power_gauge.fillAmount < 1)
		{

			power_gauge.fillAmount += 0.7f * Time.deltaTime;
		}
		else if(power_up_time == true && power_gauge.fillAmount >= 1)
		{

			power_up_time = false;
			power_gauge.gameObject.SetActive(false);
			gauge_background.gameObject.SetActive(false);
			trainPath.power = power_gauge.fillAmount * 50;
			trainPath.moving = true;
		}

	}
}