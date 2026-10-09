# Quizify 🎯

**Quizify** is an interactive 2D trivia quiz game built in **Unity 6** using the Universal Render Pipeline (URP) and TextMesh Pro. The project features modular ScriptableObject architecture for managing quiz questions, a dynamic visual countdown timer, automated score calculation, and interactive UI feedback.

---

## ✨ Features

- **ScriptableObject Question Architecture (`QuestionSO`)**: Create and configure new trivia questions, multiple-choice options, and correct answer indices easily via the Unity Inspector without writing code.
- **Dynamic Countdown Timer (`Timer.cs`)**: Visual circular timer that tracks answering duration and answer-reveal duration with smooth fill transitions.
- **Score Keeping System (`ScoreKeeper.cs`)**: Tracks correct answers vs. questions seen and calculates the player's percentage score in real time.
- **Interactive UI & Visual Feedback**:
  - Highlights correct answers in green/custom sprites upon answer selection.
  - Reveals correct answers when time runs out or upon incorrect selection.
  - Progress bar tracking completed questions across the quiz session.
- **Randomized Question Flow**: Randomizes questions each round and prevents repeated questions during a session.
- **Crisp UI Typography**: Styled using TextMesh Pro with custom fonts and responsive UI layout.

---

## 🛠️ Tech Stack & Requirements

- **Engine**: Unity 6 (`6000.3.23f1`)
- **Render Pipeline**: Universal Render Pipeline (URP 2D)
- **UI System**: Unity UI (uGUI) & TextMesh Pro (TMP)
- **Language**: C#

---

## 📁 Project Structure

```text
Quizify/
├── Assets/
│   ├── Questions/          # ScriptableObjects (QuestionSO) & Question data assets
│   ├── Scenes/             # Game scenes (SampleScene.unity)
│   ├── Scripts/            # Core gameplay logic (Quiz.cs, Timer.cs, ScoreKeeper.cs)
│   ├── Settings/           # URP pipeline & rendering configurations
│   ├── TextMesh Pro/       # Fonts, materials, styles, and TMP assets
├── Packages/               # Unity Package Manager manifest & dependencies
├── ProjectSettings/        # Unity project configurations & build settings
├── .gitignore              # Standard Unity gitignore (ignores Library, Temp, etc.)
└── README.md               # Project documentation
```

---

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/ahmadxhashmi/quizify.git
```

### 2. Open in Unity Hub
1. Open **Unity Hub**.
2. Click **Add** > **Add project from disk**.
3. Select the cloned `Quizify` directory.
4. Ensure you have **Unity 6000.3.23f1** (or compatible Unity 6 release) installed.

### 3. Play the Game
1. In the Project window, navigate to `Assets/Scenes/`.
2. Open `SampleScene.unity`.
3. Click the **Play** button at the top of the Unity Editor.

---

## 🧩 Adding New Questions

1. In the Project tab, right-click in `Assets/Questions/`.
2. Select **Create** > **Quiz Question**.
3. Name your question asset (e.g. `Question 5`).
4. In the Inspector:
   - Enter your **Question** text.
   - Enter 4 answer choices in the **Answers** array.
   - Set the **Correct Answer Index** (0 to 3).
5. Drag your new question asset into the `Questions` list on the `Quiz` GameObject in the scene.

---

## 📄 License

This project is for educational and personal use. Feel free to modify and expand!
