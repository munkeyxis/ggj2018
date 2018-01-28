using UnityEngine;
using UnityEngine.UI;

public class PowerGaugeController : MonoBehaviour {

	public Image power_gauge;


	public AudioClip electric_current_sound;

	public bool power_up_time;
	public bool power_click;

	private bool power_up_sound;

	private TrainPath trainPath;


	void Start() 
	{

		power_up_time = false;
		power_up_sound = false;
		power_click = false;

	}
	
	void Update() 
	{
		if(power_click == true && power_up_time == false)
		{

			power_up_time = true;
			Debug.Log("Power click is" + power_click);

			if(power_up_sound == false)
			{
				GetComponent<AudioSource>().clip = electric_current_sound;
				GetComponent<AudioSource>().Play();
				power_up_sound = true;
			}
		}

		if(power_click == false && power_up_time == true)
		{

			Debug.Log("Now Power click is" + power_click);
			power_up_time = false;
			trainPath.power = power_gauge.fillAmount * 200;
            trainPath.moving = true;

            gameObject.SetActive(false);
			
			
		}

		if(power_up_time == true && power_gauge.fillAmount < 1)
		{

			power_gauge.fillAmount += 0.7f * Time.deltaTime;
		}
		else if(power_up_time == true && power_gauge.fillAmount >= 1)
		{

			power_up_time = false;
			trainPath.power = power_gauge.fillAmount * 200;
            trainPath.moving = true;
            gameObject.SetActive(false);
			
		}

	}

	public void ActivePowerGauge(TrainPath train)
	{
		trainPath = train;
		gameObject.SetActive(true);
	}
}
