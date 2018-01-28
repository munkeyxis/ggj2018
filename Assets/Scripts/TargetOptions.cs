using UnityEngine;

public class TargetOptions : MonoBehaviour {
    public SegmentController nextSegment;
    public bool noTarget;

    public GameObject GetNextSegmentTarget()
    {
        return nextSegment.endTarget;
    }
	
}
