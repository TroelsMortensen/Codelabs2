# Exercise - Magic spells

Imagine you're a wizard! Write a program that asks the user to enter the name of a spell they want to cast (e.g., "Fireball", "Heal", "Teleport", "Illusion").

Request a spell name from the user. 

You will use a random number between 1 and 100 to determine if the spell is successful, or not. Each spell has a different success rate:
- "Fireball": 15% chance of success
- "Heal": 30% chance of success
- "Teleport": 50% chance of success
- "Illusion": 70% chance of success
- "Chain-lightning": 90% chance of success
- Any other spell: 0% chance of success
- If the spell is successful, print "The spell was successful!".

You can generate a random number using `Math.random()`, which returns a value between 0.0 (inclusive) and 1.0 (exclusive). Multiply this by 100 to get a number between 0 and 100.

Example of generating a random number:

```java
int randomNumber = (int) (Math.random() * 100);
```

The (int) cast is used to convert the double value returned by `Math.random()` into an integer. This will remove the decimal part and give you a whole number between 0 and 99.


## Extension

Now, each spell has three different effects based on the random number generated. That means you must first check if the spell is successful, and then determine the effect based on the random number. Effects are as follows:
- "Fireball":
  - "You scorch your enemy!"
  - "You burn your enemy to ashes!"
  - "You create a massive explosion!"
- "Heal":
  - "You restore a small amount of health."
  - "You heal your wounds completely."
  - "You bring someone back from the brink of death!"
- "Teleport":
  - "You teleport to a nearby location."
  - "You teleport to a distant place."
  - "You teleport to another dimension!"
- "Illusion":
  - "You create a simple illusion."
  - "You create a complex illusion."
  - "You create an illusion that confuses your enemies!"
- "Chain-lightning":
  - "You strike your enemy with a small bolt of lightning."
  - "You unleash a powerful chain of lightning!"
  - "You create a storm of lightning that devastates everything in its path!"
- Any other spell:
  - "The spell fizzles out and has no effect."

For each spell, determine the specific numbers, where the effect changes, for example:
- "Fireball":
  - "You scorch your enemy!" for 0-33
  - "You burn your enemy to ashes!" for 34-66
  - "You create a massive explosion!" for 67-100

And then for Heal it could be different limits:
- "Heal":
  - "You restore a small amount of health." for 0-60
  - "You heal your wounds completely." for 61-80
  - "You bring someone back from the brink of death!" for 81-100