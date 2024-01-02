# Chest System Project

[![Chest System Project Overview](https://img.youtube.com/vi/-oyRYkG7hcg/0.jpg)](https://www.youtube.com/watch?v=-oyRYkG7hcg)

The Chest System Project is a comprehensive system featuring advanced software design patterns, architecture, and concepts to handle a dynamic chest system in games. This project incorporates the following:

## Key Features

### Singleton Design Pattern

1. **Chest Queue Service:** Manages the queue of chests, ensuring a single instance to handle order in which chest are unlocked.
2. **Chest Slot Manager:** Controls the allocation and management of chest slots, ensuring only one instance for efficient slot handling.
3. **Currency Manager:** Manages in-game currency, utilizing the Singleton pattern for consistent currency handling.
4. **Event Manager:** Handles game events and notifications using the Singleton pattern for centralized event management.
5. **Game Manager:** Manages overall game state and initialization as a Singleton instance.
6. **Chest Service:** Handles the spawning, opening, and rewards of chests, ensuring a single instance for centralized chest management.

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
