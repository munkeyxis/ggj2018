﻿using UnityEngine;
using UnityEngine.UI;

public class TrainPath : MonoBehaviour {

    public GameObject initialTarget;
	public float speed;
	public float rotate_speed;
	public float power;

	public Text left_text;
	public Text right_text;

	public bool moving;
	public bool power_time;
	public bool train_sound_bool;

	public AudioClip steam_train;

    private GameObject targetGameObject;
    private bool launchTrain;
    private int launchTimer = 0;

	void Start () {
        targetGameObject = initialTarget;
		moving = false;
        launchTrain = false;
		power_time = false;
		train_sound_bool = false;
	}

    void Update()
    {
        if (moving == true)
        {
        	if(train_sound_bool == false && speed > 0)
        	{
        		GetComponent<AudioSource>().clip = steam_train;
				GetComponent<AudioSource>().Play();
				train_sound_bool = true;
        	}

            Vector2 pos = Vector2.MoveTowards(transform.position, targetGameObject.transform.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);

            if (transform.position == targetGameObject.transform.position)
            {
                if(!targetGameObject.GetComponent<TargetOptions>().noTarget)
                {
                    targetGameObject = targetGameObject.GetComponent<TargetOptions>().GetNextSegmentTarget();
                    LookAtTarget();
                }
                else
                {
                    moving = false;
                    launchTrain = true;
                }
            }
        }
    }
		
	void FixedUpdate()
    {
        if(launchTrain)
        {
            launchTimer++;
            
        }
        if(launchTimer >= 2)
        {
            BlastOff();
            launchTrain = false;
            launchTimer = 0;
            Managers.trainManager.SetWaitingToStart(false);
        }
	}

    private void BlastOff()
    {
        Debug.Log("Blast Off! Power of: " + power);
        GetComponent<Rigidbody2D>().AddForce(transform.up * power);
    }

    private void LookAtTarget()
    {
        Vector3 targ = targetGameObject.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
