# Exercise 21 - Recipe Manager System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class RecipeBook {
        - bookName : String
        - author : String
        + addRecipe(recipe : Recipe) void
        + removeRecipe(recipeId : int) void
        + getRecipesByCategory(category : String) ArrayList~Recipe~
        + getRecipesByDifficulty(difficulty : String) ArrayList~Recipe~
        + getTotalRecipes() int
    }
    
    class Recipe {
        - recipeId : int
        - name : String
        - category : String
        - difficulty : String
        - prepTime : int
        - cookTime : int
        - servings : int
        - instructions : String
        - createdDate : LocalDate
        + Recipe(recipeId : int, name : String, category : String, difficulty : String, prepTime : int, cookTime : int, servings : int)
        + getRecipeId() int
        + getName() String
        + addIngredient(ingredient : Ingredient) void
        + getIngredients() ArrayList~Ingredient~
        + getTotalTime() int
        + scaleRecipe(newServings : int) void
        + getNutrition() NutritionInfo
    }
    
    class Ingredient {
        - name : String
        - quantity : double
        - unit : String
        - caloriesPerUnit : double
        + Ingredient(name : String, quantity : double, unit : String, caloriesPerUnit : double)
        + getName() String
        + getQuantity() double
        + getUnit() String
        + getTotalCalories() double
        + scale(factor : double) void
    }
    
    class NutritionInfo {
        - totalCalories : double
        - protein : double
        - carbs : double
        - fat : double
        + NutritionInfo(totalCalories : double, protein : double, carbs : double, fat : double)
        + getTotalCalories() double
        + getCaloriesPerServing(servings : int) double
    }
    
    class Review {
        - reviewId : int
        - reviewerName : String
        - rating : int
        - comment : String
        - reviewDate : LocalDate
        + Review(reviewId : int, reviewerName : String, rating : int, comment : String, reviewDate : LocalDate)
        + getRating() int
        + getComment() String
    }
    
    class MealPlan {
        - planName : String
        - startDate : LocalDate
        - endDate : LocalDate
        + MealPlan(planName : String, startDate : LocalDate, endDate : LocalDate)
        + addRecipe(recipe : Recipe, day : int, mealType : String) void
        + getRecipesForDay(day : int) ArrayList~Recipe~
        + getTotalCalories() double
    }
    
    RecipeBook --> "*" Recipe : recipes
    Recipe --> "*" Ingredient : ingredients
    Recipe --> "1" NutritionInfo : nutrition
    Recipe --> "*" Review : reviews
    MealPlan --> "*" Recipe : meals
```

## Notes:
- Difficulty levels: "Easy", "Medium", "Hard"
- Meal categories: "Breakfast", "Lunch", "Dinner", "Dessert", "Snack"
- Times are measured in minutes
- Rating is from 1 to 5 stars
- Scaling a recipe multiplies all ingredient quantities by (newServings / currentServings)
- Use `java.time.LocalDate` for dates

