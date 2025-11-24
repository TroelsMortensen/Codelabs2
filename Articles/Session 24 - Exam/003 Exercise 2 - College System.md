# Exercise 2 - College System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class College {
        - name : String
        + getCourseByCode(code : char[]) Course
        + codeCheck(code1 : char[], code2 : char[]) boolean
    }
    
    class Course {
        - code : char[]
        + Course(code : char[], maxNoStudentSeatsAvailable : int, teacher : Teacher)
        + getCode() char[]
    }
    
    class Person {
        - firstName : String
        - lastName : String
        + getFirstName() String
        + getLastName() String
        + addressedAsName() String
    }
    
    class Teacher {
        - academicTitle : String
        + addressedAsName() String
    }
    
    class Student {
        - number : int
        - yearInCollege : int
        + addressedAsName() String
    }
    
    College --> "*" Course
    Course --> "1" Teacher : teacher
    Course --> "*" Student
    Teacher --|> Person
    Student --|> Person
```

## Notes:
- Teachers are addressed with their academic title followed by their last name
- Students are addressed with a title based on their year in college followed by their first and last names:
  - 1st year: Freshman
  - 2nd year: Sophomore
  - 3rd year: Junior
  - 4th year: Senior
- This exercise does not require date handling

