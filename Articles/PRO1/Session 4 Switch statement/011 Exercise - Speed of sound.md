# Exercise - The Speed of Sound

The following table shows the approximate speed of sound in different mediums (feel free to look up more):

| Medium | Speed (feet per second) |
|--------|--------------------------|
| Air    | 1,100                   |
| Water  | 4,900                   |
| Steel  | 16,400                  |

### Instructions
Write a program that asks the user to enter "air", "water", or "steel", and the distance that a sound wave will travel in the medium. The program should then display the amount of time it will take.

How do you handle invalid input?

### Formula
You can calculate the amount of time it takes sound to travel in each medium using the following formulas:

- **Air**: `Time = Distance / 1,100`
- **Water**: `Time = Distance / 4,900`
- **Steel**: `Time = Distance / 16,400`

### Example Output

```
Enter the medium (air, water, steel):
water
Enter the distance (in feet):
9800
The sound wave will take 2.0 seconds to travel.
```