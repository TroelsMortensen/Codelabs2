# Table format for example 1

The previous page was written in a section-based format. An alternative is a table format, which actually has two sub-categories.

The main difference between section-based and table format is where the element header is located. And I think perhaps the outer box surrounding everything can help with readability.

The two versions of the table format differ only when describing the scenarios.

My main issue with the table format is that students will often make the right side column too slim, making it annoying to read.

First, the single column version:

## Standard table format

---

| Use Case | UC-6: Reserve a Vehicle |
|----------|-------------------|
| **Summary** | The employee reserves a vehicle for a customer. |
| **User stories** | This use case covers<br>- (US-4)<br>- (US-13)<br>- (US-19) |
| **Primary actor** | Employee |
| **Preconditions** | - The customer exists in the system (UC-3).<br>- A vehicle exists in the system (UC-7). |
| **Post conditions** | The selected vehicle is reserved for the chosen customer, at the given date interval. |
| **Includes** | (UC-11) View customer |
| **Main scenario** | 1. Search for customer (UC-11).<br>3. The system lists matching customers [ALT1].<br>4. Select a customer.<br>5. Select to create a new reservation.<br>6. Input rental pick up and delivery dates [ALT2].<br>7. System shows vehicles available for the chosen date interval, i.e. not already reserved, and not under maintenance [ALT3, ALT5].<br>   Details shown:<br>   - type, registration number, rental price per day, model, make<br>8. Select a vehicle from the list [ALT4].<br>9. Accept the chosen vehicle.<br>10. System provides overview of the reservation, by showing details of the reservation, including the vehicle details, customer details, the rental-period, and total price [ALT6].<br>11. Approve the reservation.<br>12. System shows confirmation of the reservation, with details of the reservation (same as 10). |
| **Alternative scenarios** | [ALT0] The process can be cancelled at any time.<br><br>[ALT1] No matching customers found.<br>1. The system shows a message "No matching customers found."<br>2. The user can choose to create a new customer (UC-3), or cancel the process.<br><br>[ALT2] Invalid date interval. If either date is before current date, or delivery date is before pick up date.<br>1. The system shows an error message.<br>2. The user can choose to input the date interval again.<br>3. Proceed from step 6.<br><br>[ALT3] Select optional search criteria, like vehicle type, number of seats, size of trunk.<br><br>[ALT4] Employee can choose to view further details of the vehicle, like fuel type, transmission type, color, number of doors, trunk size.<br><br>[ALT5] The list of vehicles is empty.<br>1. The system shows a message "No vehicles available for the chosen date interval."<br>2. The user can choose to input the date interval again from step 6, or cancel the process.<br><br>[ALT6] Employee can choose to manually alter the price of the reservation. |
| **Notes** | To make a reservation, the customer must be known to the system. See: (UC-3) Add a customer. |

---

And now, the same information, almost the same table, but with "swimlanes" in the main scenario.

## Swimlane table format

One might wish to clarify further which parts the actor does, and which parts the system does. We can make this more explicit by adding a column for "Actor" and "System". So called "swimlanes".

Notice in the below table format how the interaction between the user and the system goes back and forth between the two columns. Notice how in a single row, only one of the two columns is used. It is important for readability to keep this structure.

The main difference here is the sub-table for the main sequence of steps. You _could_ do this for the alternate scenarios as well, but I think that is less relevant.


| Use Case | Reserve a Vehicle |
|----------|-------------------|
| **Summary** | The employee reserves a vehicle for a customer. |
| **User stories** | This use case covers<br>- (US-4)<br>- (US-13)<br>- (US-19) |
| **Primary actor** | Employee |
| **Preconditions** | - The customer exists in the system (UC-3).<br>- A vehicle exists in the system (UC-7). |
| **Post conditions** | The selected vehicle is reserved for the chosen customer, at the given date interval. |
| **Includes** | (UC-11) View customer |
| **Main scenario** | <table style="width:100%"><tr><th style="width:50%">Actor</th><th style="width:50%">System</th></tr><tr><td>1. Search for customer (UC-11).</td><td></td></tr><tr><td></td><td>3. The system lists matching customers [ALT1].</td></tr><tr><td>4. Select a customer.</td><td></td></tr><tr><td>5. Select to create a new reservation.</td><td></td></tr><tr><td>6. Input rental pick up and delivery dates [ALT2].</td><td></td></tr><tr><td></td><td>7. System shows vehicles available for the chosen date interval, i.e. not already reserved, and not under maintenance [ALT3, ALT5].<br>Details shown:<br>- type, registration number, rental price per day, model, make</td></tr><tr><td>8. Select a vehicle from the list [ALT4].</td><td></td></tr><tr><td>9. Accept the chosen vehicle.</td><td></td></tr><tr><td></td><td>10. System provides overview of the reservation, by showing details of the reservation, including the vehicle details, customer details, the rental-period, and total price [ALT6].</td></tr><tr><td>11. Approve the reservation.</td><td></td></tr><tr><td></td><td>12. System shows confirmation of the reservation, with details of the reservation (same as 10).</td></tr></table> |
| **Alternative scenarios** | [ALT0] The process can be cancelled at any time.<br><br>[ALT1] No matching customers found.<br>1. The system shows a message "No matching customers found."<br>2. The user can choose to create a new customer (UC-3), or cancel the process.<br><br>[ALT2] Invalid date interval. If either date is before current date, or delivery date is before pick up date.<br>1. The system shows an error message.<br>2. The user can choose to input the date interval again.<br>3. Proceed from step 6.<br><br>[ALT3] Select optional search criteria, like vehicle type, number of seats, size of trunk.<br><br>[ALT4] Employee can choose to view further details of the vehicle, like fuel type, transmission type, color, number of doors, trunk size.<br><br>[ALT5] The list of vehicles is empty.<br>1. The system shows a message "No vehicles available for the chosen date interval."<br>2. The user can choose to input the date interval again from step 6, or cancel the process.<br><br>[ALT6] Employee can choose to manually alter the price of the reservation. |
| **Notes** | To make a reservation, the customer must be known to the system. See: (UC-3) Add a customer. |
