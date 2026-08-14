# 🎯 Target Shooting Game

A simple target-shooting game developed in **Unity** where the player uses a gun to aim and shoot at moving targets. Each successful hit increases the player's score, while a timer keeps track of the current game session.

This project focuses on practicing **Unity gameplay programming, script organization, UI management, object spawning, and communication between gameplay systems**.

---

## 🎮 Gameplay

<img width="364" height="204" alt="Part 1" src="https://github.com/user-attachments/assets/2cedac8f-63c5-46e4-8ce6-7ca7b4cab193" />

---

<img width="490" height="276" alt="Part 2" src="https://github.com/user-attachments/assets/d201ea3f-2d9e-4c25-9341-962ad9af0bab" />

The objective is simple:

* Aim the gun using the mouse.
* Shoot the targets as they appear.
* Successfully hitting a target increases the score.
* Targets move around the play area, requiring the player to react quickly.
* The game is controlled by a timer.
* The UI displays the current score and remaining time.

### Gameplay Preview

---

## 🛠️ Technologies

* **Unity**
* **C#**
* Unity UI
* Unity Physics / Raycasting
* Prefabs
* Coroutines
* Event-driven communication

---

## 🧩 Project Architecture

The project is divided into several scripts, with each script responsible for a specific part of the game.

```text
GameManager
│
├── TargetSpawner
│      │
│      └── Target
│
├── GunBehaviour
│
├── ScoreController
│
├── TimerController
│
└── UIController
```

The goal of this structure is to keep gameplay systems separated and reduce unnecessary dependencies between scripts.

---

## 🧠 Programming Concepts

This project was also created to practice several important game programming concepts:

### Component-Based Design

Each gameplay system is separated into its own Unity component.

Instead of having one large script controlling everything, responsibilities are distributed between:

* `GameManager`
* `GunBehaviour`
* `Target`
* `TargetSpawner`
* `ScoreController`
* `TimerController`
* `UIController`

### Separation of Responsibilities

Each script has a specific purpose.

```text
Gameplay       → Target / GunBehaviour
Spawning       → TargetSpawner
Score          → ScoreController
Time           → TimerController
Game Flow      → GameManager
Presentation   → UIController
```

This makes the project easier to debug, maintain, and expand.

---

## 📁 Project Structure

A simplified project structure looks like:

```text
Assets/
│
├── Scenes/
│
├── Scripts/
│   ├── GameManager.cs
│   ├── GunBehaviour.cs
│   ├── ScoreController.cs
│   ├── Target.cs
│   ├── TargetSpawner.cs
│   ├── TimerController.cs
│   └── UIController.cs
│
├── Prefabs/
│
├── Materials/
│
├── Models/
│
└── UI/
```
## 👤 Author

**João Gozzi**

Game Programming Student & Game Developer

### Skills Used

`C#` · `Unity` · `Gameplay Programming` · `UI Programming` · `Object Spawning` · `Raycasting` · `Game Systems Architecture`
