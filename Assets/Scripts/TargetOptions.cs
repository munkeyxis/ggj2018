using UnityEngine;

public class TargetOptions : MonoBehaviour {
    public GameObject thisTarget;
    public TargetOptions nextTarget;
    public bool noTarget;

    public GameObject GetNextSegmentTarget()
    {
        return nextTarget.gameObject;
    }
	
}
