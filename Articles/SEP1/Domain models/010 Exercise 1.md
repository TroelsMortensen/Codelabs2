# Exercise 1

For each of the following scenarios, create a domain model. 

Identify the entities, their attributes, and the relationships between them. Include multiplicity on all relationships.


## Exercise 1.1: Pet Adoption Center

**Interview with Adoption Center Manager:**

"So, we run a pet adoption center, and we need a system to keep track of everything. We have animals that come in - dogs, cats, rabbits, birds, you name it. For each animal, we need to know basic stuff like their name, age, breed, and when they arrived at our center. We also track their health status - whether they're ready for adoption or need medical care first.

People who want to adopt come in and fill out an application. We keep their contact information - name, phone number, email, address. Each person can submit multiple applications over time if they're interested in different animals.

When someone applies to adopt a specific animal, we create an adoption application. This links the person to the animal they're interested in. We track the date they applied and the status - pending, approved, or rejected. Sometimes multiple people apply for the same popular animal, so we need to keep all those applications.

Once an application is approved and the adoption goes through, we create an adoption record. This shows which animal was adopted, who adopted them, and the adoption date. We also keep the adoption fee amount for our records. After that, the animal is marked as adopted and is no longer available.

Our staff members handle all of this. We have volunteers and paid employees. Each staff member has a name, role, and contact information. They're the ones who process applications, conduct home visits, and finalize adoptions. We need to track which staff member handled each adoption application so we can follow up if needed."


## Exercise 1.2: Movie Theater

Create a domain model based on the following user stories:

1. As a customer, I want to browse available movies so that I can decide what to watch.
2. As a customer, I want to see showtimes for a specific movie so that I can pick a convenient time.
3. As a customer, I want to select my seat from a seating chart so that I can choose where to sit.
4. As a customer, I want to purchase a ticket for a specific showtime and seat so that I can watch the movie.
5. As a theater manager, I want to create showtimes for movies in different theaters so that we can screen multiple films.
6. As a theater manager, I want to assign movies to specific theater rooms so that we can organize our screenings.
7. As a customer, I want to see the price of tickets based on showtime and seat type so that I know how much to pay.
8. As a customer, I want to purchase multiple tickets in one transaction so that I can bring friends.
9. As a theater manager, I want to track which seats are occupied for each showtime so that we don't oversell.
10. As a customer, I want to receive a confirmation with my ticket details so that I have proof of purchase.
11. As a theater manager, I want to set different prices for matinee vs evening shows so that we can offer discounts.
12. As a customer, I want to see movie details like genre, rating, and duration so that I can make an informed choice.
13. As a theater manager, I want to mark a showtime as sold out when all seats are taken.
14. As a customer, I want to cancel my ticket booking before the showtime so that I can get a refund.
15. As a theater manager, I want to see how many tickets were sold for each movie so that I can track popularity.


## Exercise 1.3: Art Gallery

Create a domain model based on the following user stories:

1. As a curator, I want to register new artworks in the collection so that we can track our inventory.
2. As a curator, I want to record artist information including their name, nationality, and birth year so that we can credit creators.
3. As a curator, I want to link artworks to their artists so that visitors can learn about the creators.
4. As a curator, I want to create exhibitions with a name, start date, and end date so that we can organize displays.
5. As a curator, I want to add artworks to exhibitions so that visitors can view them during the exhibition period.
6. As a curator, I want to track which artworks are currently on display vs in storage.
7. As a sales manager, I want to record when artworks are sold, including the sale price and date.
8. As a sales manager, I want to track buyer information for sold artworks so that we maintain provenance records.
9. As a curator, I want to lend artworks to other galleries with loan dates so that we can share our collection.
10. As a curator, I want to track which gallery borrowed which artwork so that we can ensure its return.
11. As a visitor, I want to see which exhibitions are currently active so that I can plan my visit.
12. As a curator, I want to record artwork details like title, creation year, medium, and dimensions so that we have complete records.
13. As a curator, I want to track the provenance (ownership history) of artworks so that we can verify authenticity.
14. As a curator, I want to assign artworks to specific rooms in the gallery during exhibitions so that visitors can find them.
15. As a curator, I want to mark artworks that are part of the permanent collection vs temporary displays.
16. As a sales manager, I want to track which artworks are available for sale vs not for sale.
17. As a curator, I want to create artist portfolios showing all works by a specific artist in our collection.
18. As a curator, I want to categorize artworks by style (impressionism, modern, etc.) so that we can organize exhibitions thematically.

