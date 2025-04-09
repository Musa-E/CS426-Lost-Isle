README.txt - CS426 Assignment 6
Project: The Lost Isle
Unity Version: 6000.0.33f1

Team Members:
- Simran Batra
- Musa Elqaq
- Karthik Ragi (Graduate Student)

---

🎮 Overview:  
_The Lost Isle_ is a survival-exploration game where the player wakes up on a mysterious and dangerous alien island after a crash landing. The player must explore the environment, manage oxygen levels, avoid a lurking entity called "The Watcher," and collect fuel to power their escape. As oxygen runs low, players must rely on visual cues, guidance systems, and environmental reactions to find nearby resources and survive.

---

🧠 AI Systems (1 per team member):

• Simran:
  - Created basic Watcher movement AI and detection logic.
  - Implemented a darkening screen effect when the player is near the Watcher, enhancing tension.

• Musa:
  - Designed AI behavior for Oxygen Tanks using NavMesh.
  - Tanks actively move away from the player when approached and can only be collected after avoiding twice.

• Karthik:
  - Developed a custom A* pathfinding system from scratch.
  - Built a dynamic oxygen detection system that spawns tanks and guides the player using a UI arrow when oxygen is low.
  - Integrated the system with a Mecanim-triggered animation (wing flap) and synchronized an 8-second audio effect.

---

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

  ---

🧪 Physics & Visual Effects:

• Colliders & Triggers: Used for zone detection, proximity reactions, and tank collection logic.   
• Rigidbody (Musa): Physics-based reactions for oxygen tanks that bounce away.   
• Particle System (local only): Sparkle/energy glow for oxygen tanks tested but excluded from GitHub due to size.   

---

💡 Lights & Textures:

- Scene includes directional and point lights to establish atmosphere.
- Materials and textures were applied to terrain, oxygen tanks, and the Watcher.
- Some high-res terrain textures were excluded from version control due to GitHub's 100MB size limit.

---

📝 Notes:

- The black hole environment uses custom shader rings and lensing which may cause minor flicker or GPU load spikes. Optimization is ongoing.
- Terrain and large `.tif` textures were tested locally but not pushed to GitHub due to size constraints.
- Git LFS was not enabled to maintain workflow consistency across the team.

---

📹 Demo Video:

A 3-minute demo video has been posted on Piazza, showcasing:
- Watcher AI and visual effects
- Custom oxygen detection/pathfinding system
- Tank avoidance and interaction
- Animation triggers and UI feedback

---

✅ Assignment Requirements Covered:

• ✔️ Three distinct AI constructs (Simran, Musa, Karthik)  
• ✔️ Three Mecanim animations (Watcher wings, ambient animal, movement idle)  
• ✔️ Three physics elements (colliders, rigidbody, particle FX [local])  
• ✔️ Three lights + textured environment  
• ✔️ Updated design and README with rationale and roles  
• ✔️ <3-minute demo video submitted on Piazza

---

📦 Final Summary:

This assignment added gameplay logic and character behavior that reacts dynamically to player choices. From Watcher tension to oxygen desperation and resource tracking, each AI system builds on the survival-exploration theme while demonstrating technical variety and collaborative design.

