# Exercise 13 - University Course System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class University {
        - universityName : String
        + addDepartment(department : Department) void
        + getCourseByCode(courseCode : String) Course
        + getAllStudents() ArrayList~Student~
        + getTotalEnrollment() int
    }
    
    class Department {
        - departmentName : String
        - departmentCode : String
        + Department(departmentName : String, departmentCode : String)
        + getDepartmentName() String
        + addCourse(course : Course) void
        + getCoursesOffered() ArrayList~Course~
    }
    
    class Course {
        - courseCode : String
        - courseName : String
        - credits : int
        - maxStudents : int
        + Course(courseCode : String, courseName : String, credits : int, maxStudents : int)
        + getCourseCode() String
        + getCredits() int
        + enrollStudent(student : Student) boolean
        + getEnrolledStudents() ArrayList~Student~
        + isFull() boolean
    }
    
    class Student {
        - studentId : int
        - name : String
        - email : String
        - enrollmentDate : LocalDate
        + Student(studentId : int, name : String, email : String, enrollmentDate : LocalDate)
        + getStudentId() int
        + getName() String
        + getTotalCredits() int
    }
    
    class Lecture {
        - weekday : String
        - startTime : String
        - endTime : String
        - room : String
        + Lecture(weekday : String, startTime : String, endTime : String, room : String)
        + getWeekday() String
        + getRoom() String
    }
    
    class Instructor {
        - employeeId : int
        - name : String
        - title : String
        - office : String
        + Instructor(employeeId : int, name : String, title : String, office : String)
        + getEmployeeId() int
        + getName() String
        + getTitle() String
    }
    
    University --> "*" Department : departments
    Department --> "*" Course : courses
    Course --> "*" Student : enrolledStudents
    Course --> "*" Lecture : lectures
    Course --> "1" Instructor : instructor
```

## Notes:
- Students cannot enroll in a course if it's full
- Use `java.time.LocalDate` for enrollment dates

