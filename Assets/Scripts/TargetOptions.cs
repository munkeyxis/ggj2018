using UnityEngine;

public class TargetOptions : MonoBehaviour {
    public SegmentController nextSegment;

    public Vector3 GetNextSegmentTargetPos()
    {
        return nextSegment.endTarget.position;
    }
	
}
