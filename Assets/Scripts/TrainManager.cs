﻿using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public Vector3 cameraPositionOffset;
    public GameObject trainPrefab;
    public GameObject startTarget;
    public GameObject initialTarget;
    public GameObject mainCamera;
    public GameObject activeTrain { get; private set; }
    public GameObject powerControl;
    public List<GameObject> trains { get; private set; }
    private bool waitingToStart;

    private void Awake()
    {
        waitingToStart = true;
        ResetTrainList();
        SetupNewTrain();
    }

    public bool AllTrainsStopped()
    {
        bool allStopped = true;

        foreach (GameObject train in trains)
        {
            float speed = train.GetComponent<Rigidbody2D>().velocity.magnitude;
            if (speed > 0.04)
            {
                allStopped = false;
            }
        }

        return allStopped;
    }

    public void SetWaitingToStart(bool status)
    {
        waitingToStart = status;
    }

    private void Update()
    {
        if (AllTrainsStopped() && !waitingToStart)
        {
            waitingToStart = true;
            SetupNewTrain();
            Managers.scoreManager.UpdateScores();
            ResetDragForTrains();
        }
    }

    private void SetupNewTrain()
    {
        GameObject train = Instantiate(trainPrefab);
        TrainPath trainPath = train.GetComponent<TrainPath>();
        AssignTrainOwnershipToPlayer(train.GetComponent<TrainScoreController>());
        train.transform.position = startTarget.transform.position;
        trainPath.initialTarget = initialTarget;
        activeTrain = train;
        trains.Add(train);
        powerControl.GetComponent<PowerGaugeController>().ActivePowerGauge(trainPath);
        LockCameraToActiveTrain();
    }

    private void ResetTrainList()
    {
        trains = new List<GameObject>();
    }

    private void LockCameraToActiveTrain()
    {
        mainCamera.transform.SetParent(activeTrain.transform);
        mainCamera.transform.localPosition = cameraPositionOffset;
        mainCamera.transform.localRotation = Quaternion.identity;
    }

    private void ResetDragForTrains()
    {
        foreach (GameObject train in trains)
        {
            train.GetComponent<Rigidbody2D>().drag = 1;
        }
    }

    private void AssignTrainOwnershipToPlayer(TrainScoreController trainScoreController)
    {
        if(trains.Count == 0 || !trains[trains.Count - 1].GetComponent<TrainScoreController>().isPlayer1)
        {
            trainScoreController.isPlayer1 = true;
        }
        else
        {
            trainScoreController.isPlayer1 = false;
            trainScoreController.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}
