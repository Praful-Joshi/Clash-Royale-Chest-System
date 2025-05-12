# Clash Royale Chest System

A modular chest reward system similar to those found in games like Clash Royale. The system allows players to collect chests, choose to unlock them immediately using gems or wait for a timer to complete, and collect randomized rewards.

<p align="center">
  <img src="preview.gif" alt="Gameplay GIF" height="400"/>
</p>

## 🏗️ System Architecture

The project follows MVC (Model-View-Controller) architecture principles for better organization and maintainability:

- **Model**: Handles data and business logic (ChestModel, ChestSO)
- **View**: Manages UI presentation (Timer, RewardManager, ChestActionsManager)
- **Controller**: Connects model and view components (ChestController, ChestService)

## 🧩 Core Components

### Chest Management
- **ChestSO**: ScriptableObject that defines chest properties (name, unlock time, rewards, cost)
- **ChestModel**: Data container that wraps ChestSO data for runtime use
- **ChestController**: Handles chest interactions and user input
- **ChestService**: Factory service that spawns and manages chest instances

### UI Components
- **ChestActionsManager**: Manages UI actions when a chest is selected
- **TimerManager**: Handles chest unlock timing and queue system
- **Timer**: Controls individual countdown timers for chest unlocking
- **RewardManager**: Handles displaying and collecting chest rewards
- **InventoryManager**: Tracks player's currency (coins and gems)

## ✨ Features

- Weighted random chest generation with 4 chest rarities
- Chest slot management system (4 slots available)
- Two unlock options:
  - Wait for timer completion
  - Use gems for instant unlock
- Queue system for multiple chest timers
- Randomized rewards within chest-specific ranges
- Currency system (coins and gems)

## 🔔 Event System

The system uses C# events for communication between components:
- `ChestController.clickedOnChest`: Triggered when player selects a chest
- `ChestActionsManager.clickedOnStartTimer`: Triggered when timer unlock is selected
- `ChestActionsManager.clickedOnUseGems`: Triggered when instant unlock is selected
- `TimerManager.timerCompleted`: Triggered when a chest timer completes
- `RewardManager.clickedOnCollectReward`: Triggered when rewards are collected

## 🔄 Workflow

1. ChestService spawns chests in the available slots
2. Player clicks on a chest, triggering ChestActionsManager
3. Player chooses unlock method (timer or gems)
4. If timer selected, TimerManager handles countdown
5. When unlocked, RewardManager displays and handles reward collection
6. InventoryManager updates player currency

## 🚀 Future Improvements

- Save/load system for persistent chests and inventory
- Additional chest types with special rewards
- Visual effects for chest unlocking process
- Advanced chest queueing system
- UI polish and animations

## 🛠️ Requirements

- Unity 2020.3 or later
- TextMeshPro package
