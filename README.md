Here is the updated `README.md` with the credit changed to **Rose EX**.

---

# 🌀 Sorcery Engine (JJK Fork)

**Sorcery Engine** is a specialized, high-performance fork of the **Intersect Engine (v0.8.0 Ascension)**, heavily customized to facilitate **Jujutsu Kaisen (JJK)** style gameplay. 

This engine moves away from traditional tab-target RPG mechanics in favor of a fast-paced, strategic "Sorcery Combat" system involving high-risk/high-reward techniques, environmental manipulation, and timing-based defense.

---

## 🛠 Current Features

### ⛩️ Domain Expansion System
A fully integrated Domain Expansion system that utilizes Intersect’s map-instance technology to create isolated combat environments.
*   **Expansion Manager:** Handles the logic of opening, tracking, and collapsing domains.
*   **Sure-Hit Logic:** Attacks from a Domain Owner bypass standard accuracy/evasion checks, ensuring a "Guaranteed Hit" on targets within the domain.
*   **Domain Clashing:** If two domains overlap, the engine compares `DomainPower` (Refinement). The weaker domain collapses, while equal domains neutralize each other's "Sure-Hit" effects.

### ⚔️ Advanced Combat & Parrying
*   **Perfect Blocking:** A 300ms window at the start of a block that completely nullifies incoming damage and staggers the attacker.
*   **Counter Buff:** Successfully parrying an attack grants a 2-second "Counter" window, increasing the damage of your next attack by 50%.
*   **Stun & Stagger:** Combat feels weightless with the addition of stagger timers that prevent attackers from spamming after being parried.

### 🔥 Cursed Technique Burnout
*   **Technique Lockout:** After a Domain Expansion ends, players suffer from "Burnout" for 15 seconds, during which they cannot cast Innate Techniques (Combat Spells).
*   **RCT Recovery:** Integrated a healing-to-recovery mechanic where receiving healing (Reverse Cursed Technique) reduces the remaining burnout time by 3 seconds per tick.

---

## 🚧 Work in Progress (WIP)

*   **Anti-Domain Techniques:** Implementing "Simple Domain" and "Hollow Wicker Basket" status effects that neutralize Sure-Hit logic while active.
*   **Barrier-less Domains:** Developing logic for domains (like Malevolent Shrine) that exist on the current map with a defined radius rather than teleporting to a new instance.
*   **Cursed Energy Stat:** A dedicated vital system for Cursed Energy that regenerates based on combat flow rather than just time.

---

## 📅 Planned Features

*   **Black Flash:** A high-level combat mechanic that rewards precise timing with a critical hit multiplier and a temporary "In the Zone" stat buff.
*   **Binding Vows:** A system allowing players to accept debuffs (e.g., "Revealing one's hand") in exchange for massive power boosts to their next technique.
*   **Shikigami Management:** Advanced NPC summoning logic for Ten Shadows-style gameplay.
*   **Environmental Destruction:** Map-tile swapping logic that mimics the destruction caused during high-level sorcery battles.

---

## 🚀 Getting Started

1.  **Build:** Open the solution in **Visual Studio 2022**. Set configuration to **Release | x64**.
2.  **Database:** Ensure the `intersect.db` is migrated to include `DomainExpansionId` and burnout columns.
3.  **Assets:** Place JJK-themed sprites and animations in `Resources/Entities` and `Resources/Animations`.

---

## 📜 Credits
*   **Rose EX:** Systems engineering, JJK customization, and combat overhaul.
*   **Intersect Engine:** Base framework and engine source.
*   **Intersect Assets:** Provided the high-quality base engine assets and textures.
*   **MoneyPigeon:** Professional logo design for Sorcery Engine.

---

### *“Throughout Heaven and Earth, I alone am the honored one.”*
