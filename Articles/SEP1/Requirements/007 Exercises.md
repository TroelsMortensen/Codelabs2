# Exercises

Below you will find two cases, and you are tasked with extracting the requirements for the system.

## Exercise 1: Haunted House Marketplace

You're meeting with Sarah Chen, the founder of "**HauntHub**", a startup that's disrupting the real estate market.\
Here's what Sarah tells you:

_"So, you know how people buy and sell houses? Well, we're doing that, but specifically for haunted properties. I know, it sounds crazy, but there's actually a huge market for this. We've got buyers who are collectors, paranormal investigators, or just people who think a haunted house is the coolest thing ever._

_Here's what we need: First, people need to be able to list their haunted properties with us. They should be able to tell us about the house - you know, the basic stuff like address, price, number of bedrooms, all that normal real estate stuff. But then we need the spooky details. Like, what kind of haunting is it? Is it a residual haunting or an intelligent one? How many entities are there? When do they tend to be active? Have there been physical disturbances, or is it more subtle?_

_Oh, and we definitely need a rating system. We're calling it the 'Spook Rating' - like a one to ten scale, where one is 'occasionally hears footsteps' and ten is 'furniture flies across the room daily.' Our users really want to know what they're getting into._

_For buyers, they need to search and filter. Like, 'show me only houses with poltergeist activity under $500k in the Midwest.' Or maybe they want to find houses with a specific type of haunting - residual energy, intelligent spirits, you name it._

_We also need user accounts. Both buyers and sellers need profiles. Sellers upload their properties, buyers can save their favorites. Some of our power users really like to track market trends - like, are poltergeist hauntings getting more or less expensive? Or what's the average Spook Rating in certain areas?_

_Here's the thing - we want to make this feel legitimate. We're not selling fake haunting reports. So we need verification. When someone lists a property, we want them to provide evidence. Photos, videos, audio recordings, witness statements - whatever they have. We verify this stuff before it goes live. And we want to track the verification status, so buyers can see what evidence is available._

_Actually, speaking of going live, we need a draft system. Sellers should be able to work on their listings and save them as drafts before publishing. That way they don't lose their work._

_For pricing, we take a commission like normal real estate platforms - 5% of the sale price. We're still figuring out payment processing, but for now, we just need to track the sale price and calculate the commission._

_Oh, and we definitely need filtering for safety. Some hauntings are extremely dangerous - like Class 10 entities that can physically harm people. We want to make sure buyers are informed about the danger level, and we might even require a waiver for the really intense ones. Safety first, you know?_

_We're launching in the next month, so we're keeping this simple to start. Just the core functionality. Maybe later we'll add things like chat between buyers and sellers, or integration with paranormal investigation services, but for now, let's keep it focused on the listings and search functionality."_

**Your task:** Extract and identify the functional requirements from Sarah's description. You should be able to find at least 10 key requirements. 

## Exercise 2: Cloud Spotting Platform

You're meeting with Marcus Rivera, the founder of "**NimbusWatch**", a platform for cloud formation enthusiasts and collectors.\
Here's what Marcus tells you:

_"You know, people collect stamps, coins, Pokémon cards. We're doing something similar, but for cloud formations. Sounds weird, right? But there's actually a passionate community of cloud spotters out there - meteorologists, photographers, weather enthusiasts, even just people who love looking up._

_Here's the basic idea: People spot interesting cloud formations, take photos, and upload them to our platform. But we're not just a photo sharing site - we want to create a real ecosystem around cloud collecting._

_First thing - we need a way for users to register and create profiles. Some people are casual observers, others are serious collectors with thousands of verified formations. We want to show their collection stats, reputation level, that kind of thing. Users should be able to view each other's profiles and collections._

_The core feature is cloud uploads. When someone takes a picture of a cloud, they need to provide basic information: the date and time, location - GPS would be great if we can get that from the photo metadata. Maybe weather conditions at the time. But here's what makes us special - we need detailed classification. What type of cloud is it? Cumulus, stratus, cirrus, the specific subcategories. Unusual formations like mammatus clouds or lenticular formations get bonus points._

_We need a verification system. Not everyone's photo is legit, you know? So when someone uploads a cloud, it should go into a pending state. Other users or moderators can verify it - like, is this actually what they say it is? Is the photo real or doctored? We'll need some basic image analysis to detect fakes. Once verified, it gets added to the user's collection._

_Now, the rarity system is huge. Some cloud formations are incredibly rare. Like, a perfectly formed fallstreak hole might appear once every few years in a specific region. We need to calculate rarity based on multiple factors - the formation type, location, time of year, weather conditions. We can assign rarity scores from common to legendary. This creates value._

_For search and discovery, users need to browse by multiple criteria. Filter by cloud type, rarity level, location, date range. Maybe they want to see all the verified 'mammatus' clouds in their state. Or they're looking for the rarest formations ever uploaded. We should have trending clouds, most liked formations, that kind of social stuff too._

_The community aspect is important. Users should be able to follow each other, like formations, leave comments. We'll need notification systems - 'Your cloud was verified!', 'Someone liked your formation', 'A new rare cloud was spotted near you'. 

_Profiles need to showcase achievements. Badges for milestones like '100 verified uploads', 'Spotted a legendary formation', 'Verified 50 others' formations'. Leaderboards showing who has the rarest collection._

_Actually, we're planning to add predictions in the future - machine learning that can predict where and when rare formations might appear based on weather data. But let's not worry about that for now. For the MVP, focus on the upload, verification, classification, and discovery features. 

_One more thing - we need user behavior tracking. Analytics like which regions are most active, which cloud types are trending, seasonal patterns. This helps us understand our community and could be valuable data down the line._

_We want this to feel premium and trustworthy. So we'll need content moderation - flagging inappropriate uploads, dealing with fake submissions. Maybe a report system. But also reward good behavior - users with high verification accuracy get elevated status."_

**Your task:** Extract and identify the functional requirements from Marcus's description. You should be able to find at least 10 key requirements.
