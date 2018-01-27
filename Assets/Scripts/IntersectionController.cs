using UnityEngine;

public class IntersectionController : MonoBehaviour {

	public int left_target_num;
	public int right_target_num;

	private bool going_right;

	// Use this for initialization
	void Start () {

		int going_right_num;
		going_right_num = Random.Range(0,1);
		going_right = going_right_num == 0 ? false : true;
	}
	
	public int GetNextTarget(){

		int nextTarget = going_right ? right_target_num : left_target_num;
		return nextTarget;
	}

    public void ToggleTarget()
    {
        going_right = !going_right;
    }

}
