using UnityEngine;

public class Managers : MonoBehaviour {

    public static TrainManager trainManager { get; private set; }
    public static ScoreManager scoreManager { get; private set; }
    public static UiManager uiManager { get; private set; }

    private void Awake()
    {
        trainManager = GetComponent<TrainManager>();
        scoreManager = GetComponent<ScoreManager>();
        uiManager = GetComponent<UiManager>();
    }
}
