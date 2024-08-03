namespace Task.Struct
{
    public struct TaskData
    {
        public readonly float FullTime;
        public readonly int Reward;
        public readonly int Penalty;
        
        public TaskData(float fullTime, int reward, int penalty)
        {
            FullTime = fullTime;
            Reward = reward;
            Penalty = penalty;
        }
    }
}