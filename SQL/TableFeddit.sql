-- Create the Feddit database
CREATE DATABASE Feddit;

-- Use the Feddit database
USE Feddit;

-- Create the User table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    RegistrationDate DATETIME NOT NULL,
    ProfilePicture NVARCHAR(255)
);

-- Create the Post table
CREATE TABLE Posts (
    PostID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX),
    Timestamp DATETIME NOT NULL,
    Upvotes INT NOT NULL,
    Downvotes INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Create the Comment table
CREATE TABLE Comments (
    CommentID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT,
    UserID INT,
    Content NVARCHAR(MAX),
    Timestamp DATETIME NOT NULL,
    Upvotes INT NOT NULL,
    Downvotes INT NOT NULL,
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Create the Vote table
CREATE TABLE Votes (
    VoteID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    PostID INT,
    CommentID INT,
    VoteType INT NOT NULL, -- Use 1 for upvote and -1 for downvote
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (CommentID) REFERENCES Comments(CommentID)
);

-- Create the Subreddit table
CREATE TABLE Subreddits (
    SubredditID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX)
);

-- Create the Subscription table
CREATE TABLE Subscriptions (
    SubscriptionID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    SubredditID INT,
    SubscriptionDate DATETIME NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (SubredditID) REFERENCES Subreddits(SubredditID)
);

-- Create the Message table
CREATE TABLE Messages (
    MessageID INT PRIMARY KEY IDENTITY(1,1),
    SenderID INT,
    ReceiverID INT,
    Content NVARCHAR(MAX) NOT NULL,
    Timestamp DATETIME NOT NULL,
    IsRead BIT NOT NULL,
    FOREIGN KEY (SenderID) REFERENCES Users(UserID),
    FOREIGN KEY (ReceiverID) REFERENCES Users(UserID)
);

-- Create the Notification table
CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    Content NVARCHAR(MAX) NOT NULL,
    Timestamp DATETIME NOT NULL,
    IsRead BIT NOT NULL,
    NotificationType NVARCHAR(255) NOT NULL
);


