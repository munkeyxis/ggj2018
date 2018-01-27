using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainPath : MonoBehaviour {

	public Transform[] target;
	public float speed;
	public float rotate_speed;
	public float power;

	public Text left_text;
	public Text right_text;

	public static int current;

	public bool direction_right;
	public bool moving;
	public bool power_time;
	public bool force_time;

	// Use this for initialization
	void Start () {
		
		direction_right = false;
		moving = false;
		power_time = false;
		force_time = false;

	}
	
	// Update is called once per frame
	void Update () {

		//speed -= 1 * Time.deltaTime;

		/*Vector2 rotate_direction = target[current].position - transform.position;
		float angle = Mathf.Atan2(rotate_direction.y, rotate_direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotate_speed * Time.deltaTime);*/
		

		if(moving == true){

			if(direction_right == true){

				right_text.enabled = true;
				left_text.enabled = false;

			}else{

				left_text.enabled = true;
				right_text.enabled = false;
			}

			if(current != 30 && current != 33 && current != 36 && current != 39 && current != 42 && current != 45 && current != 48 && current != 51){

				if(transform.position != target[current].position){

					Vector2 pos = Vector2.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
					GetComponent<Rigidbody2D>().MovePosition(pos);

				}else{

					current += 1;
				}

				if(transform.position == target[3].position && direction_right == false){
					current = 4;
				}else if(transform.position == target[3].position && direction_right == true){
					current = 8;
				}
				if(transform.position == target[6].position && direction_right == false){
					current = 12;
				}else if(transform.position == target[6].position && direction_right == true){
					current = 16;
				}
				if(transform.position == target[10].position && direction_right == false){
					current = 20;
				}else if(transform.position == target[10].position && direction_right == true){
					current = 24;
				}
				if(transform.position == target[14].position && direction_right == false){
					current = 28;
				}else if(transform.position == target[14].position && direction_right == true){
					current = 31;
				}
				if(transform.position == target[18].position && direction_right == false){
					current = 34;
				}else if(transform.position == target[18].position && direction_right == true){
					current = 37;
				}
				if(transform.position == target[22].position && direction_right == false){
					current = 40;
				}else if(transform.position == target[22].position && direction_right == true){
					current = 43;
				}
				if(transform.position == target[26].position && direction_right == false){
					current = 46;
				}else if(transform.position == target[26].position && direction_right == true){
					current = 49;
				}

			}else {
				

				if(force_time == false){

					Debug.Log("Add Force time");
					GetComponent<Rigidbody2D>().AddForce(transform.up * power);
					force_time = true;
				}

			}
		}else{
			right_text.enabled = false;
			left_text.enabled = false;
		}
		
	}

	void FixedUpdate(){
		if(direction_right == false && Input.GetKeyDown(KeyCode.RightArrow)){

			direction_right = true;

		}else if(direction_right == true && Input.GetKeyDown(KeyCode.LeftArrow)){

			direction_right = false;
		}

		if(moving == false && Input.GetKeyDown(KeyCode.Space)){
			moving = true;
		}
	}


}
