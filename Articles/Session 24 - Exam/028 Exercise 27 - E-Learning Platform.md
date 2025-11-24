# Exercise 27 - E-Learning Platform System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class LearningPlatform {
        - platformName : String
        - foundedDate : LocalDate
        + addCourse(course : Course) void
        + addInstructor(instructor : Instructor) void
        + enrollStudent(student : Student, course : Course) boolean
        + getPopularCourses() ArrayList~Course~
    }
    
    class Course {
        - courseId : int
        - title : String
        - description : String
        - difficulty : String
        - estimatedHours : int
        - enrollmentCount : int
        + Course(courseId : int, title : String, description : String, difficulty : String, estimatedHours : int)
        + getCourseId() int
        + getTitle() String
        + addLesson(lesson : Lesson) void
        + getLessons() ArrayList~Lesson~
        + getCompletionRate() double
        + getTotalDuration() int
    }
    
    class Lesson {
        - lessonId : int
        - title : String
        - duration : int
        - orderNumber : int
        + Lesson(lessonId : int, title : String, duration : int, orderNumber : int)
        + getLessonId() int
        + getTitle() String
        + getDuration() int
    }
    
    class VideoLesson {
        - videoUrl : String
        - resolution : String
        + getVideoUrl() String
    }
    
    class QuizLesson {
        - passingScore : int
        - timeLimit : int
        + getPassingScore() int
    }
    
    class ReadingLesson {
        - content : String
        - wordCount : int
        + getEstimatedReadingTime() int
    }
    
    class Student {
        - studentId : int
        - name : String
        - email : String
        - registrationDate : LocalDate
        + Student(studentId : int, name : String, email : String, registrationDate : LocalDate)
        + getStudentId() int
        + enrollInCourse(course : Course) void
        + completeLesson(lesson : Lesson) void
        + getProgress(course : Course) double
    }
    
    class Instructor {
        - instructorId : int
        - name : String
        - expertise : String
        - rating : double
        + Instructor(instructorId : int, name : String, expertise : String)
        + getInstructorId() int
        + createCourse(title : String) Course
        + getRating() double
    }
    
    class Enrollment {
        - enrollmentId : int
        - enrollmentDate : LocalDate
        - completionDate : LocalDate
        - progress : double
        - certificateIssued : boolean
        + Enrollment(enrollmentId : int, enrollmentDate : LocalDate)
        + getProgress() double
        + isCompleted() boolean
        + issueCertificate() void
    }
    
    LearningPlatform --> "*" Course : courses
    LearningPlatform --> "*" Instructor : instructors
    LearningPlatform --> "*" Student : students
    Course --> "1" Instructor : instructor
    Course --> "*" Lesson : lessons
    VideoLesson --|> Lesson
    QuizLesson --|> Lesson
    ReadingLesson --|> Lesson
    Student --> "*" Enrollment : enrollments
    Enrollment --> "1" Course : course
```

## Notes:
- Difficulty levels: "Beginner", "Intermediate", "Advanced", "Expert"
- Reading time estimated at 200 words per minute
- Course is considered popular if enrollment count > 100
- Certificate issued when progress reaches 100%
- Progress = (completed lessons / total lessons) * 100
- Courses with completion rate > 80% are highly rated
- Use `java.time.LocalDate` for dates

