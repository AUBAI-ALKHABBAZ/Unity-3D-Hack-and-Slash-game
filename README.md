# ⚔️ Unity 3D Hack-and-Slash Game Framework

[![Unity](https://img.shields.io/badge/Unity-2022.3%2B-black.svg?logo=unity)](https://unity.com/)
[![C#](https://img.shields.io/badge/C%23-Language-blue.svg?logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A modular and clean gameplay programming architecture developed in **Unity (C#)** for a 3D Hack-and-Slash action game. This repository implements core systems essential for action RPG mechanics, including character locomotion, animation-driven combat events, stats management, enemy AI behavior, level control, and UI billboard orientation.

## 📂 Script Architecture & Component Breakdown

The project follows a component-based design pattern, separating movement, combat logic, stats, and UI rendering into dedicated modular scripts located in the `scripts/` directory:

| Script Name | Core Responsibility |
| :--- | :--- |
| **`CharacterMovement.cs`** | Handles 3D player locomotion, input processing, smooth movement vectors, and rotation handling. |
| **`AnimationEvents.cs`** | Bridges animator states with game logic (e.g., enabling attack hitboxes, triggering combo windows). |
| **`CharacterStats.cs`** | Manages core RPG attributes such as health points, damage thresholds, and state changes (damage/death). |
| **`EnemyController.cs`** | Controls enemy state machines, target tracking, detection ranges, and combat engagement logic. |
| **`LevelManager.cs`** | Oversees game flow, scene transitions, level state checkpoints, and win/lose conditions. |
| **`UI_LookAt.cs`** | Implements camera-facing (billboarding) behavior for floating health bars and UI elements over entities. |

## 🛠️ Technology Stack

* **Game Engine:** Unity (Recommended: 2022.3 LTS or newer)
* **Programming Language:** C# (.NET Standard)
* **Architecture Pattern:** Component-Based Architecture / Modular Scripting

## 🚀 Getting Started & Integration

To integrate these scripts into your own Unity project:

1. **Clone the Repository:**
   `bash
   git clone [https://github.com/AUBAI-ALKHABBAZ/Unity-3D-Hack-and-Slash-game.git](https://github.com/AUBAI-ALKHABBAZ/Unity-3D-Hack-and-Slash-game.git)



2. **Open in Unity:**
* Open **Unity Hub**, select **Add project from disk**, and point to the cloned folder.


3. **Setup Scene Components:**
* Attach `CharacterMovement` and `CharacterStats` to your Player GameObject (ensure a appropriate character controller setup is present).
* Attach `EnemyController` and `CharacterStats` to your enemy prefabs.
* Use `AnimationEvents` directly inside the Unity Animation Window timeline to synchronize melee strikes.
* Attach `UI_LookAt` to world-space canvas elements (like health bars) to keep them oriented toward the main camera.
* Place `LevelManager` in your core gameplay scenes to manage state progression.



## 🔮 Future Enhancements

* **Combo System Expansion:** Deepening `AnimationEvents` to support multi-stage combo branching.
* **Behavior Tree AI:** Upgrading `EnemyController` with advanced pathfinding (NavMesh) and tactical evasion maneuvers.
* **Inventory & Loot System:** Integrating modular item databases for weapon scaling and stats modifications.

## 👤 Author

**AUBAI ALKHABBAZ**

*Mechatronics & Information Technology Engineer specializing in Machine Learning, Cyber-Physical Systems, and Game Development.*

_________________________________________________________________________
<img width="1135" height="635" alt="image" src="https://github.com/user-attachments/assets/83004586-c753-41b5-b6e9-a765ca58ea12" />
