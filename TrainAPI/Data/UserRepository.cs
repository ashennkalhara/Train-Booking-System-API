using TrainAPI.Model;

namespace TrainAPI.Data
{
    public class UserRepository
    {
        private AppDBContext _dbContext;

        public UserRepository(AppDBContext context)
        {
            _dbContext = context;
        }

        public bool CreateUser(User user)
        {
            if (user != null)
            {
                _dbContext.users.Add(user);
                return Save();
            }
            else
                return false;
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateUser(User user)
        {
            _dbContext.users.Update(user);
            return Save();
        }

        public bool RemoveUser(User user)
        {
            _dbContext.users.Remove(user);
            return Save();
        }

        public User GetUser(int id)
        {
            return _dbContext.users.FirstOrDefault(user => user.UserId == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.users.ToList();
        }

        public bool IsValidUser(string username, string password)
        {
            return _dbContext.users.Any(user => user.UserName == username && user.Password == password);
        }
    }
}