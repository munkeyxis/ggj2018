using UnityEngine;

public class TrainScoreController : MonoBehaviour {
    public bool inLargeZone { get; private set; }
    public bool inMediumZone { get; private set; }
    public bool inSmallZone { get; private set; }

    void Start () {
        inLargeZone = false;
        inMediumZone = false;
        inSmallZone = false;
	}

    public ZoneSize GetBestZone()
    {
        if(inSmallZone)
        {
            return ZoneSize.small;
        }
        else if (inMediumZone)
        {
            return ZoneSize.medium;
        }
        else if(inLargeZone)
        {
            return ZoneSize.large;
        }
        else
        {
            return ZoneSize.none;
        }
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
