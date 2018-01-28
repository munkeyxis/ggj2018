using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButtonController : MonoBehaviour {


	
	public PowerGaugeController powergaugecontroller;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PowerOn(){
		
		powergaugecontroller.power_click = !powergaugecontroller.power_click;
	}
}
