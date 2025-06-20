﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VibeQuestApp.Data;
using VibeQuestApp.Models;

namespace VibeQuestApp.Services;

public class QuestService(AppDbContext db)
{
    public async Task<bool> CompleteQuestAsync(int questId, string userId)
    {
        if (string.IsNullOrEmpty(userId)) return false;

        var quest = await db.Quests.FirstOrDefaultAsync(q => q.Id == questId && q.UserId == userId);
        var profile = await db.HeroProfiles.FirstOrDefaultAsync(p => p.UserId == userId);

        if (quest == null || profile == null || quest.IsCompleted)
            return false;

        quest.IsCompleted = true;

        profile.TotalXP += quest.XpReward;
        profile.CurrentXP += quest.XpReward;
        profile.Level = CalculateLevel(profile.TotalXP);

        await db.SaveChangesAsync();
        return true;
    }

    public async Task AddQuestAsync(Quest quest)
    {
        db.Quests.Add(quest);
        await db.SaveChangesAsync();
    }

    public async Task<List<Quest>> GetUserQuestsAsync(string userId)
    {
        return await db.Quests
            .Where(q => q.UserId == userId)
            .ToListAsync();
    }

    private static int CalculateLevel(int totalXP)
    {
        return (int)Math.Floor(Math.Sqrt(totalXP / 100.0)) + 1;
    }
}
