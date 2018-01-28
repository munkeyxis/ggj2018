using UnityEngine;

public class TargetOptions : MonoBehaviour {
    public SegmentController nextSegment;
    public bool noTarget;
    public bool isPlayer1;

    public GameObject GetNextSegmentTarget()
    {
        return nextSegment.endTarget;
    }
	
}
