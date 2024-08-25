using System;
using System.Collections.Generic;
using System.Linq;
using InteractiveObject.WorldObject.Component;
using Settings;
using Task.Struct;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Task.TaskCreator.TaskCreatorComponent
{
    public class TaskCreatorComponent
    {
        private readonly float _averageSolveTime;
        private readonly int _averagePenalty;
        private readonly int _averageReward;

        private List<float> _taskTimestamps = new();
        private int _timestampIndex = 0;

        private InteractiveObjectComponent[] _interactiveObjects;
        private List<InteractiveObjectComponent> _selectedObjects = new();

        private List<TaskData> _tasks = new();

        public TaskCreatorComponent(int levelNumber, int levelCount)
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObjectComponent>();
            
            _averageSolveTime = GameInfoConstants.DefaultTaskSolveTime * (2f - (float)levelNumber / levelCount) * Random.Range(0.8f, 1.5f);
            _averagePenalty = Mathf.RoundToInt(GameInfoConstants.DefaultPenalty * levelNumber * Random.Range(0.8f, 1.5f));
            _averageReward = Mathf.RoundToInt(GameInfoConstants.DefaultReward * levelNumber * Random.Range(0.8f, 1.5f));
        }

        public void GenerateTasks()
        {
            var tasksCount = Mathf.RoundToInt(GameInfoConstants.LevelTime / _averageSolveTime);
            if (tasksCount > _interactiveObjects.Length)
            {
                throw new ApplicationException("TOO MANY TASKS");
            }
            
            var availableObjects = _interactiveObjects.ToList();

            for (var i = 0; i < tasksCount; i++)
            {
                var data = new TaskData($"Task {i}", _averageSolveTime * Random.Range(0.9f, 1.1f),
                    (int)(_averageReward * Random.Range(0.9f, 1.1f)), (int)(_averagePenalty * Random.Range(0.9f, 1.1f)));

                var timestamp = 0f;
                if (i != 0)
                {
                    timestamp = _taskTimestamps[i - 1] + _tasks.Last().FullTime - 1f;
                }

                var randomIndex = Random.Range(0, availableObjects.Count);
                var selectedObject = availableObjects[randomIndex];
                availableObjects.RemoveAt(randomIndex);
                
                _tasks.Add(data);
                _taskTimestamps.Add(timestamp);
                _selectedObjects.Add(selectedObject);
            } 
        }

        public void Update()
        {
            if (_timestampIndex >= _tasks.Count) return;
            
            if (_taskTimestamps[_timestampIndex] >= Time.time)
            {
                _timestampIndex++;
                _selectedObjects[_timestampIndex].SetupForNewTask(_tasks[_timestampIndex]);
            }
        }
    }
}