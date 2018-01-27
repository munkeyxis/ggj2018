using UnityEngine;

public class IntersectionController : MonoBehaviour {

	public Transform left_target;
	public Transform right_target;

    private Vector3 leftTargetPos;
    private Vector3 rightTargetPos;

	private bool going_right;

	// Use this for initialization
	void Start () {

		int going_right_num;
		going_right_num = Random.Range(0,1);
		going_right = going_right_num == 0 ? false : true;
        leftTargetPos = left_target.position;
        rightTargetPos = right_target.position;
	}
	
	public Vector3 GetNextTarget(){

		Vector3 nextTarget = going_right ? rightTargetPos : leftTargetPos;
		return nextTarget;
	}

    public void ToggleTarget()
    {
        going_right = !going_right;
        Debug.Log("Going right? " + going_right);
    }

}
