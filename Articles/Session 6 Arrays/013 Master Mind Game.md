# Master Mind Game

Implement the classic board game Master Mind as a console application using letters instead of colors.

## Game Rules

Master Mind is a code-breaking game where:
- The computer generates a secret code of 4 letters (using the letters A-F)
- You have 10 attempts to guess the code
- After each guess, you get feedback:
  - **Correct position**: Number of letters in the right position
  - **Wrong position**: Number of correct letters but in wrong positions
  - **Not in code**: Number of letters that aren't in the secret code at all

## Available Letters

Use these 6 letters: **A, B, C, D, E, F**

## Example Game Session

```
=== MASTER MIND GAME ===
I've generated a secret 4-letter code using letters A-F.
You have 10 attempts to crack it!

Attempt 1/10: Enter your guess (4 letters): ABCD
Feedback: 1 correct position, 1 wrong position, 2 not in code

Attempt 2/10: Enter your guess (4 letters): ACDE
Feedback: 0 correct positions, 2 wrong positions, 2 not in code

Attempt 3/10: Enter your guess (4 letters): BCDA
Feedback: 2 correct positions, 2 wrong positions, 0 not in code

Attempt 4/10: Enter your guess (4 letters): BCDE
Feedback: 3 correct positions, 0 wrong positions, 1 not in code

Attempt 5/10: Enter your guess (4 letters): BCDE
Feedback: 3 correct positions, 0 wrong positions, 1 not in code

Attempt 6/10: Enter your guess (4 letters): BCDE
Feedback: 3 correct positions, 0 wrong positions, 1 not in code

Attempt 7/10: Enter your guess (4 letters): BCDE
Feedback: 3 correct positions, 0 wrong positions, 1 not in code

Attempt 8/10: Enter your guess (4 letters): BCDE
Feedback: 3 correct positions, 0 wrong positions, 1 not in code

Attempt 9/10: Enter your guess (4 letters): BCDE
Feedback: 3 correct positions, 0 wrong positions, 1 not in code

Attempt 10/10: Enter your guess (4 letters): BCDE
Feedback: 3 correct positions, 0 wrong positions, 1 not in code

Game Over! The secret code was: BCDE
You didn't crack the code this time. Better luck next time!
```

## Another Example (Winning Game)

```
=== MASTER MIND GAME ===
I've generated a secret 4-letter code using letters A-F.
You have 10 attempts to crack it!

Attempt 1/10: Enter your guess (4 letters): ABCD
Feedback: 0 correct positions, 2 wrong positions, 2 not in code

Attempt 2/10: Enter your guess (4 letters): EFAB
Feedback: 1 correct position, 1 wrong position, 2 not in code

Attempt 3/10: Enter your guess (4 letters): CDEF
Feedback: 2 correct positions, 0 wrong positions, 2 not in code

Attempt 4/10: Enter your guess (4 letters): BCDE
Feedback: 4 correct positions, 0 wrong positions, 0 not in code

Congratulations! You cracked the code in 4 attempts!
The secret code was: BCDE
```

## Implementation Requirements

### Core Features
1. **Generate secret code**: Randomly select 4 letters from A-F (letters can repeat)
2. **Input validation**: Ensure user enters exactly 4 valid letters
3. **Feedback calculation**: Count correct positions, wrong positions, and letters not in code correctly
4. **Game loop**: Allow up to 10 attempts
5. **Win/lose detection**: Check for correct guess or max attempts reached

### Key Methods to Implement

You may structure the code as you see fit, but consider creating helper methods for the core functionality:

```java
// Generate a random 4-letter code
public static char[] generateSecretCode()

// Validate user input
public static boolean isValidGuess(String guess)

// Calculate feedback (correct positions, wrong positions, not in code)
public static int[] calculateFeedback(char[] secret, char[] guess)

// Main game loop
public static void playGame()
```

### Feedback Calculation Logic

**Correct positions**: Count letters that are in the correct position
**Wrong positions**: Count letters that are correct but in wrong position (don't double-count)
**Not in code**: Count letters that don't appear in the secret code at all

Example:
- Secret: `AABC`
- Guess: `ABCA`
- Correct positions: 1 (first A)
- Wrong positions: 2 (B and C are correct but in wrong positions)
- Not in code: 1 (the last A in the guess doesn't match any remaining letters in secret)

### Input/Output Format

- Display attempt number and remaining attempts
- Show feedback as "X correct positions, Y wrong positions, Z not in code"
- Handle invalid input gracefully
- Show the secret code at the end (win or lose)

## Bonus Features (Optional)

1. **Difficulty levels**: Different code lengths (3, 4, or 5 letters)
2. **Statistics**: Track win/loss ratio
3. **Hints**: Option to reveal one correct letter
4. **Replay**: Ask if player wants to play again
5. **High scores**: Track best performance

## Testing Your Implementation

Test with these scenarios:
- All letters correct in wrong order
- All letters correct in right order (win)
- No correct letters
- Some letters correct in right positions
- Duplicate letters in both secret and guess

Good luck implementing this classic puzzle game!