public class GameData
{
    public bool[] levelUnlock = new bool[9];
    public bool[] levelCompleted = new bool[9];
    
    public GameData()
    {
        levelUnlock[0] = true;
        levelUnlock[1] = true;
        levelUnlock[2] = false;
        levelUnlock[3] = false;
        levelUnlock[4] = false;
        levelUnlock[5] = false;
        levelUnlock[6] = false;
        levelUnlock[7] = false;
        levelUnlock[8] = false;

        levelCompleted[0] = false;
        levelCompleted[1] = false;
        levelCompleted[2] = false;
        levelCompleted[3] = false;
        levelCompleted[4] = false;
        levelCompleted[5] = false;
        levelCompleted[6] = false;
        levelCompleted[7] = false;
        levelCompleted[8] = false;
    }
}
