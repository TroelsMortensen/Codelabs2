# Rock Paper Scissors Game

In this exercise, you will implement a classic Rock Paper Scissors game where the player competes against the computer in a best-of-three match. This is an excellent opportunity to practice while loops, user input validation, random number generation, and game logic.

## Game Rules

- **Rock** beats **Scissors**
- **Scissors** beats **Paper**
- **Paper** beats **Rock**
- The game is played in a **best-of-three** format
- The first player (human or computer) to win 2 rounds wins the entire match

## Requirements

Your program should:

1. **Display a welcome message** explaining the game rules
2. **Accept user input** for rock (r), paper (p), or scissors (s)
3. **Validate user input** and ask again if invalid
4. **Generate random computer moves**
5. **Determine the winner** of each round
6. **Keep track of the score** (player wins vs computer wins)
7. **Continue playing** until one player wins 2 rounds (best of 3)
8. **Display the final winner** and ask if the player wants to play again
9. **Use appropriate loops** for game flow and input validation

## Example Game Session

```
=== ROCK PAPER SCISSORS ===
Best of 3 rounds!

Rules:
- Rock beats Scissors
- Scissors beats Paper  
- Paper beats Rock

Round 1:
Enter your choice (r=rock, p=paper, s=scissors): r
You chose: Rock
Computer chose: Scissors
You win this round!

Score: You 1 - 0 Computer

Round 2:
Enter your choice (r=rock, p=paper, s=scissors): p
You chose: Paper
Computer chose: Paper
It's a tie! No points awarded.

Score: You 1 - 0 Computer

Round 2 (continued):
Enter your choice (r=rock, p=paper, s=scissors): s
You chose: Scissors
Computer chose: Rock
Computer wins this round!

Score: You 1 - 1 Computer

Round 3:
Enter your choice (r=rock, p=paper, s=scissors): r
You chose: Rock
Computer chose: Scissors
You win this round!

Score: You 2 - 1 Computer

🎉 CONGRATULATIONS! You won the match! 🎉

Play again? (y/n): n
Thanks for playing!
```

## Implementation Hints

<hint title="Hint 1: Program Structure">

Structure your program with these main components:
- A main game loop that continues until the player doesn't want to play again
- A round loop that continues until someone wins 2 rounds
- Input validation loop for user choices
- Methods to generate computer choice, determine winner, and display results

</hint>

<hint title="Hint 2: Random Computer Choice">

Use `Random` class to generate computer choices:
```java
import java.util.Random;

Random random = new Random();
int computerChoice = random.nextInt(3); // 0, 1, or 2
// 0 = rock, 1 = paper, 2 = scissors
```

</hint>

<hint title="Hint 3: Input Validation">

Use a while loop to validate user input:
```java
String userInput;
do {
    System.out.print("Enter your choice (r=rock, p=paper, s=scissors): ");
    userInput = scanner.next().toLowerCase();
} while (!userInput.equals("r") && !userInput.equals("p") && !userInput.equals("s"));
```

</hint>

<hint title="Hint 4: Game Logic">

Consider using numbers to represent choices and determine winners:
- Rock = 0, Paper = 1, Scissors = 2
- Winner logic: `(player - computer + 3) % 3`
  - Result 0 = tie
  - Result 1 = player wins  
  - Result 2 = computer wins

</hint>