namespace Forum.App.UserInterface.ViewModels
{
    using System.Linq;
    using Forum.Models;
    using System.Collections.Generic;
    using Forum.App.Services;

    public class PostViewModel
    {
        private const int LINE_LENGTH = 37;

        public PostViewModel()
        {
            this.Content = new List<string>();
        }

        public PostViewModel(Post post)
        {
            this.PostId = post.Id;
            this.Title = post.Title;
            this.Content = this.GetLines(post.Content);
            this.Author = UserService.GetUser(post.AuthorId).Username;
            this.Category = PostService.GetCategory(post.CategoryId).Name;
            this.Replies = PostService.GetPostReplies(post.Id);
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }

        private IList<string> GetLines(string content)
        {
            char[] contentChar = content.ToCharArray();

            IList<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i += LINE_LENGTH)
            {
                char[] row = content.Skip(i).Take(LINE_LENGTH).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }
    }
}
