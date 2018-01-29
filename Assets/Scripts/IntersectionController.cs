using UnityEngine;

public class IntersectionController : MonoBehaviour
{
    public TargetOptions left_target;
    public TargetOptions right_target;
    public SignalLightsController signalLightsController;
    private bool going_right;
    private TargetOptions intersectionTarget;

    void Start()
    {
        int going_right_num;
        intersectionTarget = GetComponentInChildren<TargetOptions>();
        going_right_num = Random.Range(0, 2);
        going_right = going_right_num == 0 ? false : true;
        signalLightsController.SetLightOn(going_right);
        SetSelectedTarget();
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
        intersectionTarget.nextTarget = left_target;

        if (going_right)
        {
            intersectionTarget.nextTarget = right_target;
        }
    }
}
