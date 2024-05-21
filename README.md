# Chest System Project

[![Chest System Project Overview](https://img.youtube.com/vi/-oyRYkG7hcg/0.jpg)](https://www.youtube.com/watch?v=-oyRYkG7hcg)

The Chest System Project is a comprehensive system featuring advanced software design patterns, architecture, and concepts to handle a dynamic chest system in games. This project incorporates the following:

## Key Features

### MVC Architecture for Chest

The Chest System follows the Model-View-Controller (MVC) architecture, providing a clear separation of concerns and improving maintainability. 

### State Machine for Chest States

A State Machine is implemented to manage various states of chests, including states like "Closed," "Unlocking," "Unlocked," and "Queued." This allows for organized and intuitive chest behavior.

### Observer Pattern with Events

The Observer Pattern is employed through an Event System. Chests and other components can subscribe to events, enabling a decoupled and flexible system for reacting to changes in the game.

### Object-Oriented Programming (OOP) Concepts

The project adheres to OOP principles, promoting modularity, extensibility, and code readability.

### Queue Data Structure

The project uses a Queue data structure to manage the order in which chests are Unlocked, providing a fair and organized system for players.

## Code Overview

The updated codebase consists of several classes responsible for different aspects of the chest system. Here's a brief overview:

- `ChestData`: Holds data about chest types, images, unlock time, and rewards.
- `ChestSO`: Scriptable Object to hold an array of `ChestData`.
- `ChestModel`: Represents the data and behavior of an individual chest.
- `ChestView`: Manages the visual representation of a chest.
- `ChestController`: Controls the interaction and state management of a chest.
- `ChestSlotController`: Manages the slot where chests can be placed.
- `ChestSlotView`: Handles the visual representation and interaction of chest slots.
- `ChestService`: Coordinates the spawning, opening, and rewards of chests.
- `ChestStateMachine`: Implements a state machine to manage chest states.
- `EventService`: Manages game events and notifications through event controllers.
- `NotificationController`: Controls the display and behavior of in-game notifications.
- `NotificationView`: Visual representation of in-game notifications.

The project utilizes dependency injection, observer pattern, state machine, MVC architecture, and queue data structure to create a robust and organized chest system in Unity.
