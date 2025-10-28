# Exercises

Below are several exercises where you are given a set of user stories. Your task is to create a use case diagram for each system.

Consider the following:
- Identify the primary actors
- Merge related user stories into single use cases where appropriate
- Look for opportunities to use **include** relationships for shared functionality
- Keep the diagram at an appropriate level of abstraction

## Exercise 1: Urban Legend Tracker

You are building a crowdsourced system for documenting, verifying, and mapping local urban legends.

**Your task:** Create a use case diagram for this system. Identify at least 3 different actors and look for opportunities to merge related user stories.

**User Stories:**

1. As a visitor, I want to browse urban legends by location so I can discover stories from my area
2. As a visitor, I want to search for legends by keyword so I can find specific types of stories
3. As a visitor, I want to filter legends by category (ghost, cryptid, haunted location) so I can focus on my interests
4. As a contributor, I want to create an account so I can submit my own legends
5. As a contributor, I want to submit a new urban legend with title, description, and location so others can read it
6. As a contributor, I want to upload photos or videos as evidence so I can support my submission
7. As a contributor, I want to mark a legend's location on a map so people know where it happened
8. As a user, I want to vote on the credibility of legends so the community can assess their believability
9. As a user, I want to add comments to legends so I can share my experiences or skepticism
10. As a moderator, I want to review flagged content so I can remove inappropriate submissions
11. As a moderator, I want to verify legend submissions before they go live so quality is maintained
12. As a moderator, I want to merge duplicate legend entries so the database stays clean
13. As a user, I want to receive notifications when someone comments on my submission so I can engage with the community
14. As a user, I want to view legends on an interactive map so I can see spatial patterns
15. As a contributor, I want to link related legends together so people can see connections between stories

---

## Exercise 2: Plant Adoption & Care Network

You are building a system like a pet adoption platform, but for houseplants. Users can adopt plants, track their care, and connect with plant mentors.

**Your task:** Create a use case diagram for this system. Notice that:
- A **User** can browse and view plants
- A **Plant Parent** can do everything a User can do, PLUS adopt plants, track care, and request help
- A **Plant Owner** can do everything a Plant Parent can do, PLUS list plants for adoption and manage adoption requests
- A **Plant Mentor** can do everything a Plant Parent can do, PLUS answer diagnosis requests

Consider using actor extension (inheritance) to show these relationships.

**User Stories:**

1. As a user, I want to create a profile for my account so I can use the system
2. As a user, I want to browse available plants by type so I can find plants I like
3. As a user, I want to search plants by difficulty level so I can match my experience
4. As a user, I want to filter plants by sunlight requirements so I can find suitable plants for my home
5. As a user, I want to view plant details and care requirements so I can learn about plants
6. As a plant parent, I want to request to adopt a plant so I can add it to my collection
7. As a plant parent, I want to log care activities (watering, fertilizing, repotting) so I track what I've done
8. As a plant parent, I want to set care reminders for my plants so I don't forget to water them
9. As a plant parent, I want to upload photos to track my plant's growth over time so I see progress
10. As a plant parent, I want to diagnose plant problems by uploading a photo so I can get help
11. As a plant parent, I want to write a memorial when a plant dies so I can honor my fallen friend
12. As a plant owner, I want to list a plant for adoption with photo and care requirements so others can adopt it
13. As a plant owner, I want to update my plant's information so the listing stays current
14. As a plant owner, I want to mark a plant as adopted so it's no longer available
15. As a plant owner, I want to approve or deny adoption requests so I choose who gets my plants
16. As a plant mentor, I want to answer diagnosis requests so I can help struggling plant parents
17. As a plant mentor, I want to provide care tips and guidance so plant parents succeed

---

## Exercise 3: Neighborhood Time Bank

You are building a community time bank system where members trade time and skills instead of money.

**Your task:** Create a use case diagram for this system. Notice that:
- A **Member** can browse services, request services, view their balance, and rate providers
- A **Service Provider** can do everything a Member can do, PLUS create/manage service offerings, accept requests, and log exchanges
- A **Moderator** can do everything a Service Provider can do, PLUS resolve disputes and suspend members
- An **Administrator** can do everything a Moderator can do, PLUS generate reports and configure system settings

Consider using actor extension (inheritance) to represent these hierarchical relationships.

**User Stories:**

1. As a member, I want to register an account with my contact information so I can join the time bank
2. As a member, I want to verify my identity through a community referral so trust is established
3. As a member, I want to browse available services by category so I can find what I need
4. As a member, I want to search for services by keyword so I can quickly find specific help
5. As a member, I want to view my time balance (hours earned vs spent) so I know my standing
6. As a member, I want to request a service from another member so I can get help
7. As a member, I want to rate and review service providers so others can make informed choices
8. As a service provider, I want to create service offerings with descriptions and time estimates so others know what I provide
9. As a service provider, I want to edit my service offerings so they stay current
10. As a service provider, I want to deactivate service offerings I no longer provide so my profile is accurate
11. As a service provider, I want to accept or decline service requests so I control my commitments
12. As a service provider, I want to propose alternative times for service delivery so scheduling works for both parties
13. As a service provider, I want to log completed service exchanges with time spent so hours are tracked
14. As a moderator, I want to resolve disputes between members so fairness is maintained
15. As a moderator, I want to suspend members who violate community guidelines so the platform stays safe
16. As an administrator, I want to generate community impact reports showing total hours exchanged so we demonstrate value
17. As an administrator, I want to configure system settings and fee structures so the time bank operates properly

---

## Exercise 4: Lost & Found Item Network

You are building a community-driven system for reporting lost and found items to help reunite people with their belongings.

**Your task:** Create a use case diagram for this system. Consider that both "reporting" and "searching" have multiple variations that could be merged.

**User Stories:**

1. As a user, I want to create an account so I can report items
2. As a finder, I want to report a found item with description and location so the owner can be notified
3. As a finder, I want to upload photos of the found item so identification is easier
4. As a finder, I want to specify where the item can be picked up so the owner knows where to go
5. As a loser, I want to report a lost item with description and approximate location so finders can match it
6. As a loser, I want to search found items by category so I can look for my belongings
7. As a loser, I want to filter found items by location and date range so I find relevant matches
8. As a loser, I want to search found items by keyword so I can find specific items quickly
9. As a loser, I want to claim a found item so I can arrange to get it back
10. As a finder, I want to ask verification questions before releasing an item so I confirm true ownership
11. As a finder, I want to approve or deny claims based on verification answers so items go to rightful owners
12. As a user, I want to arrange a meetup location and time so we can exchange the item safely
13. As a user, I want to mark an item as reunited so it's removed from active listings
14. As a user, I want to receive notifications when potential matches are posted so I'm alerted quickly
15. As a moderator, I want to remove suspicious or spam listings so the system stays trustworthy