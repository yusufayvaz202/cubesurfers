# Unity Stacking Game

A 3D mobile-style stacking game developed in Unity where players collect cubes to build a stack while navigating through obstacles and collecting gems.

***Note:** This project is only an internship project prepared in a few days. It is not a completed game. It may contain errors and performance issues.*

## 🎮 Game Overview

This is an endless runner-style stacking game where the player controls a character that automatically moves forward while collecting cubes to build a stack. The objective is to reach the bonus area with as many cubes as possible to maximize the gem multiplier.

## 🎯 Gameplay Features

### Core Mechanics
- **Automatic Forward Movement**: Player moves forward automatically
- **Horizontal Control**: Swipe left/right to control horizontal movement
- **Cube Stacking**: Collect cubes by passing over them with raycasting detection
- **Stack Management**: Cubes are added to and removed from the player's stack dynamically

### Power-ups & Collectibles
- **Gems**: Collectible items that increase score
- **Magnet Mode**: Temporary power-up that increases cube collection range (7x normal range)
- **Bonus Area**: Special zone at the end where remaining cubes multiply gem count

### Obstacles
- **Water Obstacles**: Gradually decrease stack size over time when player is in contact
- **Stack Loss**: Losing all cubes results in game over (unless in bonus area)

## 🏗️ Technical Architecture

### Manager Classes
- **GameManager**: Handles game state transitions, gem counting, and win/lose conditions
- **LevelManager**: Manages scene loading and level progression
- **EventManager**: Static event system for decoupled communication between components

### Player System
- **PlayerInputController**: Handles input using Unity's Input System
- **PlayerMovementController**: Controls forward and horizontal movement
- **PlayerAnimationController**: Manages character animations
- **StackController**: Handles cube stacking mechanics and stack management

### Game Components
- **Cube System**: Individual cube behavior with raycast-based stacking detection
- **Collectibles**: Gem and Magnet power-up implementations
- **UI System**: Game UI including gem counter, magnet mode indicator, and win/lose screens

## 🔧 Key Technical Features

### Event-Driven Architecture
- Utilizes a centralized EventManager for loose coupling between systems
- Events for raycast hits, game state changes, collectibles, and player states

### Raycast-Based Cube Collection
- Cubes use BoxCast for precise collision detection
- Dynamic raycast scaling for normal and magnet modes
- Layer-based filtering for optimal performance

### DOTween Integration
- Smooth animations for UI elements
- Stack movement animations
- Gem collection visual feedback

### Input System Integration
- Modern Unity Input System implementation
- Touch and keyboard input support
- Responsive horizontal movement controls

## 🚀 Getting Started

### Prerequisites
- Unity 2022.3 LTS or later
- DOTween
- Unity Input System package

### Setup
1. Clone or download the project
2. Open in Unity
3. Ensure DOTween is properly imported
4. Configure Input System in Project Settings
5. Build and run on your target platform

## 🎯 Future Enhancements

- Object pooling for cubes and gems (noted in TODO comments)
- Particle effects for collections and interactions
- Additional power-up types
- More obstacle varieties
- Sound and music integration
- Progressive difficulty scaling

## 📝 Development Notes

This project demonstrates modern Unity development practices including:
- Component-based architecture
- Event-driven programming
- State management
- Modern input handling
- UI animation and feedback
- Performance considerations with raycasting and object management

---
