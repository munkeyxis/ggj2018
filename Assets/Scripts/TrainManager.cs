﻿using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {

    public Vector3 cameraPositionOffset;
    public GameObject trainPrefab;
    public GameObject startTarget;
    public GameObject initialTarget;
    public GameObject mainCamera;
    public GameObject activeTrain { get; private set; }
    public GameObject powerControl;
    public List<GameObject> trains { get; private set; }

    private void Awake()
    {
        ResetTrainList();
        SetupNewTrain();
        LockCameraToActiveTrain();
    }

    private void SetupNewTrain()
    {

        GameObject train = Instantiate(trainPrefab);
        TrainPath trainPath = train.GetComponent<TrainPath>();
        train.transform.position = startTarget.transform.position;
        trainPath.initialTarget = initialTarget;
        activeTrain = train;
        trains.Add(train);
        powerControl.GetComponent<PowerGaugeController>().ActivePowerGauge(trainPath);
    }

    private void ResetTrainList()
    {
        trains = new List<GameObject>();
    }

    private void LockCameraToActiveTrain()
    {
        mainCamera.transform.SetParent(activeTrain.transform);
        mainCamera.transform.localPosition = cameraPositionOffset;
    }
}
