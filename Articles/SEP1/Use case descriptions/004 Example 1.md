# Use case description example 1

Let's now take a look at an example of a use case description.

The domain we are looking at is a vehicle rental system. And the particular use case we are looking at is the "Rent a Vehicle" use case.

I will first show the section-based structure, and on the next page I will show the table.

## UC-6: Reserve a Vehicle

Here is an example. 

User stories have an id prefixed with "US", and use cases have an id prefixed with "UC". You can see this in action in the "user stories" and "includes" sections.

Notice in the main scenario, at the end of some steps, you will find [ALT3], or some other number. This is a reference to an alternative scenario. It means that at this step, the sequence of steps may differ from the main scenario. Usually in case of some error, or some user action.

---

### Use case
UC-6. Reserve a vehicle.

### Summary

The employee reserves a vehicle for a customer.

### User stories
This use case covers
- (US-4)
- (US-13)
- (US-19)


### Primary actor
Employee

### Preconditions
- The customer exists in the system (UC-3).
- A vehicle exists in the system (UC-7).

### Post conditions
The selected vehicle is reserved for the chosen customer, at the given date interval.

### Includes
- (UC-11) View customer

### Main scenario

1. Search for customer (UC-11).
3. The system lists matching customers [ALT1].
4. Select a customer.
5. Select to create a new reservation. 
6. Input rental pick up and delivery dates [ALT2].
7. System shows vehicles available for the chosen date interval, i.e. not already reserved, and not under maintenance [ALT3, ALT5].
   Details shown:
   - type, registration number, rental price per day, model, make
8. Select a vehicle from the list [ALT4].
9.  Accept the chosen vehicle.
10. System provides overview of the reservation, by showing details of the reservation, including the vehicle details, customer details, the rental-period, and total price [ALT6].
11. Approve the reservation.
12. System shows confirmation of the reservation, with details of the reservation (same as 10).

### Alternative scenarios
[ALT0] The process can be cancelled at any time.

[ALT1] No matching customers found.
1. The system shows a message "No matching customers found."
2. The user can choose to create a new customer (UC-3), or cancel the process.

[ALT2] Invalid date interval. If either date is before current date, or delivery date is before pick up date.
1. The system shows an error message.
2. The user can choose to input the date interval again.
3. Proceed from step 6 in main scenario.

[ALT3] Select optional search criteria, like vehicle type, number of seats, size of trunk.

[ALT4] Employee can choose to view further details of the vehicle, like fuel type, transmission type, color, number of doors, trunk size.

[ALT5] The list of vehicles is empty.
1. The system shows a message "No vehicles available for the chosen date interval."
2. The user can choose to input the date interval again from step 6 in main scenario, or cancel the process.

[ALT6] Employee can choose to manually alter the price of the reservation.

---


### Notes

To make a reservation, the customer must be known to the system. See: (UC-3) Add a customer.