using LMS.Models.Auth;
using LMS.Models.Context;
using LMS.Models.Courses;
using LMS.Models.Enums;
using LMS.Models.Interaction;
using LMS.Models.Social;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.Config
{
    public static class ApplicationDbSeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            if (!context.Users.OfType<Instructor>().Any())
            {
                var instructors = new List<Instructor>
            {
                new Instructor { UserName = "inst1", Email = "inst1@example.com", FirstName = "Ali", LastName = "Mohamed", Specialization = "AI", Skills = "C#, Python", Experience = "5 years", Rating = 4.5, Bio = "Experienced AI Instructor" },
                new Instructor { UserName = "inst2", Email = "inst2@example.com", FirstName = "Sara", LastName = "Hassan", Specialization = "Web Dev", Skills = "HTML, CSS, JS", Experience = "3 years", Rating = 4.2, Bio = "Passionate Web Development Teacher" },
                new Instructor { UserName = "inst3", Email = "inst3@example.com", FirstName = "Omar", LastName = "Gamal", Specialization = "Data Science", Skills = "SQL, Python", Experience = "4 years", Rating = 4.7, Bio = "Data Science Expert" },
                new Instructor { UserName = "inst4", Email = "inst4@example.com", FirstName = "Nada", LastName = "Ibrahim", Specialization = "Cloud", Skills = "Azure, AWS", Experience = "2 years", Rating = 4.1, Bio = "Cloud Computing Specialist" },
                new Instructor { UserName = "inst5", Email = "inst5@example.com", FirstName = "Mostafa", LastName = "Ali", Specialization = "Mobile Dev", Skills = "Flutter, Kotlin", Experience = "3 years", Rating = 4.3, Bio = "Mobile App Development Mentor" }
            };

                foreach (var instructor in instructors)
                {
                    await userManager.CreateAsync(instructor, "P@ssw0rd!");
                }
            }

            // Seed Students
            if (!context.Users.OfType<Student>().Any())
            {
                var students = new List<Student>
            {
                new Student { UserName = "stud1", Email = "stud1@example.com", FirstName = "Khaled", LastName = "Adel", EducationLevel = "Undergraduate" },
                new Student { UserName = "stud2", Email = "stud2@example.com", FirstName = "Marwa", LastName = "Samy", EducationLevel = "Postgraduate" },
                new Student { UserName = "stud3", Email = "stud3@example.com", FirstName = "Yousef", LastName = "Ibrahim", EducationLevel = "Undergraduate" },
                new Student { UserName = "stud4", Email = "stud4@example.com", FirstName = "Hana", LastName = "Ali", EducationLevel = "High School" },
                new Student { UserName = "stud5", Email = "stud5@example.com", FirstName = "Ahmed", LastName = "Osama", EducationLevel = "Postgraduate" }
            };

                foreach (var student in students)
                {
                    await userManager.CreateAsync(student, "P@ssw0rd!");
                }
            }

            // Seed Admin
            if (!context.Users.OfType<Admin>().Any())
            {
                var admin = new Admin
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    FirstName = "Super",
                    LastName = "Admin",
                    Bio = "Administrator with full privileges"
                };
                await userManager.CreateAsync(admin, "Admin123!");
            }

            // Seed Categories
            if (!context.CourseCategories.Any())
            {
                var categories = new List<CourseCategory>
            {
                new CourseCategory { Name = "Programming", Description = "All about coding", IconUrl = "prog-icon.png" },
                new CourseCategory { Name = "Design", Description = "UI/UX, Graphic Design", IconUrl = "design-icon.png" },
                new CourseCategory { Name = "Business", Description = "Marketing & Management", IconUrl = "biz-icon.png" },
                new CourseCategory { Name = "AI", Description = "Artificial Intelligence & ML", IconUrl = "ai-icon.png" },
                new CourseCategory { Name = "Languages", Description = "Learn different languages", IconUrl = "lang-icon.png" }
            };
                context.CourseCategories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            // Seed Courses
            if (!context.Courses.Any())
            {
                var instructors = await context.Users.OfType<Instructor>().ToListAsync();
                var categories = await context.CourseCategories.ToListAsync();

                var courses = new List<Course>
            {
                new Course {
                    Title = "Intro to C#",
                    Description = "Beginner friendly C# course",
                    ThumbnailUrl = "csharp.png",
                    InstructorId = instructors[0].Id,
                    CategoryId = categories[0].Id,
                    Price = 49.99M,
                    IsFeatured = true,
                    IsPublished = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EnrollmentCount = 0,
                    Rating = 4.5,
                    Level = CourseLevels.junior,
                    Language = "English"
                },
                new Course {
                    Title = "HTML & CSS",
                    Description = "Build beautiful websites",
                    ThumbnailUrl = "htmlcss.png",
                    InstructorId = instructors[1].Id,
                    CategoryId = categories[1].Id,
                    Price = 39.99M,
                    IsFeatured = false,
                    IsPublished = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EnrollmentCount = 0,
                    Rating = 4.3,
                    Level = CourseLevels.junior,
                    Language = "Arabic"
                },
                new Course {
                    Title = "Python for AI",
                    Description = "AI with Python",
                    ThumbnailUrl = "pythonai.png",
                    InstructorId = instructors[2].Id,
                    CategoryId = categories[3].Id,
                    Price = 59.99M,
                    IsFeatured = true,
                    IsPublished = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EnrollmentCount = 0,
                    Rating = 4.7,
                    Level = CourseLevels.intermediate,
                    Language = "English"
                },
                new Course {
                    Title = "Digital Marketing",
                    Description = "Boost your brand",
                    ThumbnailUrl = "marketing.png",
                    InstructorId = instructors[1].Id,
                    CategoryId = categories[2].Id,
                    Price = 44.99M,
                    IsFeatured = false,
                    IsPublished = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EnrollmentCount = 0,
                    Rating = 4.1,
                    Level = CourseLevels.junior,
                    Language = "Arabic"
                },
                new Course {
                    Title = "Flutter Basics",
                    Description = "Mobile apps made easy",
                    ThumbnailUrl = "flutter.png",
                    InstructorId = instructors[4].Id,
                    CategoryId = categories[0].Id,
                    Price = 55.00M,
                    IsFeatured = true,
                    IsPublished = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EnrollmentCount = 0,
                    Rating = 4.6,
                    Level = CourseLevels.intermediate,
                    Language = "English"
                }
            };

                context.Courses.AddRange(courses);
                await context.SaveChangesAsync();
            }

            // Seed Modules
            if (!context.Set<Modules>().Any())
            {
                var courses = await context.Courses.ToListAsync();

                var modules = new List<Modules>();

                foreach (var course in courses)
                {
                    // Add 3 modules for each course
                    modules.Add(new Modules
                    {
                        CourseId = course.Id,
                        Title = $"Introduction to {course.Title}",
                        Description = $"Basic introduction to {course.Title}",
                        Order = 1
                    });

                    modules.Add(new Modules
                    {
                        CourseId = course.Id,
                        Title = $"Core Concepts of {course.Title}",
                        Description = $"Main concepts and principles of {course.Title}",
                        Order = 2
                    });

                    modules.Add(new Modules
                    {
                        CourseId = course.Id,
                        Title = $"Advanced {course.Title}",
                        Description = $"Advanced topics in {course.Title}",
                        Order = 3
                    });
                }

                context.Set<Modules>().AddRange(modules);
                await context.SaveChangesAsync();
            }

            // Seed Lessons
            if (!context.Set<Lesson>().Any())
            {
                var modules = await context.Set<Modules>().ToListAsync();

                var lessons = new List<Lesson>();

                foreach (var module in modules)
                {
                    // Add 2-3 lessons for each module
                    lessons.Add(new Lesson
                    {
                        ModuleId = module.Id,
                        Title = $"Lesson 1: Getting Started with {module.Title}",
                        Content = $"Introduction content for {module.Title}",
                        VideoUrl = "https://example.com/videos/lesson1.mp4",
                        Order = 1,
                        Duration = TimeSpan.FromMinutes(15)
                    });

                    lessons.Add(new Lesson
                    {
                        ModuleId = module.Id,
                        Title = $"Lesson 2: Exploring {module.Title}",
                        Content = $"Detailed exploration of {module.Title}",
                        VideoUrl = "https://example.com/videos/lesson2.mp4",
                        Order = 2,
                        Duration = TimeSpan.FromMinutes(20)
                    });

                    if (module.Order > 1)
                    {
                        lessons.Add(new Lesson
                        {
                            ModuleId = module.Id,
                            Title = $"Lesson 3: Mastering {module.Title}",
                            Content = $"Advanced concepts of {module.Title}",
                            VideoUrl = "https://example.com/videos/lesson3.mp4",
                            Order = 3,
                            Duration = TimeSpan.FromMinutes(25)
                        });
                    }
                }

                context.Set<Lesson>().AddRange(lessons);
                await context.SaveChangesAsync();
            }

            // Seed Quizzes
            if (!context.Set<Quiz>().Any())
            {
                var modules = await context.Set<Modules>().ToListAsync();

                var quizzes = new List<Quiz>();

                foreach (var module in modules)
                {
                    quizzes.Add(new Quiz
                    {
                        ModuleId = module.Id,
                        Title = $"Quiz for {module.Title}",
                        Description = $"Test your knowledge of {module.Title}",
                        TimeLimit = 15,
                        PassingScore = 70,
                        IsActive = true
                    });
                }

                context.Set<Quiz>().AddRange(quizzes);
                await context.SaveChangesAsync();
            }

            // Seed Questions and Answers
            if (!context.Set<Question>().Any())
            {
                var quizzes = await context.Set<Quiz>().ToListAsync();

                foreach (var quiz in quizzes)
                {
                    // Add 3 questions per quiz
                    var question1 = new Question
                    {
                        QuizId = quiz.Id,
                        QuestionText = $"What is the main concept of {quiz.Title}?",
                        QuestionType = "MultipleChoice",
                        Points = 10
                    };

                    var question2 = new Question
                    {
                        QuizId = quiz.Id,
                        QuestionText = $"Explain the importance of {quiz.Title}.",
                        QuestionType = "Essay",
                        Points = 15
                    };

                    var question3 = new Question
                    {
                        QuizId = quiz.Id,
                        QuestionText = $"Which statement is true about {quiz.Title}?",
                        QuestionType = "MultipleChoice",
                        Points = 10
                    };

                    context.Set<Question>().Add(question1);
                    context.Set<Question>().Add(question2);
                    context.Set<Question>().Add(question3);
                    await context.SaveChangesAsync();

                    // Add answers to multiple choice questions
                    var answers1 = new List<Answer>
                {
                    new Answer { QuestionId = question1.Id, AnswerText = "Option A", IsCorrect = true },
                    new Answer { QuestionId = question1.Id, AnswerText = "Option B", IsCorrect = false },
                    new Answer { QuestionId = question1.Id, AnswerText = "Option C", IsCorrect = false },
                    new Answer { QuestionId = question1.Id, AnswerText = "Option D", IsCorrect = false }
                };

                    var answers3 = new List<Answer>
                {
                    new Answer { QuestionId = question3.Id, AnswerText = "Statement A", IsCorrect = false },
                    new Answer { QuestionId = question3.Id, AnswerText = "Statement B", IsCorrect = true },
                    new Answer { QuestionId = question3.Id, AnswerText = "Statement C", IsCorrect = false },
                    new Answer { QuestionId = question3.Id, AnswerText = "Statement D", IsCorrect = false }
                };

                    context.Set<Answer>().AddRange(answers1);
                    context.Set<Answer>().AddRange(answers3);
                }

                await context.SaveChangesAsync();
            }

            // Seed Assignments
            if (!context.Set<Assignment>().Any())
            {
                var courses = await context.Courses.ToListAsync();

                var assignments = new List<Assignment>();

                foreach (var course in courses)
                {
                    assignments.Add(new Assignment
                    {
                        CourseId = course.Id,
                        Title = $"Midterm Assignment for {course.Title}",
                        Description = $"Complete this midterm assignment for {course.Title}",
                        MaxScore = 100,
                        AttachmentUrl = "https://example.com/assignments/midterm.pdf"
                    });

                    assignments.Add(new Assignment
                    {
                        CourseId = course.Id,
                        Title = $"Final Project for {course.Title}",
                        Description = $"Complete this final project for {course.Title}",
                        MaxScore = 150,
                        AttachmentUrl = "https://example.com/assignments/final.pdf"
                    });
                }

                context.Set<Assignment>().AddRange(assignments);
                await context.SaveChangesAsync();
            }

            // Seed Enrollments
            if (!context.Enrollments.Any())
            {
                var students = await context.Users.OfType<Student>().ToListAsync();
                var courses = await context.Courses.ToListAsync();

                var enrollments = new List<Enrollment>();

                // Enroll each student in 2 courses
                for (int i = 0; i < students.Count; i++)
                {
                    enrollments.Add(new Enrollment
                    {
                        StudentId = students[i].Id,
                        CourseId = courses[i % courses.Count].Id,
                        IsCompleted = false,
                        ProgressPercentage = 0.0
                    });

                    enrollments.Add(new Enrollment
                    {
                        StudentId = students[i].Id,
                        CourseId = courses[(i + 1) % courses.Count].Id,
                        IsCompleted = false,
                        ProgressPercentage = 0.0
                    });
                }

                context.Enrollments.AddRange(enrollments);
                await context.SaveChangesAsync();
            }

            // Seed Progress Records
            if (!context.Set<Progress>().Any())
            {
                var enrollments = await context.Enrollments.ToListAsync();
                var lessons = await context.Set<Lesson>().Include(l => l.Module).ToListAsync();

                var progressRecords = new List<Progress>();

                foreach (var enrollment in enrollments)
                {
                    // Get lessons for the enrolled course
                    var courseLessons = lessons.Where(l => l.Module.CourseId == enrollment.CourseId).ToList();

                    if (courseLessons.Any())
                    {
                        // Add progress for first lesson
                        progressRecords.Add(new Progress
                        {
                            StudentId = enrollment.StudentId,
                            EnrollmentId = enrollment.Id,
                            LessonId = courseLessons.First().Id,
                            IsCompleted = true
                        });

                        // If there's more than one lesson, add progress for second lesson
                        if (courseLessons.Count > 1)
                        {
                            progressRecords.Add(new Progress
                            {
                                StudentId = enrollment.StudentId,
                                EnrollmentId = enrollment.Id,
                                LessonId = courseLessons[1].Id,
                                IsCompleted = courseLessons[1].Order == 1
                            });
                        }
                    }
                }

                context.Set<Progress>().AddRange(progressRecords);
                await context.SaveChangesAsync();

                // Update enrollment progress percentages
                foreach (var enrollment in enrollments)
                {
                    var courseLessons = lessons.Where(l => l.Module.CourseId == enrollment.CourseId).ToList();
                    var completedLessons = progressRecords
                        .Where(p => p.EnrollmentId == enrollment.Id && p.IsCompleted)
                        .Count();

                    if (courseLessons.Any())
                    {
                        enrollment.ProgressPercentage = (double)completedLessons / courseLessons.Count * 100;
                    }
                }

                await context.SaveChangesAsync();
            }

            // Seed Discussions
            if (!context.Set<Discussion>().Any())
            {
                var courses = await context.Courses.ToListAsync();
                var users = await context.Users.ToListAsync();

                var discussions = new List<Discussion>();

                for (int i = 0; i < courses.Count; i++)
                {
                    discussions.Add(new Discussion
                    {
                        CourseId = courses[i].Id,
                        UserId = users[i % users.Count].Id,
                        Title = $"Question about {courses[i].Title}",
                        Content = $"I have a question regarding the concepts covered in {courses[i].Title}. Can someone please explain?"
                    });

                    discussions.Add(new Discussion
                    {
                        CourseId = courses[i].Id,
                        UserId = users[(i + 1) % users.Count].Id,
                        Title = $"Feedback on {courses[i].Title}",
                        Content = $"I'd like to share my feedback on {courses[i].Title} and suggestions for improvement."
                    });
                }

                context.Set<Discussion>().AddRange(discussions);
                await context.SaveChangesAsync();
            }

            // Seed Comments
            if (!context.Set<Comment>().Any())
            {
                var discussions = await context.Set<Discussion>().ToListAsync();
                var users = await context.Users.ToListAsync();

                var comments = new List<Comment>();

                foreach (var discussion in discussions)
                {
                    comments.Add(new Comment
                    {
                        DiscussionId = discussion.Id,
                        UserId = users.FirstOrDefault(u => u.Id != discussion.UserId).Id,
                        Content = "Thank you for sharing this. I found it very helpful."
                    });

                    comments.Add(new Comment
                    {
                        DiscussionId = discussion.Id,
                        UserId = users.LastOrDefault(u => u.Id != discussion.UserId).Id,
                        Content = "I have a similar question/opinion. Looking forward to more insights."
                    });
                }

                context.Set<Comment>().AddRange(comments);
                await context.SaveChangesAsync();
            }

            // Seed Resources
            if (!context.Set<Resource>().Any())
            {
                var courses = await context.Courses.ToListAsync();

                var resources = new List<Resource>();

                foreach (var course in courses)
                {
                    resources.Add(new Resource
                    {
                        CourseId = course.Id,
                        Title = $"Additional Reading for {course.Title}",
                        Description = $"Supplementary materials for {course.Title}",
                        ResourceType = "PDF",
                        ResourceUrl = "https://example.com/resources/reading.pdf"
                    });

                    resources.Add(new Resource
                    {
                        CourseId = course.Id,
                        Title = $"Practice Exercises for {course.Title}",
                        Description = $"Practice exercises to reinforce concepts in {course.Title}",
                        ResourceType = "ZIP",
                        ResourceUrl = "https://example.com/resources/exercises.zip"
                    });
                }

                context.Set<Resource>().AddRange(resources);
                await context.SaveChangesAsync();
            }

            // Seed Attachments
            if (!context.Set<Attachment>().Any())
            {
                var lessons = await context.Set<Lesson>().ToListAsync();

                var attachments = new List<Attachment>();

                foreach (var lesson in lessons)
                {
                    attachments.Add(new Attachment
                    {
                        LessonId = lesson.Id,
                        FileName = $"slides_{lesson.Title.Replace(" ", "_").ToLower()}.pptx",
                        FilePath = $"/attachments/slides_{lesson.Id}.pptx",
                        FileType = "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                        FileSize = 2048000 // ~2MB 
                    });

                    attachments.Add(new Attachment
                    {
                        LessonId = lesson.Id,
                        FileName = $"notes_{lesson.Title.Replace(" ", "_").ToLower()}.pdf",
                        FilePath = $"/attachments/notes_{lesson.Id}.pdf",
                        FileType = "application/pdf",
                        FileSize = 1024000 // ~1MB 
                    });
                }

                context.Set<Attachment>().AddRange(attachments);
                await context.SaveChangesAsync();
            }

            // Seed Submissions
            if (!context.Set<Submission>().Any())
            {
                var assignments = await context.Set<Assignment>().ToListAsync();
                var enrollments = await context.Enrollments.ToListAsync();

                var submissions = new List<Submission>();

                foreach (var assignment in assignments)
                {
                    // Find enrollments for this assignment's course
                    var courseEnrollments = enrollments.Where(e => e.CourseId == assignment.CourseId).ToList();

                    foreach (var enrollment in courseEnrollments)
                    {
                        submissions.Add(new Submission
                        {
                            AssignmentId = assignment.Id,
                            StudentId = enrollment.StudentId,
                            SubmissionText = "Here is my submission for the assignment.",
                            AttachmentUrl = $"/submissions/student_{enrollment.StudentId}_assignment_{assignment.Id}.pdf",
                            Score = null, // Not graded yet 
                            Feedback = "" // حل المشكلة هنا
                        });
                    }
                }

                context.Set<Submission>().AddRange(submissions);
                await context.SaveChangesAsync();
            }


            // Seed Subscriptions
            if (!context.Set<Subscription>().Any())
            {
                var students = await context.Users.OfType<Student>().ToListAsync();

                var subscriptions = new List<Subscription>();

                var subscriptionTypes = new[] { "Basic", "Premium", "Ultimate" };
                var prices = new[] { 9.99M, 19.99M, 29.99M };

                for (int i = 0; i < students.Count; i++)
                {
                    var planIndex = i % subscriptionTypes.Length;

                    subscriptions.Add(new Subscription
                    {
                        StudentId = students[i].Id,
                        SubscriptionPlan = subscriptionTypes[planIndex],
                        Price = prices[planIndex],
                        IsActive = true,
                        AutoRenew = true,
                        PaymentMethod = "Credit Card"
                    });
                }

                context.Set<Subscription>().AddRange(subscriptions);
                await context.SaveChangesAsync();
            }

            // Seed Transactions
            if (!context.Set<Transaction>().Any())
            {
                var students = await context.Users.OfType<Student>().ToListAsync();
                var courses = await context.Courses.ToListAsync();
                var subscriptions = await context.Set<Subscription>().ToListAsync();

                var transactions = new List<Transaction>();

                // Course purchase transactions
                foreach (var student in students)
                {
                    var courseToTransaction = courses.FirstOrDefault(c => !context.Enrollments.Any(e => e.StudentId == student.Id && e.CourseId == c.Id));

                    if (courseToTransaction != null)
                    {
                        transactions.Add(new Transaction
                        {
                            StudentId = student.Id,
                            CourseId = courseToTransaction.Id,
                            Amount = courseToTransaction.Price,
                            Currency = "USD",
                            TransactionType = "Course Purchase",
                            PaymentMethod = "Credit Card",
                            TransactionStatus = "Completed",
                            TransactionReference = Guid.NewGuid().ToString()
                        });
                    }
                }

                // Subscription transactions
                foreach (var subscription in subscriptions)
                {
                    transactions.Add(new Transaction
                    {
                        StudentId = subscription.StudentId,
                        SubscriptionId = subscription.Id,
                        Amount = subscription.Price,
                        Currency = "USD",
                        TransactionType = "Subscription",
                        PaymentMethod = subscription.PaymentMethod,
                        TransactionStatus = "Completed",
                        TransactionReference = Guid.NewGuid().ToString()
                    });
                }

                context.Set<Transaction>().AddRange(transactions);
                await context.SaveChangesAsync();
            }

            // Seed Payments
            if (!context.Set<Payment>().Any())
            {
                var transactions = await context.Set<Transaction>().ToListAsync();

                var payments = new List<Payment>();

                var paymentGateways = new[] { "Stripe", "PayPal", "Fawry" };

                for (int i = 0; i < transactions.Count; i++)
                {
                    payments.Add(new Payment
                    {
                        TransactionId = transactions[i].Id,
                        PaymentGateway = paymentGateways[i % paymentGateways.Length],
                        PaymentId = $"PAY-{Guid.NewGuid().ToString().Substring(0, 8)}",
                        Amount = transactions[i].Amount,
                        Currency = transactions[i].Currency,
                        PaymentStatus = "Approved"
                    });
                }

                context.Set<Payment>().AddRange(payments);
                await context.SaveChangesAsync();
            }

            // Seed Notifications
            if (!context.Set<Notification>().Any())
            {
                var users = await context.Users.ToListAsync();

                var notifications = new List<Notification>();

                foreach (var user in users)
                {
                    notifications.Add(new Notification
                    {
                        UserId = user.Id,
                        Title = "Welcome to the platform",
                        Message = "Thank you for joining our e-learning platform!",
                        IsRead = false,
                        NotificationType = "Welcome",
                        ReferenceId = "0"  // أو "" إذا كان النوع string
                    });

                    if (user is Student)
                    {
                        notifications.Add(new Notification
                        {
                            UserId = user.Id,
                            Title = "New courses available",
                            Message = "Check out our newly added courses that match your interests.",
                            IsRead = false,
                            NotificationType = "Course",
                            ReferenceId = "0"  // أو "" إذا كان النوع string
                        });
                    }
                    else if (user is Instructor)
                    {
                        notifications.Add(new Notification
                        {
                            UserId = user.Id,
                            Title = "New student enrollments",
                            Message = "You have new students enrolled in your courses.",
                            IsRead = false,
                            NotificationType = "Enrollment",
                            ReferenceId = "0"  // أو "" إذا كان النوع string
                        });
                    }
                }

                context.Set<Notification>().AddRange(notifications);
                await context.SaveChangesAsync();
            }


            // Seed Messages
            if (!context.Set<Message>().Any())
            {
                var instructors = await context.Users.OfType<Instructor>().ToListAsync();
                var students = await context.Users.OfType<Student>().ToListAsync();

                var messages = new List<Message>();

                for (int i = 0; i < students.Count; i++)
                {
                    var instructor = instructors[i % instructors.Count];

                    messages.Add(new Message
                    {
                        SenderId = students[i].Id,
                        ReceiverId = instructor.Id,
                        Content = "Hello, I have a question about the course.",
                        IsRead = false
                    });

                    messages.Add(new Message
                    {
                        SenderId = instructor.Id,
                        ReceiverId = students[i].Id,
                        Content = "Sure, I'd be happy to help. What's your question?",
                        IsRead = true
                    });
                }

                context.Set<Message>().AddRange(messages);
                await context.SaveChangesAsync();
            }
        }
    }

}
