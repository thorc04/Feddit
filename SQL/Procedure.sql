use Feddit
Go


CREATE OR ALTER PROCEDURE CreateUser
    @Username NVARCHAR(255),
    @Password NVARCHAR(255),
    @Email NVARCHAR(255),
    @RegistrationDate DATETIME,
    @ProfilePicture NVARCHAR(255)
AS
BEGIN
    INSERT INTO Users (Username, Password, Email, RegistrationDate, ProfilePicture)
    VALUES (@Username, @Password, @Email, @RegistrationDate, @ProfilePicture);
END
GO


CREATE OR ALTER PROCEDURE CreatePost
    @UserID INT,
    @Title NVARCHAR(255),
    @Content NVARCHAR(MAX),
    @Timestamp DATETIME,
    @Upvotes INT,
    @Downvotes INT
AS
BEGIN
    INSERT INTO Posts (UserID, Title, Content, Timestamp, Upvotes, Downvotes)
    VALUES (@UserID, @Title, @Content, @Timestamp, @Upvotes, @Downvotes);
END
GO


CREATE OR ALTER PROCEDURE CreatePost
    @UserID INT,
    @Title NVARCHAR(255),
    @Content NVARCHAR(MAX),
    @Timestamp DATETIME,
    @Upvotes INT,
    @Downvotes INT
AS
BEGIN
    INSERT INTO Posts (UserID, Title, Content, Timestamp, Upvotes, Downvotes)
    VALUES (@UserID, @Title, @Content, @Timestamp, @Upvotes, @Downvotes);
END
GO


CREATE OR ALTER PROCEDURE CreateComment
    @PostID INT,
    @UserID INT,
    @Content NVARCHAR(MAX),
    @Timestamp DATETIME,
    @Upvotes INT,
    @Downvotes INT
AS
BEGIN
    INSERT INTO Comments (PostID, UserID, Content, Timestamp, Upvotes, Downvotes)
    VALUES (@PostID, @UserID, @Content, @Timestamp, @Upvotes, @Downvotes);
END
GO


CREATE OR ALTER PROCEDURE CreateVote
    @UserID INT,
    @PostID INT,
    @CommentID INT,
    @VoteType INT
AS
BEGIN
    INSERT INTO Votes (UserID, PostID, CommentID, VoteType)
    VALUES (@UserID, @PostID, @CommentID, @VoteType);
END
GO


CREATE OR ALTER PROCEDURE CreateSubreddit
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Subreddits (Name, Description)
    VALUES (@Name, @Description);
END
GO


CREATE OR ALTER PROCEDURE CreateSubscription
    @UserID INT,
    @SubredditID INT,
    @SubscriptionDate DATETIME
AS
BEGIN
    INSERT INTO Subscriptions (UserID, SubredditID, SubscriptionDate)
    VALUES (@UserID, @SubredditID, @SubscriptionDate);
END
GO


CREATE OR ALTER PROCEDURE CreateMessage
    @SenderID INT,
    @ReceiverID INT,
    @Content NVARCHAR(MAX),
    @Timestamp DATETIME,
    @IsRead BIT
AS
BEGIN
    INSERT INTO Messages (SenderID, ReceiverID, Content, Timestamp, IsRead)
    VALUES (@SenderID, @ReceiverID, @Content, @Timestamp, @IsRead);
END
GO


CREATE OR ALTER PROCEDURE CreateNotification
    @UserID INT,
    @Content NVARCHAR(MAX),
    @Timestamp DATETIME,
    @IsRead BIT,
    @NotificationType NVARCHAR(255)
AS
BEGIN
    INSERT INTO Notifications (UserID, Content, Timestamp, IsRead, NotificationType)
    VALUES (@UserID, @Content, @Timestamp, @IsRead, @NotificationType);
END
GO

CREATE OR ALTER PROCEDURE DeletePost
    @PostID INT
AS
BEGIN
    DELETE FROM Posts
    WHERE PostID = @PostID;
END
GO

CREATE OR ALTER PROCEDURE DeleteComment
    @CommentID INT
AS
BEGIN
    DELETE FROM Comments
    WHERE CommentID = @CommentID;
END
GO

CREATE OR ALTER PROCEDURE EditUser
    @UserID INT,
    @Username NVARCHAR(255),
    @Password NVARCHAR(255),
    @Email NVARCHAR(255),
    @ProfilePicture NVARCHAR(255)
AS
BEGIN
    UPDATE Users
    SET Username = @Username, Password = @Password, Email = @Email, ProfilePicture = @ProfilePicture
    WHERE UserID = @UserID;
END
GO

CREATE OR ALTER PROCEDURE EditPost
    @PostID INT,
    @Title NVARCHAR(255),
    @Content NVARCHAR(MAX)
AS
BEGIN
    UPDATE Posts
    SET Title = @Title, Content = @Content
    WHERE PostID = @PostID;
END
GO



