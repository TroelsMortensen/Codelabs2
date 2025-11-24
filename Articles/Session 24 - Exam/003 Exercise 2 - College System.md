# Exercise 2 - College System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class College {
        - name : String
        + getCourseByCode(code : char[]) Course
        + addCourse(course : Course) void
    }
    
    class Course {
        - code : char[]
        - maxNoStudentSeatsAvailable : int
        - semester : int
        + Course(code : char[], maxNoStudentSeatsAvailable : int, semester : int, teacher : Teacher)
        + getCode() char[]
    }
    
    class _Person_ {
        - firstName : String
        - lastName : String
        + getFirstName() String
        + getLastName() String
        + addressedAsName()* String
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
    Course --> "1" Teacher 
    Course --> "*" Student
    _Person_ <|-- Teacher
    _Person_ <|-- Student
```

## Notes:
- Teachers are addressed with their academic title followed by their last name
- Students are addressed with a title based on their year in college followed by their first and last names:
  - 1st year: Freshman
  - 2nd year: Sophomore
  - 3rd year: Junior
  - 4th year: Senior

