using System;
using Settings;
using Task.TaskCreator.TaskCreatorComponent;
using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    private TaskCreatorComponent _taskCreatorComponent;

    private void Awake()
    {
        _taskCreatorComponent = new TaskCreatorComponent(LevelInfoStatic.CurrentLevel, GameInfoConstants.LevelCount);
        _taskCreatorComponent.GenerateTasks();
    }

    private void Update()
    {
        _taskCreatorComponent.Update();
    }
}