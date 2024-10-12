namespace Data;

public static class SeedData
{
    public static void Initialize(AppDbContext db)
    {
        var users = new User[]
{
    new User
    {
        Id = 1,
        Username = "admin",
        Password = "admin123",
        Role = "01",
        Status = "1",
        Nickname = "AdminUser",
        Avatar = "https://example.com/avatar1.jpg",
        Mobile = "12345678901",
        Email = "admin@example.com",
        Gender = "M",
        Description = "Administrator account",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        Score = 100,
        PushEmail = "admin@example.com",
        PushSwitch = true,
        Token = "admin"
    },
    new User
    {
        Id = 2,
        Username = "user1",
        Password = "user123",
        Role = "02",
        Status = "1",
        Nickname = "UserOne",
        Avatar = "https://example.com/avatar2.jpg",
        Mobile = "09876543210",
        Email = "user1@example.com",
        Gender = "F",
        Description = "Regular user",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        Score = 50,
        PushEmail = "user1@example.com",
        PushSwitch = false,
        Token = Guid.NewGuid().ToString("N")
    },
    new User
    {
        Id = 3,
        Username = "guest",
        Password = "guest123",
        Role = "03",
        Status = "0",
        Nickname = "GuestUser",
        Avatar = "https://example.com/avatar3.jpg",
        Mobile = "11223344556",
        Email = "guest@example.com",
        Gender = "M",
        Description = "Guest account",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        Score = 10,
        PushEmail = "guest@example.com",
        PushSwitch = false,
        Token = Guid.NewGuid().ToString("N")
        }
    };
        var thingWishes = new ThingWish[]
    {
    new ThingWish
    {
        Id = 1,
        ThingId = 101,
        UserId = 1
    },
    new ThingWish
    {
        Id = 2,
        ThingId = 102,
        UserId = 2
    },
    new ThingWish
    {
        Id = 3,
        ThingId = 103,
        UserId = 3
    }
    };
        var thingTags = new ThingTag[]
    {
    new ThingTag
    {
        Id = 1,
        ThingId = 101,
        TagId = 201
    },
    new ThingTag
    {
        Id = 2,
        ThingId = 102,
        TagId = 202
    },
    new ThingTag
    {
        Id = 3,
        ThingId = 103,
        TagId = 203
    }
    };
        var thingCollects = new ThingCollect[]
        {
    new ThingCollect
    {
        Id = 1,
        ThingId = 101,
        UserId = 1
    },
    new ThingCollect
    {
        Id = 2,
        ThingId = 102,
        UserId = 2
    },
    new ThingCollect
    {
        Id = 3,
        ThingId = 103,
        UserId = 3
    }
        };
        var things = new Thing[]
        {
    new Thing
    {
        Id = 1,
        Title = "Electric Car",
        Cover = "electric_car.jpg",
        Description = "A powerful electric car with a range of 500 km.",
        Price = "25000",
        Status = "1",
        Score = 95,
        Mobile = "1234567890",
        Age = "2 years",
        Location = "New York",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        Pv = 1500,
        RecommendCount = 120,
        WishCount = 80,
        CollectCount = 60,
        ClassificationId = 10,
        UserId = "admin",
        Xuhang = "500km",
        Dongli = "Electric",
        Xianzhi = "No restriction"
    },
    new Thing
    {
        Id = 2,
        Title = "Mountain Bike",
        Cover = "mountain_bike.jpg",
        Description = "A durable mountain bike suitable for tough terrains.",
        Price = "800",
        Status = "1",
        Score = 88,
        Mobile = "0987654321",
        Age = "1 year",
        Location = "California",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        Pv = 800,
        RecommendCount = 60,
        WishCount = 45,
        CollectCount = 30,
        ClassificationId = 5,
        UserId = "user1",
        Xuhang = "N/A",
        Dongli = "Manual",
        Xianzhi = "No restriction"
    },
    new Thing
    {
        Id = 3,
        Title = "Smartphone",
        Cover = "smartphone.jpg",
        Description = "A latest-generation smartphone with advanced features.",
        Price = "999",
        Status = "1",
        Score = 92,
        Mobile = "1122334455",
        Age = "6 months",
        Location = "San Francisco",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        Pv = 2500,
        RecommendCount = 200,
        WishCount = 150,
        CollectCount = 100,
        ClassificationId = 8,
        UserId = "guest",
        Xuhang = "N/A",
        Dongli = "Battery",
        Xianzhi = "No restriction"
    }
        };
        var tags = new Tag[]
        {
    new Tag
    {
        Id = 1,
        Title = "Technology",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    },
    new Tag
    {
        Id = 2,
        Title = "Automobile",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    },
    new Tag
    {
        Id = 3,
        Title = "Environment",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    }
        };
        var orders = new Order[]
        {
    new Order
    {
        Id = 1,
        Status = "01",
        OrderTime = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd HH:mm:ss"),
        PayTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"),
        ThingId = 101,
        UserId = 1,
        Count = 2,
        OrderNumber = "ORD1234567890",
        ReceiverAddress = "123 Main St, New York",
        ReceiverName = "John Doe",
        ReceiverPhone = "1234567890",
        Remark = "Deliver before noon"
    },
    new Order
    {
        Id = 2,
        Status = "02",
        OrderTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"),
        PayTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        ThingId = 102,
        UserId = 2,
        Count = 1,
        OrderNumber = "ORD0987654321",
        ReceiverAddress = "456 Market St, San Francisco",
        ReceiverName = "Jane Smith",
        ReceiverPhone = "0987654321",
        Remark = "Leave at the front door"
    }
        };
        var opLogs = new OpLog[]
        {
    new OpLog
    {
        Id = 1,
        ReIp = "192.168.0.1",
        ReTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        ReUa = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)",
        ReUrl = "/api/endpoint",
        ReMethod = "GET",
        ReContent = "Request content for API endpoint",
        AccessTime = DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss")
    },
    new OpLog
    {
        Id = 2,
        ReIp = "10.0.0.2",
        ReTime = DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd HH:mm:ss"),
        ReUa = "PostmanRuntime/7.28.4",
        ReUrl = "/api/data",
        ReMethod = "POST",
        ReContent = "Data submitted via API",
        AccessTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    }
        };
        var notices = new Notice[]
        {
    new Notice
    {
        Id = 1,
        Title = "System Maintenance",
        Content = "The system will undergo maintenance from 12:00 AM to 4:00 AM.",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    },
    new Notice
    {
        Id = 2,
        Title = "New Feature Release",
        Content = "We are excited to announce the release of a new feature in our application.",
        CreateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")
    },
    new Notice
    {
        Id = 3,
        Title = "Holiday Announcement",
        Content = "Our office will be closed for the holidays from December 24th to January 2nd.",
        CreateTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss")
    }
        };
        var loginLogs = new LoginLog[]
        {
    new LoginLog
    {
        Id = 1,
        Username = "admin",
        Ip = "192.168.0.1",
        Ua = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)",
        LogTime = DateTime.Now
    },
    new LoginLog
    {
        Id = 2,
        Username = "user1",
        Ip = "10.0.0.2",
        Ua = "PostmanRuntime/7.29.0",
        LogTime = DateTime.Now.AddMinutes(-30)
    },
    new LoginLog
    {
        Id = 3,
        Username = "guest",
        Ip = "172.16.0.5",
        Ua = "curl/7.64.1",
        LogTime = DateTime.Now.AddHours(-2)
    }
        };
        var errorLogs = new ErrorLog[]
        {
    new ErrorLog
    {
        Id = 1,
        Ip = "192.168.0.1",
        Url = "/api/data",
        Method = "GET",
        Content = "An unexpected error occurred while fetching data.",
        LogTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    },
    new ErrorLog
    {
        Id = 2,
        Ip = "10.0.0.2",
        Url = "/api/login",
        Method = "POST",
        Content = "User authentication failed due to invalid credentials.",
        LogTime = DateTime.Now.AddMinutes(-15).ToString("yyyy-MM-dd HH:mm:ss")
    },
    new ErrorLog
    {
        Id = 3,
        Ip = "172.16.0.3",
        Url = "/api/upload",
        Method = "PUT",
        Content = "File upload failed due to insufficient storage space.",
        LogTime = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss")
    }
        };
        var comments = new Comment[]
        {
    new Comment
    {
        Id = 1,
        Content = "Great product, highly recommend!",
        CommentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        LikeCount = 25,
        UserId = 1,
        ThingId = 101
    },
    new Comment
    {
        Id = 2,
        Content = "Not satisfied with the quality.",
        CommentTime = DateTime.Now.AddMinutes(-20).ToString("yyyy-MM-dd HH:mm:ss"),
        LikeCount = 3,
        UserId = 2,
        ThingId = 102
    },
    new Comment
    {
        Id = 3,
        Content = "Amazing customer service and fast delivery.",
        CommentTime = DateTime.Now.AddHours(-2).ToString("yyyy-MM-dd HH:mm:ss"),
        LikeCount = 10,
        UserId = 3,
        ThingId = 103
    }
        };
        var classifications = new Classification[]
        {
    new Classification
    {
        Id = 1,
        Title = "Electronics",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    },
    new Classification
    {
        Id = 2,
        Title = "Automobiles",
        CreateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")
    },
    new Classification
    {
        Id = 3,
        Title = "Home Appliances",
        CreateTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss")
    }
        };
        var banners = new Banner[]
        {
    new Banner
    {
        Id = 1,
        Image = "https://example.com/banner1.jpg",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        ThingId = 101
    },
    new Banner
    {
        Id = 2,
        Image = "https://example.com/banner2.jpg",
        CreateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"),
        ThingId = 102
    },
    new Banner
    {
        Id = 3,
        Image = "https://example.com/banner3.jpg",
        CreateTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss"),
        ThingId = 103
    }
        };
        var addresses = new Address[]
        {
    new Address
    {
        Id = 1,
        Name = "John Doe",
        Mobile = "1234567890",
        Description = "Primary residence",
        Def = "Yes",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        UserId = 1
    },
    new Address
    {
        Id = 2,
        Name = "Jane Smith",
        Mobile = "0987654321",
        Description = "Office address",
        Def = "No",
        CreateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"),
        UserId = 2
    },
    new Address
    {
        Id = 3,
        Name = "Emily Brown",
        Mobile = "1122334455",
        Description = "Vacation home",
        Def = "No",
        CreateTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss"),
        UserId = 3
    }
        };
        var ads = new Ad[]
        {
    new Ad
    {
        Id = 1,
        Image = "https://example.com/ad1.jpg",
        Link = "https://example.com/product1",
        CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    },
    new Ad
    {
        Id = 2,
        Image = "https://example.com/ad2.jpg",
        Link = "https://example.com/product2",
        CreateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")
    },
    new Ad
    {
        Id = 3,
        Image = "https://example.com/ad3.jpg",
        Link = "https://example.com/product3",
        CreateTime = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd HH:mm:ss")
    }
        };
        if (!db.Users.Any())
        {
            db.Users.AddRange(users);
            db.SaveChanges();
        }

        if (!db.ThingWishes.Any())
        {
            db.ThingWishes.AddRange(thingWishes);
            db.SaveChanges();
        }

        if (!db.ThingTags.Any())
        {
            db.ThingTags.AddRange(thingTags);
            db.SaveChanges();
        }

        if (!db.ThingCollects.Any())
        {
            db.ThingCollects.AddRange(thingCollects);
            db.SaveChanges();
        }

        if (!db.Things.Any())
        {
            db.Things.AddRange(things);
            db.SaveChanges();
        }

        if (!db.Tags.Any())
        {
            db.Tags.AddRange(tags);
            db.SaveChanges();
        }

        if (!db.Orders.Any())
        {
            db.Orders.AddRange(orders);
            db.SaveChanges();
        }

        if (!db.OpLogs.Any())
        {
            db.OpLogs.AddRange(opLogs);
            db.SaveChanges();
        }

        if (!db.Notices.Any())
        {
            db.Notices.AddRange(notices);
            db.SaveChanges();
        }

        if (!db.LoginLogs.Any())
        {
            db.LoginLogs.AddRange(loginLogs);
            db.SaveChanges();
        }

        if (!db.ErrorLogs.Any())
        {
            db.ErrorLogs.AddRange(errorLogs);
            db.SaveChanges();
        }

        if (!db.Comments.Any())
        {
            db.Comments.AddRange(comments);
            db.SaveChanges();
        }

        if (!db.Classifications.Any())
        {
            db.Classifications.AddRange(classifications);
            db.SaveChanges();
        }

        if (!db.Banners.Any())
        {
            db.Banners.AddRange(banners);
            db.SaveChanges();
        }

        if (!db.Addresses.Any())
        {
            db.Addresses.AddRange(addresses);
            db.SaveChanges();
        }

        if (!db.Ads.Any())
        {
            db.Ads.AddRange(ads);
            db.SaveChanges();
        }

    }
}


