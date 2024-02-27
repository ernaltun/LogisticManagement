using LogisticManagement.Data.Abstract;
using LogisticManagement.Data.Concrete.Context;
using LogisticManagement.Entity;

namespace LogisticManagement.Data.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;
        public MessageRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IQueryable<Message> Messages => _context.Messages;

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            var message = _context.Messages.Find(id);
            return message;
        }

        public void Insert(Message message)
        {
            _context.Add(message);
            _context.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
