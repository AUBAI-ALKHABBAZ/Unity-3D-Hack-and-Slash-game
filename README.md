# ⚔️ 3D Hack-and-Slash Game (Unity)

A robust gameplay programming framework developed in **Unity (C#)** for a 3D Hack-and-Slash action game. This repository showcases core mechanics essential for fast-paced action RPGs, including advanced character control, smooth camera follow logic, combat state management, and grid-based tactical algorithms inspired by classic real-time strategy frameworks.

## 🎮 Core Features & Script Architecture

The scripts within this repository form the backbone of the game's loop, emphasizing clean object-oriented design and modularity:

1. **Advanced Character Control Framework:** Implements responsive player locomotion, dash mechanics, and orientation handling tailored for 3D action combat.
2. **Dynamic Camera Follow System:** Smooth tracking algorithms designed to keep fast-paced combat fluid and focused on the player character without lagging behind rapid movements.
3. **Combat State Machine:** Manages attack animations, hitboxes, combo chains, and state transitions to ensure responsive and fluid melee combat mechanics.
4. **RTS Grid & Strategic Algorithms:** Features grid-based utility and path/positional logic (drawing inspiration from classic RTS movement and "Fog of War" grid concepts) adapted for spatial awareness and enemy navigation.

## 🛠️ Technology Stack & Requirements

* **Game Engine:** Unity (Recommended version: 2022.3 LTS or newer)
* **Programming Language:** C# (.NET Standard / Modern C# features)
* **Input System:** Unity Input System / Legacy Input (depending on scene configuration)

## 📂 Repository Structure

```text
Unity-3D-Hack-and-Slash-game/
├── scripts/
│   ├── PlayerController.cs     # Locomotion, inputs, and movement physics
│   ├── CombatManager.cs        # Attack states, combos, and hit detection
│   ├── CameraFollow.cs         # Smooth 3D follow camera mechanics
│   └── RTSGridSystem.cs        # Grid-based mapping and spatial algorithms
└── README.md                   # Project documentation

```

*(Note: Script filenames represent the core architecture modules contained within the repository.)*

## 🚀 Getting Started & Installation

To integrate or review these scripts in your own Unity project:

1. **Clone the Repository:**
```bash
git clone https://github.com/AUBAI-ALKHABBAZ/Unity-3D-Hack-and-Slash-game.git

```


2. **Open in Unity:**
* Open **Unity Hub**.
* Click **Add project from disk** and select the cloned repository folder.


3. **Explore Scripts:**
* Navigate to the `scripts/` directory to inspect the modular C# components. Attach them to respective GameObjects (Player, Main Camera, Managers) inside a Unity scene configured with appropriate components (CharacterControllers, Colliders).



## 🔮 Future Enhancements

* **AI Behavior Trees:** Integrating state-driven enemy AI for aggressive melee combat encounters, patrolling, and flanking maneuvers.
* **Hit-Stop & Screen Shake Polish:** Adding juice effects like micro-pauses on heavy impacts to dramatically enhance the Hack-and-Slash feel.
* **Inventory & Equipment Systems:** Scripting modular inventory architecture for weapon swapping and stat modifications.

## 👤 Author

**AUBAI ALKHABBAZ**

*Mechatronics & Information Technology Engineer specializing in Machine Learning, Cyber-Physical Systems, and Game Mechanics.*

_________________________________________________________________________
<img width="1135" height="635" alt="image" src="https://github.com/user-attachments/assets/83004586-c753-41b5-b6e9-a765ca58ea12" />
