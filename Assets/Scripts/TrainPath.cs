using UnityEngine;
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

    private GameObject targetGameObject;

	void Awake () {
        targetGameObject = initialTarget;
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
            if(transform.position == targetGameObject.transform.position)
            {
                targetGameObject = targetGameObject.GetComponent<TargetOptions>().GetNextSegmentTarget();
            }

            Vector2 pos = Vector2.MoveTowards(transform.position, targetGameObject.transform.position, speed * Time.deltaTime);
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
			targetGameObject = other.GetComponent<IntersectionController>().GetNextTarget();
        }
	}
}
