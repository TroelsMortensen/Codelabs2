# Guidelines for writing use case descriptions

There are several guidelines, to help you write clearer, better descriptions.

## Terse

No one wants to read walls of text. Make your descriptions short and concise, without leaving out important information. Don't make AI vomit out all the words, it tends to overdo it.

## Write in an Essential UI-Free Style

Try to make the description agnostic of the UI. Don't mention buttons, or drop-down lists, or tables, or other UI elements. Don't "click" anything, instead "select" or "submit" or similar.

Consider a case where a Cashier may say one of their goals is to "log in." The cashier was probably thinking of a GUI, dialog box, user ID, and password. This is a _mechanism_ to achieve a goal, rather than the goal itself.\
Alternative ways log in could be

- Finger print scan
- Face scan
- Voice activation
- PIN code, either on screen or a physical keypad
- Swipe a card
- ...

_How_ you log in is probably less important than the goal of authenticating the user. The purpose of logging in is to gain access to the system. One way or another.

Focus on actor intent.

## Write Black-box use cases

What is a black box? You treat the system as a closed black box, no idea how the internals work. You know what the user does, and the response from the system. If you need to describe something the system does, keep it very general, abstract.

Consider:

- The system records the sale.
vs
- The system writes the sale to a database. …or (even worse):
- The system generates a SQL INSERT statement for the sale…

Your stakeholder does not care about the implementation details. They only care about the outcome.

We focus on _what_ the system does, not _how_ it does it.

