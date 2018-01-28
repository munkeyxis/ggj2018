using UnityEngine;

public class TrainScoreController : MonoBehaviour {
    private bool inLargeZone;
    private bool inMediumZone;
    private bool inSmallZone;

	void Start () {
        inLargeZone = false;
        inMediumZone = false;
        inSmallZone = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check which zone i've entered
            // based on zone, set bool to true
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // check which zone i've entered
            // based on zone, set bool to false
    }
}
