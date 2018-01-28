using UnityEngine;

public class IntersectionController : MonoBehaviour {

	public GameObject left_target;
	public GameObject right_target;
    public GameObject intersectionTarget;
    public SignalLightsController signalLightsController;

	private bool going_right;
    private GameObject selectedTarget;

	// Use this for initialization
	void Start () {

		int going_right_num;
		going_right_num = Random.Range(0,2);
		going_right = going_right_num == 0 ? false : true;
        signalLightsController.SetLightOn(going_right);
        SetSelectedTarget();
        intersectionTarget.GetComponent<TargetOptions>().nextTarget = selectedTarget.GetComponent<TargetOptions>();
	}
	
	public GameObject GetNextTarget(){
		return going_right ? right_target : left_target;
	}

    public void ToggleTarget()
    {
        going_right = !going_right;
        signalLightsController.SetLightOn(going_right);
        Debug.Log("Going right? " + going_right);
        SetSelectedTarget();
    }

    private void SetSelectedTarget()
    {
        selectedTarget = left_target;

        if(going_right)
        {
            selectedTarget = right_target;
        }
    }

}
