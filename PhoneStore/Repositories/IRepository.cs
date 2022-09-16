using PhoneStore.Models;

namespace PhoneStore.Repositories
{
    public interface IRepository
    {
        void Delete(int id);
        void Update(int id, Phone phone);
        void Create(Phone phone);
        string PhoneCategoty(int cateoryId);
        IEnumerable<Category> GetCategories();
        IEnumerable<Phone> GetPhones();
        void AddComment(int id, string comment);
        void DeleteComment(int id);
    }
}
