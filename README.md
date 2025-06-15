# 🌟 Vibe Quest – Level Up Your Life
**A Gamified Personal Growth Tracker**  
**Author:** Vibe Rantz  
**Version:** 1.5 (Living Document)  
**Last Updated:** June 14, 2025  

---

## 🎯 Project Overview

Vibe Quest is a gamified self-development platform that transforms real-life tasks into RPG-style quests. Users build a custom hero, complete daily goals, earn XP, level up, and grow in skill categories like Mind, Body, Creativity, and Focus.

---

## 📚 Table of Contents

1. [Purpose & Vision](#1-purpose--vision)  
2. [Challenging Concepts](#2-challenging-concepts)  
3. [Tech Stack](#3-tech-stack)  
4. [Feature Roadmap](#4-feature-roadmap)  
5. [User Types](#5-user-types)  
6. [System Architecture](#6-system-architecture)  
7. [Milestones & Changelog](#7-milestones--changelog)  
8. [Onboarding Flow](#8-onboarding-flow)  
9. [XP & Leveling Logic](#9-xp--leveling-logic)  
10. [Setup Instructions](#10-setup-instructions)

---

## 1. 🎯 Purpose & Vision

### 1.1 Purpose  
Help people stay consistent with personal growth through fun, motivating systems rooted in video game mechanics.

### 1.2 Vision  
Turn your goals into a game you actually want to play.

---

## 2. 🧠 Challenging Concepts

### 2.1 Gamifying Growth  
Real actions → XP → Visual Progress → Motivation  
> **Challenge:** Avoiding the “checklist trap” — XP needs to feel *earned* and *meaningful*.

### 2.2 Emotional Progress  
Journal entries and consistency streaks should be rewarded without trivializing emotional effort.

### 2.3 XP & Skill Trees  
> XP drives both level progression and development in Mind, Body, Creativity, and Focus.

### 2.4 RPG Identity  
Users create a “Hero” persona that reflects their growth journey.

---

## 3. 🧰 Tech Stack

| Layer         | Tool                  |
|---------------|------------------------|
| Frontend      | Blazor Server (.NET 9) |
| Backend       | ASP.NET Core           |
| Database      | SQLite + EF Core       |
| Identity/Auth | ASP.NET Identity       |
| Styling       | Bootstrap 5            |
| State Mgmt    | Scoped Services        |
| Hosting (dev) | Localhost, GitHub Pages |

---

## 4. 🚀 Feature Roadmap

| Feature                    | Status     |
|---------------------------|------------|
| User Registration/Login   | ✅ Complete |
| Hero Creation             | ✅ Complete |
| XP & Leveling System      | ✅ Complete |
| Quests System             | ✅ Complete |
| Journal Entries           | ✅ Complete |
| Reward Store              | ✅ Complete |
| Dynamic NavMenu           | ✅ Complete |
| Developer Dashboard       | ✅ Complete |
| Skill Tree Visualization  | 🛠️ Planned |
| Boss Battles              | 🛠️ Planned |
| Achievements System       | 🛠️ Planned |

---

## 5. 👤 User Types

| Role         | Access Permissions                          |
|--------------|---------------------------------------------|
| Guest        | Get Started, Register, Log In               |
| User         | Quests, Journal, Rewards, XP Dashboard      |
| Developer    | Developer Dashboard, Modify Any User        |

---

## 6. 🧩 System Architecture

VibeQuestApp/
│
├── Pages/ # Razor UI Components
│ ├── Onboarding/ # Step1, Step2, Step3
│ ├── Profile.razor # Hero Profile Page
│ ├── Journal.razor # Mood + Entry Tracking
│ ├── Quests.razor # Task Management
│ ├── Rewards.razor # HeroCoin Store
│ └── DeveloperDashboard.razor
│
├── Models/ # User, HeroProfile, Quest, Reward
├── Services/ # Session, XP, Reward, DevTool, State
├── Data/ # AppDbContext, Migrations
├── Shared/ # NavMenu, Layout
└── Program.cs # Entry Point & Dependency Setup

yaml
Copy
Edit

---

## 7. 🛠️ Milestones & Changelog

### ✅ Version 1.1 – Authentication System (Apr 25)
- Email + Password login
- Hero Name setup
- Validation + error states

### ✅ Version 1.2 – XP + Task Engine (May 4)
- Quest creation + XP reward logic
- Skill Category mapping (Mind, Body, etc.)

### ✅ Version 1.3 – TaskBoard & XP Bar (May 11)
- Dynamic UI for XP
- Task CRUD implemented

### ✅ Version 1.4 – Core Modules (May 18)
- Profile, Journal, Reward Store
- XP scaling system introduced

### ✅ Version 1.5 – Onboarding Flow + Dev Dashboard (June 13–14)
- Multi-step onboarding: Hero → Vision → Register  
- XP + Level service centralized  
- Full developer dashboard to manage user XP, coins, avatars, and reset

---

## 8. 🧙 Onboarding Flow

| Step | Page                   | Input                        |
|------|------------------------|------------------------------|
| 1    | `Step1HeroCreation`    | HeroName, Avatar             |
| 2    | `Step2VisionSetup`     | Focus Areas, Motivation      |
| 3    | `Step3AccountSetup`    | Email, Password              |
| 4    | `/success`             | Confirmation + Auto-Login    |

---

## 9. 📈 XP & Leveling Logic

**Level Formula:**  
```csharp
XPRequired = 50 * Level * (Level - 1)
Services Involved:

LevelService.cs — Determines level from total XP

HeroProfile.cs — Stores XP, level, and calculates percentage

RewardStoreService.cs — Unlocks rewards based on XP or HeroCoins

Leveling Behavior:

Bar resets to 0 on level-up

XP rolls over excess into next level

Rewards trigger on threshold (e.g. +1 HeroCoin)

10. 💻 Setup Instructions
bash
Copy
Edit
git clone https://github.com/yourname/VibeQuestApp.git
cd VibeQuestApp
dotnet ef database update
dotnet run
Make sure to have .NET 9 SDK installed

✅ Developer Dashboard Summary
Select and manage any user

View/edit: XP, Level, HeroCoins, Avatar

Real-time XP bar with level-up logic

Reset or delete user data

Upload avatars from dashboard

🧪 Testing Notes
TDD is enforced via VibeQuestApp.Tests

Unit tests exist for:

XP tracking logic

Reward unlocking

Journal streaks

Task completion updates

🔒 Auth Behavior Recap
Page	Requires Login?	Notes
/login	❌	Public
/quests	✅	Authenticated users only
/developer/dashboard	✅ (Developer)	Devs only via IsDeveloper
/hero-customize	❌	Public onboarding

💬 Vibe’s Notes
This app isn’t just a tracker — it’s a reflection engine. A mirror for your goals.
If you play the game daily, you will change. One habit, one entry, one quest at a time.

📌 License
MIT License — 2025 © Vibe Rantz

vbnet
Copy
Edit

Let me know if you'd like a visual layout added, printable PDF version, or a landing site version of this README!
