using System.Collections;

namespace Repository.Domain.Interface
{
    public interface IUserRepository
    {
        void Add(User p);
        void Edit(User p);
        void Remove(int Id);
        IEnumerable GetUsers(); User FindById(int Id);
    }
}