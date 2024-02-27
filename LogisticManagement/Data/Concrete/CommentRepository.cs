using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;

namespace LogisticManagement.Data.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _dataContext;
        public CommentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IQueryable<Comment> Comments => _dataContext.Comments;

        public void CreateComment(Comment comment)
        {
            _dataContext.Comments.Add(comment);
            _dataContext.SaveChanges();
        }
    }
}
