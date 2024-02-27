using LogisticManagement.Entity;

namespace LogisticManagement.Data.Abstract
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        IEnumerable<Message> GetAll();
        Message GetById(int id);
        void Insert(Message message);
        void Update(Message message);
        void Delete(int id);
        void Save();
    }
}
