using Blog.Domain.Entities;

namespace Blog.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Domain.Contexts.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Domain.Contexts.BlogDbContext context)
        {
            var articlesList = new[]
            {
                new Article
                {
                    Name = "Running PHP on .NET Core with Peachpie",
                    Text = @"This post is about running PHP on .NET Core with Peachpie. Peachpie is an open source PHP Compiler to .NET. This innovative compiler allows you to run existing PHP applications with the performance, speed, security and interoperability of .NET. In ASP.NET Community Standup July 25th, 2017, Jon Galloway announced Peachpie Compiler Platform is now part of .NET Foundation. In this post I am explaining how to run PHP in .NET Core.",
                    PublishDate = DateTime.Now,
                    //Tags = ".Net Core, Asp.Net Mvc, PHP, Azure"
                },
                new Article
                {
                    Name = "Send Mail Using SendGrid In .NET Core",
                    Text = @"This post is about sending emails using Send Grid API in .NET Core. SendGrid is a cloud-based SMTP provider that allows you to send email without having to maintain email servers. SendGrid manages all of the technical details, from scaling the infrastructure to ISP outreach and reputation monitoring to whitelist services and real time analytics.",
                    PublishDate = DateTime.Now,
                    //Tags = ".Net Core, Asp.Net Mvc, SendGrid"
                },
                new Article
                {
                    Name = "ASP.NET Core Gravatar Tag Helper",
                    Text = @"This post is about creating a tag helper in ASP.NET Core for displaying Gravatar images based on the email address. Your Gravatar is an image that follows you from site to site appearing beside your name when you do things like comment or post on a blog. Gravatar images may be requested just like a normal image, using an IMG tag. To get an image specific to a user, you must first calculate their email hash. All URLs on Gravatar are based on the use of the hashed value of an email address. Images and profiles are both accessed via the hash of an email, and it is considered the primary way of identifying an identity within the system. To ensure a consistent and accurate hash, the following steps should be taken to create a hash:",
                    PublishDate = DateTime.Now,
                    //Tags = ".Net Core, Asp.Net Core, Tag Helper, Gravatar"
                },
                new Article
                {
                    Name = "How to Deploy Multiple Apps on Azure WebApps",
                    Text = @"This post is about deploying multiple applications on an Azure Web App. App Service Web Apps is a fully managed compute platform that is optimized for hosting websites and web applications. This platform-as-a-service (PaaS) offering of Microsoft Azure lets you focus on your business logic while Azure takes care of the infrastructure to run and scale your apps. Once you created the Web App, open the portal, select the Web Application, Select Application Settings under Settings from the Web Application. Then scroll down until you reach “Virtual applications and directories” configuration.",
                    PublishDate = DateTime.Now,
                    //Tags = "Azure, Web Apps"
                },
                new Article
                {
                    Name = "Connecting to Azure Cosmos DB emulator from RoboMongo",
                    Text = @"This post is about connecting to Azure Cosmos DB emulator from RoboMongo. Azure Cosmos DB is Microsoft’s globally distributed multi-model database. It is superset of Azure Document DB. Due to some challenges, one of our team decided to try some new No SQL databases. One of the option was Document Db. I found it quite good option, since it supports Mongo protocol so existing app can work without much change. So I decided to explore that. First step I downloaded the Document Db emulator, now it is Azure Cosmos DB emulator. Installed and started the emulator, it is opening the Data Explorer web page (https://localhost:8081/_explorer/index.html), which helps to explore the Documents inside the database. Then I tried to connect to the same with Robo Mongo (It is a free Mongo Db client, can be downloaded from here). But is was not working. I was getting some errors. Later I spent some time to find some similar issues, blog post on how to connect from Robo Mongo to Document Db emulator. But I couldn’t find anything useful. After spenting almost a day, I finally figured out the solution. Here is the steps.",
                    PublishDate = DateTime.Now,
                    //Tags = "Database, MongoDb, Azure, RoboMongo"
                }
            };
            var tags = new[]
            {
                new Tag { Name = "Asp.Net" },
                new Tag { Name = "MVC" },
                new Tag { Name = ".Net Core" },
                new Tag { Name = "WPF" },
                new Tag { Name = "WCF" },
                new Tag { Name = "Web Api" }
            };
            var commentsList = new[]
            {
                new Comment
                {
                    AuthorName = "Tom Hanks",
                    Text = @"Thank you for the best .NET blog",
                    PublishDate = DateTime.Now
                },
                new Comment
                {
                    AuthorName = "John Snow",
                    Text = @"Pls add article about xamarin development",
                    PublishDate = DateTime.Now
                },
                new Comment
                {
                    AuthorName = "Christian",
                    Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed et finibus metus, non lobortis nulla. Suspendisse cursus tristique nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Maecenas faucibus bibendum porttitor. Nullam quam nibh, luctus a ex vel, congue semper diam. Aliquam at magna a eros fermentum tristique eget sit amet lacus. Quisque dapibus neque sodales tortor semper, in scelerisque arcu sodales. Vivamus molestie nibh eget dui sollicitudin posuere. Donec vulputate sit amet libero id volutpat. Praesent eget gravida tortor.",
                    PublishDate = DateTime.Now
                },
                new Comment
                {
                    AuthorName = "Jack Sparrow",
                    Text = @"It's very helpful at my work. Thanks!",
                    PublishDate = DateTime.Now
                },
                new Comment
                {
                    AuthorName = "Anonymous",
                    Text = @"Need more articles!!",
                    PublishDate = DateTime.Now
                }
            };
            var questionaryAnswersList = new[]
            {
                new QuestionaryAnswer()
                {
                    Answer = "Los Angeles",
                    QuestionType = "City",
                    AnsweredCount = 13
                },
                new QuestionaryAnswer()
                {
                    Answer = "Las Vegas",
                    QuestionType = "City",
                    AnsweredCount = 25
                },
                new QuestionaryAnswer()
                {
                    Answer = "New York",
                    QuestionType = "City",
                    AnsweredCount = 2
                },
                new QuestionaryAnswer()
                {
                    Answer = "< 18",
                    QuestionType = "Age range",
                    AnsweredCount = 15
                },
                new QuestionaryAnswer()
                {
                    Answer = "18-45",
                    QuestionType = "Age range",
                    AnsweredCount = 15
                },
                new QuestionaryAnswer()
                {
                    Answer = "46-60",
                    QuestionType = "Age range",
                    AnsweredCount = 10
                },
                new QuestionaryAnswer()
                {
                    Answer = "< 1 year",
                    QuestionType = "How long user reads blog",
                    AnsweredCount = 18
                },
                new QuestionaryAnswer()
                {
                    Answer = "1-2 years",
                    QuestionType = "How long user reads blog",
                    AnsweredCount = 18
                },
                new QuestionaryAnswer()
                {
                    Answer = "3 years <",
                    QuestionType = "How long user reads blog",
                    AnsweredCount = 4
                },
                new QuestionaryAnswer()
                {
                    Answer = "Very expirienced authors",
                    QuestionType = "Interestings in blog",
                    AnsweredCount = 12
                },
                new QuestionaryAnswer()
                {
                    Answer = "Relevant technologies",
                    QuestionType = "Interestings in blog",
                    AnsweredCount = 37
                },
                new QuestionaryAnswer()
                {
                    Answer = "Many code examples",
                    QuestionType = "Interestings in blog",
                    AnsweredCount = 34
                },
                new QuestionaryAnswer()
                {
                    Answer = "Other",
                    QuestionType = "Interestings in blog",
                    AnsweredCount = 23
                },

                // Vote

                new QuestionaryAnswer
                {
                    Answer = "ASP.NET MVC",
                    QuestionType = "Technology for articles",
                    AnsweredCount = 40
                },
                new QuestionaryAnswer
                {
                    Answer = "WCF",
                    QuestionType = "Technology for articles",
                    AnsweredCount = 22
                },
                new QuestionaryAnswer
                {
                    Answer = "WPF",
                    QuestionType = "Technology for articles",
                    AnsweredCount = 19
                },
                new QuestionaryAnswer
                {
                    Answer = "Web Api",
                    QuestionType = "Technology for articles",
                    AnsweredCount = 29
                }
            };
            var users = new[]
            {
                new User { UserName = "admin", PasswordHash = "AMXEkg3ypspYYwYhUBUFhhDf40J6NxywUVY9DT6g8jGrlOZelfTUT8kYjdWVlsmMrw==" }
            };
            var roles = new[]
            {
                new Role { Name = "Admin" }
            };

            #region Addings

            foreach (var article in articlesList)
            {
                context.Articles.Add(article);
            }

            foreach (var comment in commentsList)
            {
                context.Comments.Add(comment);
            }

            foreach (var questionaryAnswer in questionaryAnswersList)
            {
                context.QuestionaryAnswers.Add(questionaryAnswer);
            }

            foreach (var tag in tags)
            {
                context.Tags.Add(tag);
            }

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }

            #endregion

            context.SaveChanges();

            context.UserRoles.Add(new UserRole { UserId = users[0].Id, RoleId = roles[0].Id });

            var articleTags = new[]
            {
                new ArticleTag
                {
                    ArticleId = articlesList[0].Id,
                    TagId = tags[0].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[0].Id,
                    TagId = tags[2].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[0].Id,
                    TagId = tags[5].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[1].Id,
                    TagId = tags[1].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[1].Id,
                    TagId = tags[4].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[2].Id,
                    TagId = tags[4].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[2].Id,
                    TagId = tags[5].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[3].Id,
                    TagId = tags[3].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[4].Id,
                    TagId = tags[0].Id
                },
                new ArticleTag
                {
                    ArticleId = articlesList[4].Id,
                    TagId = tags[1].Id
                },
            };

            foreach (var articleTag in articleTags)
            {
                context.ArticleTags.Add(articleTag);
            }

            context.SaveChanges();
        }
    }
}
