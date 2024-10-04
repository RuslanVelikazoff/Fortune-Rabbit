public class GameData
{
    public int carrot;
    public int clover;
    
    public bool[] levelUnlock = new bool[9];
    public bool[] levelCompleted = new bool[9];

    public bool purchasedMegaJump;
    public bool purchasedProtective;

    public bool[] purchasedRabbit = new bool[4];
    public bool[] selectedRabbit = new bool[4];
    
    public GameData()
    {
        carrot = 0;
        clover = 1000;
        
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

        purchasedMegaJump = false;
        purchasedProtective = false;

        purchasedRabbit[0] = true;
        purchasedRabbit[1] = false;
        purchasedRabbit[2] = false;
        purchasedRabbit[3] = false;

        selectedRabbit[0] = true;
        selectedRabbit[1] = false;
        selectedRabbit[2] = false;
        selectedRabbit[3] = false;

    }
}
