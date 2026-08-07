# Exercise - Rock-Paper-Scissors Game

### Problem Statement
Create a program that simulates a game of Rock-Paper-Scissors between the user and a computer opponent. The computer's choice should be determined randomly.

### Instructions
1. Ask the user to enter their choice (`rock`, `paper`, or `scissors`).
2. Generate a random number (0, 1, or 2) to represent the computer's choice:
   - `0` for `rock`
   - `1` for `paper`
   - `2` for `scissors`
3. Compare the user's choice and the computer's choice to determine the winner.
4. Print the result of the game (e.g., "You win!", "Computer wins!", "It's a tie!").

### Rules
- Rock beats Scissors
- Scissors beats Paper
- Paper beats Rock

### Example Output
```
Enter your choice (rock, paper, scissors):
rock
Computer chose: scissors
You win!
```

### Hint: Generating Random Numbers

To generate random numbers in Java, you can use the `Math.random()` method or the `Random` class from the `java.util` package.

#### Rolling 1, 2, or 3
Use the `Math.random()` method to generate a random number between 1 and 3:
```java
int roll = (int) (Math.random() * 3) + 1;
```
- `Math.random()` generates a random double between 0.0 and 1.0.
- Multiplying by 3 gives a range of 0.0 to 2.999...
- Adding 1 shifts the range to 1, 2, or 3.
- Casting to `int` truncates the decimal part, resulting in 1, 2, or 3.


## Extension Ideas

Redo the exercise to implement the [Rock-Paper-Scissors-Lizard-Spock game](https://bigbangtheory.fandom.com/wiki/Rock,_Paper,_Scissors,_Lizard,_Spock). 

<video src="https://www.youtube.com/watch?v=pIpmITBocfM"></video>

The rules are:

- **Rock** crushes **Scissors**
- **Rock** crushes **Lizard**
- **Paper** covers **Rock**
- **Paper** disproves **Spock**
- **Scissors** cuts **Paper**
- **Scissors** decapitates **Lizard**
- **Lizard** eats **Paper**
- **Lizard** poisons **Spock**
- **Spock** smashes **Scissors**
- **Spock** vaporizes **Rock**

### Instructions
1. Extend the program to include the additional choices (`lizard` and `spock`).
2. Update the random number generation to include values for `lizard` and `spock`.
3. Modify the comparison logic to account for the new rules.

### Example Output
```
Enter your choice (rock, paper, scissors, lizard, spock):
spock
Computer chose: scissors
Spock smashes Scissors. You win!
```