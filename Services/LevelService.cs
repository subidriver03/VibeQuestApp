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
    }
}
