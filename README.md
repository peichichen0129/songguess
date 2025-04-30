# SongGuess - SpongeBob Karaoke Battle

**A network-based multiplayer music guessing game using C# and TCP/UDP**

---

## Project Overview

**SongGuess** is a multiplayer music quiz game inspired by the Taiwanese variety show “Guess the Song King” and the animated character SpongeBob SquarePants. Developed as a final project for our **Network Programming** course, the game features a SpongeBob-themed song quiz experience, complete with TCP-based chat, UDP-based broadcasting, and a C# GUI.

Two players connect through a server-client architecture and compete in a 10-round music guessing challenge. Each round, players listen to a short music clip and must answer within 30 seconds. Correct answers earn points based on the remaining time (e.g., answering at 8 seconds = 80 points). The player with the higher total score at the end wins.

---

## Features

- **Real-time multiplayer music quiz**
- **TCP Chatroom** with username tagging and Enter-to-send
- **UDP Broadcasting** of random SpongeBob quotes every 7 seconds
- **Score system** based on remaining seconds
- **C# GUI interface** for both server and client
- **Multithreaded server** to handle multiple client connections

---

## Technologies Used

| Component        | Technology           |
|------------------|----------------------|
| Frontend GUI     | C# WinForms          |
| Networking       | TCP/UDP sockets      |
| Communication    | Multithreading (C#)  |
| Broadcasting     | UDP + Timer          |
| Game Sync        | TCP for music sync   |

---

## Architecture Overview

- **TCP Socket** for communication and game data (questions, chat, control)
- **UDP Broadcast** for fun quote announcements
- **Multithreaded Server** for handling concurrent client connections
- **Client-side GUI** to control game flow, receive music, input answers, and interact in real-time

---

## Team & Contributions

- **CHEN, PEI-CHI**  
  - Developed the main game logic and GUI  
  - Implemented TCP chat system and client-server sync

- **HO, TING-WEI**  
  - Implemented UDP broadcast system  
  - Integrated SpongeBob quote announcements

---

## Challenges & Takeaways

> Initially, synchronizing music playback between server and clients was a major challenge. By sending play commands through TCP and managing streams on both ends, we achieved basic sync, though some bugs remain. Despite this, we successfully integrated a chatroom, music guessing game, and broadcasting features—all using C#, which was new for implementing network functions.

This project helped us:
- Apply theoretical networking knowledge (TCP, UDP, threading) in practice
- Design real-time interactive applications
- Gain hands-on experience with C# network programming and GUI design

---

## How to Run

1. Open the project in Visual Studio (C#)
2. Start the server (GUI)
3. Launch client(s), input IP to connect
4. Start the game and enjoy guessing songs!

---

## Demo

![image](https://github.com/user-attachments/assets/12aa5ec7-bdd0-4b24-a50c-e5df57e583d7)
![image](https://github.com/user-attachments/assets/e621a323-9ffe-41f3-becd-3be16ca891e9)


---

## Contact

For questions or collaboration inquiries:  
**james61324@gmail.com**

---
