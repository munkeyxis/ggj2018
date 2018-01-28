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
        if (collision.GetComponent<ScoreZoneController>())
        {
            switch (collision.GetComponent<ScoreZoneController>().zoneSize)
            {
                case ZoneSize.large:
                    inLargeZone = true;
                    break;
                case ZoneSize.medium:
                    inMediumZone = true;
                    break;
                case ZoneSize.small:
                    inSmallZone = true;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ScoreZoneController>())
        {
            switch (collision.GetComponent<ScoreZoneController>().zoneSize)
            {
                case ZoneSize.large:
                    inLargeZone = false;
                    break;
                case ZoneSize.medium:
                    inMediumZone = false;
                    break;
                case ZoneSize.small:
                    inSmallZone = false;
                    break;
            }
        }
    }
}
