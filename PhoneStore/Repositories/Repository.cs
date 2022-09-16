using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Models;

namespace PhoneStore.Repositories
{
    public class Repository : IRepository
    {
        private PhoneContext _context;
        public Repository(PhoneContext context)
        {
            _context = context;
        }
        public void Create(Phone phone)
        {
            phone.Picture = phone.Picture;
            _context.Phones!.Add(phone);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var phone = _context.Phones!.Single(ph => ph.PhoneId == id);
            _context.Phones!.Remove(phone);
            _context.SaveChanges();
        }

        public IEnumerable<Phone> GetPhones()
        {
            return _context.Phones!.Include(ph => ph.Comments);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }
        public string PhoneCategoty(int categoryId)
        {
            return (_context.Categories.First(ph => ph.CategoryId == categoryId) as Category).Name;
        }

        public void Update(int id, Phone phone)
        {
            var phoneEdit = _context.Phones!.SingleOrDefault(ph => ph.PhoneId == id);
            phoneEdit.Name = phone.Name;
            phoneEdit.Series = phone.Series;
            phoneEdit.Picture = phone.Picture;
            phoneEdit.Description = phone.Description;
            phoneEdit.CategoryId = phone.CategoryId;
            _context.SaveChanges();
        }
        public void AddComment(int id, string comment)
        {
            var phone = _context.Phones!.Include(_ => _.Comments).Single(ph => ph.PhoneId == id);
            if (phone != null)
            {
                phone.Comments.Add(new Comment { CommentText = comment });
            }
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var phone = _context.Comments!.Single(ph => ph.CommentId == id);
            _context.Comments!.Remove(phone);
            _context.SaveChanges();
        }
    }
}
