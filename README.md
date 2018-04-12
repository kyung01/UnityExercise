# Unity Exercise 

Clone this Github project and expand it by adding a new game to it.

The project is made in Unity 5.3

It implements a very simple game called React, which briefly displays a stimulus (rectangle) and the player has to respond as quickly as possible.

The codebase is structured so that more complex games can be built on top of it easily and its behavior can be controlled using an xml parameter file (which we call the session file).
See the 'Overview' section below for more details on the structure of the project.


Once you're familiar with the game and how the code is organized, you will be implementing one new game in this project.
In this game you should be able to:

- Specify in the session file whether the stimulus (rectangle) position per trial is random or predefined.
  - The predefined position should be defined inside the session file on a per trial basis. 
  - While the random position should be generated based off a defined range.
- Specify in the session file whether the stimulus should sometimes appear red, in which case the player should NOT respond in order to get a correct response.
- Save all the new game parameters (position, isRed, etc...) when creating a session log file at the end of a game.
- Log important events such as the result of each Trial to a trace file by utilizing the GUILog functionality that the project has, instead of Unity's Debug.Log


# Things to keep in mind

- Treat this exercise as a real world scenario where we ask you to add a new game to our existing project.
- The original React game should remain unchanged.
- The new code should maintain the formatting conventions of the original code.


# Project Overview

- **Stimulus** - An event that a player has to respond to.
- **Session** - A session refers to an entire playthrough of a game.
- **Trial** - A trial is when a player has to respond to a stimulus, which becomes marked as a success or failure depending on the player's response.
- **TrialResult** - A result contains data for how the player responded during a Trial.
- **Session File** - A session file contains all the Trials that will be played during a session, as well as any additional variables that allow us to control and customize the game.
- **Session Log** - An xml log file generated at the end of a session, contains all the attributes defined in the source Session file as well as all the Trial results that were generated during the game session.
- **Trace Log** - A text log file generated using GUILog for debugging and analytical purposes. GUILog requires a SaveLog() function to be called at the end of a session in order for the log to be saved.
- **GameController** - Tracks all the possible game options and selects a defined game to be played at the start of the application.
- **InputController** - Checks for player input and sends an event to the Active game that may be assigned.
- **GUILog** - A trace file logging solution, similar to Unity's Debug.Log, except this one creates a unique log file in the application's starting location.
- **GameBase** - The base class for all games.
- **GameData** - A base class, used for storing game specific data.
- **GameType** - Used to distinguish to which game a Session file belongs to.


# Submission

There is a new scene called "Second" with green background color. Please proceed to play the "second" scene to test new implementation of the game.
You can now define the position of stimulus in your xml sheet.
You can now define whether the stimlus will be red or white. Red stimlus requires player to not enter any input. Any input during red stimulus is displayed is regarded as wrong answer.
If you do not define position, it will use the default 0 value for both x and y.
You could define position to be randomly chosen by the game.

ex)```<trial delay="0.2" />``` //Your default implementation. The coordinates for x and y will be 0 and 0 and stimulus will be white.

ex)<trial delay="0.2" position ="11 45" /> //The coordinates for x and y will be 11 for x, and 45 for y.

ex) <trial delay="0.2" isRed = "true" /> //Your stimlus will be red now

ex) <trial delay="0.2" isRed = "true" position ="random"/> //Your stimlus will be red and random

ex) <trial delay="0.2" isRed = "true" position ="11 45"/> //Your stimlus will be red and will be located at position of 11 x coordinate and 45 y coordinate.

Trial and SessionData classes are most heavily edited to allow new data (different color and position of stimulus) to be applied. However older format of xml sheet is still accepted.
React class is lightly modified. Some of its variables' access level has been changed from private to protected to allow an extended class React2 to access them.
React2 class is implemented to handle new version of the game. React2 extends from React class. React2 is almost identical to React class except when handling red stimlus and processing player's input when the game needs to "AddResult".

# Important

If you want to play the new version of the game, you must use React2. The original React class is left intact as it originally was to allow easy backtrack.