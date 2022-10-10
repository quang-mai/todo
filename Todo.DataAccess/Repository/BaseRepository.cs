namespace Todo.DataAccess.Repository
{
    public class BaseRepository
    {
        protected readonly TodoContext _context;

        public BaseRepository (TodoContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}