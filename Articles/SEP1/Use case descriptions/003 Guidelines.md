# Guidelines for writing use case descriptions

There are several guidelines, to help you write clearer, better descriptions.

## 1. One use case per user goal

Figure out the user goals of your system. Be aware that multiple user stories can feed into a single user goal. Name the use case after the user goal.

## 2. Who is the primary actor?

Identify relevant actors in your system. For each use case, identify the primary actor. Sometimes this is not entirely clear.\
A "customer" may want to reserve a vehicle, but it is actually the "employee" who uses the system to reserve the vehicle for the customer.

Here, the primary actor is the "employee". Because the employee performs the actions necessary to achieve the goal of reserving a vehicle for a customer.

Alternatively, if this is some online platform, where the customer goes through the reservation process themselves, the primary actor is the "customer".

- I have rented a vehicle through an online form once or twice. The system would show available vehicles, their information, etc.
- I have also worked at a company renting out vehicles ([MLFlyt](https://mlflyt.dk/?gad_source=1&gad_campaignid=17543805731&gclid=Cj0KCQjwvJHIBhCgARIsAEQnWlBW5_BffpdRVVisq5x1nmoLfyYCO_sIl4YY_Th5l7L7sfuTvk4LmGIaAplMEALw_wcB) in Århus). Here the customer would call us, and we would reserve the vehicle for them, in our system. I don't think they rent out vehicles anymore, though.

## 3. Terse

No one wants to read walls of text. Make your descriptions short and concise, without leaving out important information. Don't make AI vomit out all the words, it tends to overdo it.

## 4. Write in an Essential UI-Free Style

Try to make the description agnostic of the UI. Don't mention buttons, or drop-down lists, or tables, or other UI elements. Don't "click" anything, instead "select" or "submit" or similar.

Consider a case where a Cashier may say one of their goals is to "log in" (perhaps not a great use case, though).\
The cashier was probably thinking of a GUI, dialog box, user ID, and password. This is a _mechanism_ to achieve a goal, rather than the goal itself.\
Alternative ways log in could be

- Finger print scan
- Face scan
- Voice activation
- PIN code, either on screen or a physical keypad
- Swipe a card
- ...

_How_ you log in is probably less important than the goal of authenticating the user. The purpose of logging in is to gain access to the system. One way or another.

Focus on actor intent.

Generally: there are no buttons, no ui elements, no drag or swipe or gestures. Focus on more abstract explanations, like "select", "submit", "chooses to", "provides", etc.

## 5. Write black-box use cases

What is a black box? You treat the system as a closed black box, no idea how the internals work. You know what the user does, and the response from the system. If you need to describe something the system does, keep it very general, abstract.

Consider:

- The system records the sale.
 
vs

- The system writes the sale to a database. …or (even worse):
- The system generates a SQL INSERT statement for the sale.

Your stakeholder does not care about (or may not understand) the implementation details. They only care about the outcome.

You describe _input_ and _output_.

### What vs how

You should never explain anything related to _how_ the system does a thing.\
And if you have to explain _what_ the system does, keep it focused on what the user can see.

We focus on _what_ the system does, not _how_ it does it.

- This means you should explain what the system _shows_ the user, or, what the user can see as a system-reaction to their input.
- You should not explain _how_ the system does a thing. And generally, nor should you explain _that_ a system does a thing internally, if the user cannot see it happen.

### The system validates the input

This is a classis step in a use case description. But it is not needed.\
In the happy path, from the user's perspective, the system just accepts the input, no need to explain that anything extra happens with it.\
In an alternate scenario, you can descripe that "_x_ is invalid, and the system shows an error message to the user." The user goes back to a previous step, and tries again.


### The system saves the changes.

This is also an often seen step. At the end of the main scenario, the user has modified some data, and the system saves the changes.\
However, this is also explained as the post condition. So, you don't need a step in the main scenario to explain that the system saves the changes.

## 6. Should provide value

Generally, a use case should provide value to the user. It should be something that the user wants to do, and the system should be able to do it. 

We often see "Logging in" as a use case, but that is rarely the case. Logging in is a mechanism to achieve a goal, rather than the goal itself.

There is something called the "Boss test", to help decide if something is a use case, or perhaps just a precondition, or part of another use case.

The Boss test is as follows:

> Boss: "What did you do today?"
>
> You: "I logged in to the system."

Maybe your boss will think you wasted your time, and you should have done something else.

> Boss: "What did you do today?"
>
> You: "I reserved a vehicle for a customer."

And your boss will be happy, because you provided value to the company.

Logging in, or "is authenticated", is probably just a precondition for another use case.

## 7. Size matters

If a use case is too small, it probably is not relevant as an independent use case. A single or two steps in the main sequence is not interesting. Perhaps this use case is actually part of another use case.
