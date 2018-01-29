using UnityEngine;

public class TargetOptions : MonoBehaviour {
    public TargetOptions nextTarget;
    public bool noTarget;

    public GameObject GetNextSegmentTarget()
    {
        return nextTarget.gameObject;
    }
}
