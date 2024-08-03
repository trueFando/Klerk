namespace Task.Struct
{
    public struct TaskData
    {
        public readonly string Name;
        public readonly float FullTime;
        public readonly int Reward;
        public readonly int Penalty;
        
        public TaskData(string name, float fullTime, int reward, int penalty)
        {
            Name = name;
            FullTime = fullTime;
            Reward = reward;
            Penalty = penalty;
        }
    }
}