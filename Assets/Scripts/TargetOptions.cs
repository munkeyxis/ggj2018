using UnityEngine;

public class TargetOptions : MonoBehaviour {
    public SegmentController nextSegment;

    public GameObject GetNextSegmentTarget()
    {
        return nextSegment.endTarget;
    }
	
}
