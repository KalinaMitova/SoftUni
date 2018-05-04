namespace Forum.App.Services
{
    using System;
    using System.Linq;
    using Forum.App.Services.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;

    public class CategoryController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategory(0);
        }

        public int CurrentPage { get; set; }

        private string[] PostTitles { get; set; }

        private int LastPage => this.PostTitles.Length / (PAGE_OFFSET + 1);

        private bool isFirstPage => this.CurrentPage == 0;

        private bool isLastPage => this.CurrentPage == this.LastPage;

        public int CategoryId { get; private set; }

        private enum Command
        {
            Back = 0,
            ViewPost = 1,
            PreviusPage = 11,
            NextPage = 12
        }

        public void SetCategory(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
            GetPosts();
        }

        private void GetPosts()
        {
            var allCategoryPosts = PostService.GetPostsByCategory(this.CategoryId);

            this.PostTitles = allCategoryPosts
                .Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .Select(p => p.Title)
                .ToArray();
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Back:

                    return MenuState.Back;
                case Command.ViewPost:

                    return MenuState.ViewPost;
                case Command.PreviusPage:
                    this.ChangePage(false);
                    return MenuState.OpenCategory;
                case Command.NextPage:
                    this.ChangePage();
                    return MenuState.OpenCategory;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            GetPosts();
            string categoryName = PostService.GetCategory(this.CategoryId).Name;
            return new CategoryView(categoryName, this.PostTitles, isFirstPage, isLastPage);
        }
    }
}
