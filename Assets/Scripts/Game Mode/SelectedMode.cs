public class SelectedMode
{
    private static GameMode _gameMode;
    public static SoloMode SoloMode { get; private set; } = new SoloMode();
    public static VersusMode VersusMode { get; private set; } = new VersusMode();
    public static IAMode IaMode { get; private set; } = new IAMode();

    public static GameMode GetGameMode()
    {
        return _gameMode;
    }

    public static void SetGameMode(GameMode gameMode)
    {
        _gameMode = gameMode;
    }
}