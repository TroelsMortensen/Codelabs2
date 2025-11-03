# Exercise 2

For each of the following scenarios, create an activity diagram based on the customer interview transcript. Include start and end nodes, activity boxes, decision diamonds, and appropriate arrows with conditions.


## Exercise 2.1: Book Flight Reservation System

**Interview with Travel Agency Manager:**

"So, we need a system for booking flights online. When a customer comes to our site, they'll start by entering where they're flying from and where they're going to, plus their travel dates. Then they click search, and we need to look up all available flights in our database.

Now, sometimes there just aren't any flights available for those dates or that route. When that happens, we should show them a message saying no flights were found, and let them start over with different search criteria.

If we do find flights, we show them a list with all the options. They pick the one they want, and then we need to check if there are actually seats left on that flight. You know, sometimes between when we show the list and when they click, another customer might have booked the last seat. So if the flight's full, we remove it from their list and send them back to pick a different flight.

Once we've confirmed seats are available, they choose their seat preference - window, middle, or aisle. We should check if we have that type available. If not, we can offer them what we do have, or let them choose again.

After that, they enter all their passenger information - name, passport details, that sort of thing. We need to validate that everything's filled in correctly. If something's missing or looks wrong, show an error and make them fix it before continuing.

Then we show them a booking summary with all the details. At this point they can either confirm they want to proceed, or if they changed their mind, let them go back and pick a different flight.

If they confirm, we take them to payment. They enter their credit card information and we process it. Payment can fail for various reasons - insufficient funds, expired card, whatever. If it fails, they should be able to try a different payment method, or they can just cancel the whole booking.

Once payment goes through successfully, we confirm the booking in our system and send them a confirmation email with all their details. That's the end of the process."


## Exercise 2.2: Library Book Return Kiosk

**Interview with Library Manager:**

"We're installing self-service return kiosks, and here's how they should work. When a patron walks up, first thing they do is scan their library card. We pull up their account from the system.

Before we let them do anything, we need to check if their account is in good standing. If it's suspended - maybe they have too many overdue books or unpaid fines - we show them a message telling them to see a librarian, and that's it, we're done.

If their account is fine, they can start returning books. They place a book in the slot, and the kiosk scans the barcode. First thing we check is whether this book actually belongs to our library. Sometimes people try to return books from other branches or even other library systems. If it's not ours, we spit it back out with an error message, and they can either try another book or just finish.

Assuming it is our book, we need to verify it's actually checked out to this person. If it's not - maybe it belongs to someone else or it wasn't checked out at all - we show an error and tell them to see a librarian. Can't process that return.

Now for the returns we can process, we check the due date. If the book is overdue, we calculate the late fee based on how many days late it is. We show them the amount and give them two options: pay it right now at the kiosk, or add it to their account to pay later. If they choose to pay now, they can insert cash or card. Either way, we continue.

For books that aren't overdue, we skip all that fee stuff and just continue.

Next, we mark the book as returned in the system. We also do a quick automated check on the book's condition - sometimes our scanners can detect torn pages or water damage. If we detect damage, we flag it for a librarian to review later, but we still accept the return.

Finally, we update their account, print out a receipt showing what they returned and any fees paid or added to their account. Then we ask if they want to return another book. If yes, we start the whole process over from placing a book in the slot. If no, we're done."


## Exercise 2.3: Gym Membership Registration

**Interview with Gym Owner:**

"Alright, so when someone wants to join our gym, here's the process. They come in and talk to one of our staff members at the front desk. First, we check if they're old enough - you have to be at least 16 to join. If they're under 16, we have to stop right there and let them know they're not eligible.

For everyone else, we need to check if they have any medical conditions we should know about. We have them fill out a quick health questionnaire. If they indicate any serious conditions - like heart problems or recent surgeries - we require them to get a doctor's clearance before we can proceed. We give them a form to take to their doctor, and they have to come back later with it signed. That ends the process for now.

If there are no medical concerns, or they've come back with doctor approval, we move on to showing them our membership options. We have three tiers: Basic, Premium, and VIP. We explain what each one includes, and they pick which one they want.

Now, for Premium and VIP, we need to check if we have capacity. These memberships include access to our small group training classes, and we cap how many Premium and VIP members we can have. If we're at capacity for their chosen tier, we let them know and they can either pick a different tier or cancel.

Once they've settled on an available membership tier, we have them fill out the registration form with all their personal information - name, address, emergency contact, that stuff. We validate that everything's complete. If anything's missing, they have to fill it in.

Then comes the legal stuff. They have to sign our liability waiver. If they refuse to sign it, we can't let them join. Simple as that. Process ends.

After the waiver is signed, we take their photo for their membership card and set them up in our system. Then we process the payment. They can pay with credit card or direct debit. If the payment fails, they can try a different payment method or cancel the whole thing.

Once payment goes through, we print their membership card right there, give them a welcome packet with our rules and class schedule, and they're all set. They can start using the gym immediately."

