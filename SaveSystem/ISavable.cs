namespace Project.Game.SaveSystem
{
    /// <summary>
    /// Interface which will be applied to any class that will have its data saved.
    /// </summary>
    public interface ISavable
    {
        void SaveData(GameData gameData);
    }

    /// <summary>
    /// Interface which will be applied to any class that will have its data saved.
    /// </summary>
    public interface ISavable<T> : ISavable
    {
        void LoadData(T gameData);
    }
}