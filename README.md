# The Lost Isle

Team Members:
  - Simran Batra, 
  - Musa Elqaq, 
  - Karthik Ragi

**UNITY VERSION**: `6000.0.33f1`   
**Design Document**: [Link - must have access to view](https://docs.google.com/document/d/1v9vLBIsELQ7zh-CbmvK-6qBt1XS7PMMaMPOavaJecvk/edit?tab=t.0) 

----

🎮 Overview:  
_The Lost Isle_ is a survival-exploration game where the player wakes up on a mysterious and dangerous alien island after a crash landing. The player must explore the environment, manage oxygen levels, avoid a lurking entity called "The Watcher," and collect fuel to power their escape. As oxygen runs low, players must rely on visual cues, guidance systems, and environmental reactions to find nearby resources and survive.

----

## Objective:

Run around the map while avoiding the watcher.  Your main goal is to find the various fuel canisters (yellow cylinders) scattered around the map.
Keep in mind the amount of oxygen you have while exploring.  Oxygen tanks will spawn near you when you reach critically low levels.

----

## Controls:

### Movement:

  | Keybind | Description |
  | ------- | ----------- |
  |    W    | Move Forward in the direction of the camera |
  |    A    | Move Left from the direction of the camera |
  |    S    | Move Backwards from the direction of the camera |
  |    D    | Move Right from the direction of the camera |

### Utility:
  | Keybind | Description |
  | ------- | ----------- |
  |    F    | Toggle Flashlight |

----

🧠 AI Systems (1 per team member):

• Simran:
  - Created basic Watcher movement AI and detection logic.
  - Implemented a darkening screen effect when the player is near the Watcher, enhancing tension.

• Musa:
  - Designed AI behavior for Oxygen Tanks using NavMesh.
  - Tanks actively move away from the player when approached and can only be collected after avoiding twice.

• Karthik Ragi – Contributions

Assignment 6: AI, Physics, and Mecanim
- Implemented a custom pathfinding system using the A* algorithm to dynamically guide the player toward spawned oxygen tanks
- Built the logic to spawn oxygen tanks based on critical oxygen levels, enhancing survival gameplay
- Integrated the UI-based directional arrow system that responds to pathfinding updates
- Contributed a wing-flap Mecanim animation that triggers when oxygen is low, paired with a synchronized sound effect
- Handled AI logic, spawn behaviors, and interaction feedback using custom C# systems

Assignment 7: UI, Sound, and Alpha Polish
- Designed and implemented a red screen pulse UI when oxygen drops below threshold, creating immediate tension and feedback
- Added a crosshair that follows the mouse for FPS aiming clarity
- Integrated a low oxygen breathing sound effect tied to player status
- Created and tested the UI fade-in screen effect at the start of the game for polish
- Organized and contributed to Alpha feedback handling and helped with overall bug testing

Assignment 8: Shader and Beta Release
- Developed a toggleable flashlight system using a Spot Light, adding immersive visibility to the now-darkened game environment
- Adjusted ambient lighting and directional light to create a survival atmosphere
- Fixed visibility issues with the Watcher’s wings by adjusting material settings and lighting
- Supported polish efforts with feedback-driven scene refinement and lighting enhancements

----

🎞️ Mecanim Animations:

• Wing Flap Trigger (Karthik):
  - Watcher's wings flap once when oxygen drops below a critical threshold.
  - Triggered via Mecanim with an associated audio cue.

• Ambient Animation (Karthik):
  - A rigged Mixamo animal performs idle animation as background ambient life.

• Watcher Idle + Movement (Simran):
  - Basic idle/move animations tied to Watcher AI.

•  Jumping player (Simran & Musa) 
 - basic animination for player from mixamo 

• Idle player (Musa) 
 - basica animination for player from mixamo 

----

🧪 Physics & Visual Effects:

• Colliders & Triggers: Used for zone detection, proximity reactions, and tank collection logic.   
• Rigidbody (Musa): Physics-based reactions for oxygen tanks that bounce away.   
• Particle System (local only): Sparkle/energy glow for oxygen tanks tested but excluded from GitHub due to size.   

----

💡 Lights & Textures:

- Scene includes directional and point lights to establish atmosphere.
- Materials and textures were applied to terrain, oxygen tanks, and the Watcher.
- Some high-res terrain textures were excluded from version control due to GitHub's 100MB size limit.

----

<img width="17" alt="The Code button's dropdown menu" src=image.png> - Shaders

The shaders we implemented, among other things, are:
  - Fuel Canister Pulse   
  - Grass Swaying
  - Flashlight 

----

📝 Notes:

- The black hole environment uses custom shader rings and lensing which may cause minor flicker or GPU load spikes. Optimization is ongoing.
- Terrain and large `.tif` textures were tested locally but not pushed to GitHub due to size constraints.
- Git LFS was not enabled to maintain workflow consistency across the team.

----

📹 Demo Video:

A 3-minute demo video has been posted on Piazza, showcasing:
- Watcher AI and visual effects
- Custom oxygen detection/pathfinding system
- Tank avoidance and interaction
- Animation triggers and UI feedback

----

✅ Assignment Requirements Covered:

• ✔️ Three distinct AI constructs (Simran, Musa, Karthik)  
• ✔️ Three Mecanim animations (Watcher wings, ambient animal, movement idle)  
• ✔️ Three physics elements (colliders, rigidbody, particle FX [local])  
• ✔️ Three lights + textured environment  
• ✔️ Updated design and README with rationale and roles  
• ✔️ <3-minute demo video submitted on Piazza

----

📦 Final Summary:

This assignment added gameplay logic and character behavior that reacts dynamically to player choices. From Watcher tension to oxygen desperation and resource tracking, each AI system builds on the survival-exploration theme while demonstrating technical variety and collaborative design.

