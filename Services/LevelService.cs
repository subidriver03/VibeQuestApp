namespace VibeQuestApp.Services
{
    public class LevelService
    {
        public int GetLevel(int totalXP)
        {
            int level = 1;
            int requiredXP = 0;

            while (totalXP >= requiredXP)
            {
                level++;
                requiredXP = 50 * level * (level - 1);
            }

            return level - 1;
        }

        public int GetXPToNextLevel(int totalXP)
        {
            int level = GetLevel(totalXP);
            int nextLevel = level + 1;
            int xpForNextLevel = 50 * nextLevel * (nextLevel - 1);
            return xpForNextLevel - totalXP;
        }

    }
}
