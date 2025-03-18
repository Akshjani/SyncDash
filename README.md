# Sync Dash 🕹️

**Sync Dash** is a hyper-casual Unity game where a glowing cube moves forward automatically.  
The player **taps to jump** and **avoids obstacles**, while a **ghost player mirrors the player’s movements with a delay**, simulating real-time network synchronization.

---

## 🎮 Gameplay Features
✅ **Player moves automatically** on the right side of the screen.  
✅ **Tap to jump** and avoid obstacles.  
✅ **Collect glowing orbs** for points.  
✅ **A mirrored ghost player** follows the player's actions with a slight delay.  
✅ **Game speed increases over time** for a progressive challenge.  

---

## 🛠️ Technologies Used
- **Unity 2021+**
- **C#**
- **Object Pooling** for optimized performance
- **Physics-Based Jump System**
- **Shaders & Visual Effects** for immersive gameplay
- **Interpolation & Delay System** for ghost movement synchronization

---

## 🚀 Features Implemented
### 🔹 **Core Mechanics**
- **Real-time movement synchronization**
- **Jump mechanics with collision handling**
- **Dynamic difficulty (speed increases over time)**

### 🔹 **Optimized Performance**
- **Object Pooling** for orbs & enemies
- **Smooth ghost movement interpolation**
- **Minimal memory usage with object recycling**

### 🔹 **Game Logic**
- **Orbs can be collected when touched by the player** (`Trigger`)
- **Enemies cause a collision** (`Physics-based`)
- **Orbs & Enemies return to the pool** when offscreen

---

## 📂 Project Structure
