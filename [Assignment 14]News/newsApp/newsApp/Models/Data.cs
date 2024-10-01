/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newsApp.Models
{
    public partial class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Preferences { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Last_Login { get; set; }
    }

    public partial class News
    {
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int CategoryID { get; set; }
        public string Author { get; set; }
        public string Image_URL { get; set; }
        public string Language { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int SourceID { get; set; }
        public string Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual RSS Source { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> LikesCollection { get; set; }
        public virtual ICollection<View> ViewsCollection { get; set; }
    }

    public partial class RSS
    {
        public int SourceID { get; set; }
        public string SourceName { get; set; }
        public string URL { get; set; }
        public int Fetch_Interval { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string Status { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }

        public virtual ICollection<News> News { get; set; }
    }

    public partial class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        public virtual ICollection<News> News { get; set; }
    }

    public partial class Comment
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public int NewsID { get; set; }
        public string Content { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Likes { get; set; }
        public string Status { get; set; }

        public virtual User User { get; set; }
        public virtual News News { get; set; }
    }

    public partial class Like
    {
        public int LikeID { get; set; }
        public int UserID { get; set; }
        public int NewsID { get; set; }
        public DateTime Liked_At { get; set; }

        public virtual User User { get; set; }
        public virtual News News { get; set; }
    }

    public partial class View
    {
        public int ViewID { get; set; }
        public int UserID { get; set; }
        public int NewsID { get; set; }
        public DateTime Viewed_At { get; set; }
        public string IP_Address { get; set; }

        public virtual User User { get; set; }
        public virtual News News { get; set; }
    }

    public partial class Notification
    {
        public int NotificationID { get; set; }
        public int UserID { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public bool Is_Read { get; set; }
        public DateTime Created_At { get; set; }

        public virtual User User { get; set; }
    }
}*/