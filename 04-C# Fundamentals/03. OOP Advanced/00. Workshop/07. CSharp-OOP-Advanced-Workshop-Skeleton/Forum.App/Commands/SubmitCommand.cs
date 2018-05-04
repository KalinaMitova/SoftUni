namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public SubmitCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;

            int postId = int.Parse(args[0]);
            string replyContents = args[1];

            this.postService.AddReplyToPost(postId, replyContents, userId);

            this.session.Back();
            this.session.Back();
            ICommand viewPostCommand = this.commandFactory.CreateCommand("ViewPostMenu");

            return viewPostCommand.Execute(postId.ToString());
        }
    }
}
