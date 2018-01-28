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

	void Awake () {
        targetGameObject = initialTarget;
		moving = false;
		power_time = false;
		train_sound_bool = false;
	}

    void Update()
    {

        //speed -= 1 * Time.deltaTime;

        /*Vector2 rotate_direction = target[current].position - transform.position;
		float angle = Mathf.Atan2(rotate_direction.y, rotate_direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotate_speed * Time.deltaTime);*/


        if (moving == true)
        {
        	if(train_sound_bool == false && speed > 0){

        		GetComponent<AudioSource>().clip = steam_train;
				GetComponent<AudioSource>().Play();
				train_sound_bool = true;
        	}
        	

            if(transform.position == targetGameObject.transform.position)
            {
                targetGameObject = targetGameObject.GetComponent<TargetOptions>().GetNextSegmentTarget();
            }

            Vector2 pos = Vector2.MoveTowards(transform.position, targetGameObject.transform.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
            LookAtTarget();
        }
    }
		
	void FixedUpdate(){
		if(moving == false && Input.GetKeyDown(KeyCode.Space)){
			moving = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.GetComponent<IntersectionController>()){
			targetGameObject = other.GetComponent<IntersectionController>().GetNextTarget();
        }
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
