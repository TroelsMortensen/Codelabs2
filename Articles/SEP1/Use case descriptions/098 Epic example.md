# Use Case: Manage Bank Account (UC-MBA)

**Actors:** User, Bank System  
**Goal:** Allow a user to perform core account management functions.  
**Summary:**  
The user can manage their bank account by performing actions such as transferring money, updating account details, viewing transactions, and closing the account. Each action is described in a separate sub-use case.

**Preconditions:**  
- User is authenticated.  
- User has at least one active bank account.

**Postconditions:**  
- Changes made by the user are persisted in the system.  
- Relevant notifications or confirmations are sent to the user.

**Basic Flow (High-Level):**  
1. User navigates to the account management section.  
2. User selects a desired action (transfer, update details, view transactions, close account).  
3. System invokes the corresponding sub-use case.  
4. System provides feedback or confirmation of the action.

**Extensions / Variations:**  
- Each specific action is handled by a **child use case**:  
  - UC-1: Transfer Money  
  - UC-2: Update Account Details  
  - UC-3: View Transactions  
  - UC-4: Close Account

---

## Child Use Cases

### UC-1: Transfer Money
**Actors:** User, Bank System  
**Goal:** Transfer money from one account to another.  
**Summary:** User selects an account, enters recipient details and amount, and completes the transfer.

**Basic Flow:**  
1. User selects “Transfer Money”.  
2. User enters recipient account and amount.  
3. System validates details and checks balance.  
4. System completes transfer and notifies user.

**Alternative Flows:**  
- Insufficient balance → system shows error and aborts transfer.  
- Invalid recipient → system shows error and requests correction.

---

### UC-2: Update Account Details
**Actors:** User, Bank System  
**Goal:** Modify account information (e.g., address, contact info).  

**Basic Flow:**  
1. User selects “Update Account Details”.  
2. User edits details and submits changes.  
3. System validates inputs and updates account.  
4. System confirms successful update.

---

### UC-3: View Transactions
**Actors:** User, Bank System  
**Goal:** Review past transactions for an account.  

**Basic Flow:**  
1. User selects “View Transactions”.  
2. User selects account and date range.  
3. System displays transactions in chronological order.

---

### UC-4: Close Account
**Actors:** User, Bank System  
**Goal:** Close an existing bank account.  

**Basic Flow:**  
1. User selects “Close Account”.  
2. System confirms action with user.  
3. System closes the account if preconditions are met (e.g., balance is zero).  
4. System confirms closure.

**Alternative Flow:**  
- Account has remaining balance → system requests withdrawal or transfer before closure.
