using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text player1ScoreText;
    private int player1Score;
    public Text player2ScoreText;
    private int player2Score;
    public ScoreZoneController scoreZoneController;

	void Start () {
        player1Score = 0;
        player2Score = 0;
	}
	
	public void UpdateScores()
    {
        player1Score = 0;
        player2Score = 0;

        foreach (GameObject train in Managers.trainManager.trains)
        {
            TrainScoreController trainScoreController = train.GetComponent<TrainScoreController>();
            ZoneSize bestZone = trainScoreController.GetBestZone();
            AddScoreBasedOnZone(bestZone);
        }

        player1ScoreText.text = "Player 1: " + player1Score.ToString();
        player2ScoreText.text = "Player 2: " + player2Score.ToString();
    }

    private void AddScoreBasedOnZone(ZoneSize zone)
    {
        int zoneValue = 0;
        switch (zone)
        {
            case ZoneSize.large:
                zoneValue = 1;
                break;
            case ZoneSize.medium:
                zoneValue = 2;
                break;
            case ZoneSize.small:
                zoneValue = 3;
                break;
            default:
                zoneValue = 0;
                break;
        }

        player1Score += zoneValue;
    }
}
