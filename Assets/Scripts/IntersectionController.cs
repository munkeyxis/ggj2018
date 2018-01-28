using UnityEngine;

public class IntersectionController : MonoBehaviour {

	public GameObject left_target;
	public GameObject right_target;
    public SignalLightsController signalLightsController;

	private bool going_right;

	// Use this for initialization
	void Start () {

		int going_right_num;
		going_right_num = Random.Range(0,1);
		going_right = going_right_num == 0 ? false : true;
        signalLightsController.SetLightOn(going_right);
	}
	
	public GameObject GetNextTarget(){
		return going_right ? right_target : left_target;
	}

    public void ToggleTarget()
    {
        going_right = !going_right;
        signalLightsController.SetLightOn(going_right);
        Debug.Log("Going right? " + going_right);
    }

}
