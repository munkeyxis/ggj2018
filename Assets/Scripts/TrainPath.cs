using UnityEngine;
using UnityEngine.UI;

public class TrainPath : MonoBehaviour {

    public Transform initialTarget;
	public float speed;
	public float rotate_speed;
	public float power;

	public Text left_text;
	public Text right_text;

	public bool moving;
	public bool power_time;

    private Vector3 targetPosition;

	void Awake () {
        targetPosition = initialTarget.position;
		moving = false;
		power_time = false;
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
            Vector2 pos = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
    }
		
	

	void FixedUpdate(){
		if(moving == false && Input.GetKeyDown(KeyCode.Space)){
			moving = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.GetComponent<IntersectionController>()){
			targetPosition = other.GetComponent<IntersectionController>().GetNextTarget();
		}
	}


}
