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
            // Seed Instructors
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
                var instructor = await context.Users.OfType<Instructor>().FirstOrDefaultAsync();
                var category = await context.CourseCategories.FirstOrDefaultAsync();

                var courses = new List<Course>
            {
                new Course { Title = "Intro to C#", Description = "Beginner friendly C# course", ThumbnailUrl = "csharp.png", InstructorId = instructor.Id, CategoryId = category.Id, Price = 49.99M, IsFeatured = true, IsPublished = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, EnrollmentCount = 0, Rating = 4.5, Language = "English" },
                new Course { Title = "HTML & CSS", Description = "Build beautiful websites", ThumbnailUrl = "htmlcss.png", InstructorId = instructor.Id, CategoryId = category.Id, Price = 39.99M, IsFeatured = false, IsPublished = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, EnrollmentCount = 0, Rating = 4.3, Language = "Arabic" },
                new Course { Title = "Python for AI", Description = "AI with Python", ThumbnailUrl = "pythonai.png", InstructorId = instructor.Id, CategoryId = category.Id, Price = 59.99M, IsFeatured = true, IsPublished = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, EnrollmentCount = 0, Rating = 4.7, Language = "English" },
                new Course { Title = "Digital Marketing", Description = "Boost your brand", ThumbnailUrl = "marketing.png", InstructorId = instructor.Id, CategoryId = category.Id, Price = 44.99M, IsFeatured = false, IsPublished = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, EnrollmentCount = 0, Rating = 4.1, Language = "Arabic" },
                new Course { Title = "Flutter Basics", Description = "Mobile apps made easy", ThumbnailUrl = "flutter.png", InstructorId = instructor.Id, CategoryId = category.Id, Price = 55.00M, IsFeatured = true, IsPublished = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, EnrollmentCount = 0, Rating = 4.6, Language = "English" }
            };

                context.Courses.AddRange(courses);
                await context.SaveChangesAsync();
            }
        }
    }

}
