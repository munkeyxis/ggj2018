using UnityEngine;

public class Managers : MonoBehaviour {

    public static TrainManager trainManager { get; private set; }

    private void Awake()
    {
        trainManager = GetComponent<TrainManager>();
    }
}
