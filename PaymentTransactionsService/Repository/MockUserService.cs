namespace TransactionServiceAPI.Repository
{
    public class MockUserService
    {
        private readonly List<int> _userIds;

        public MockUserService()
        {
            // Initialize with some mock user IDs
            _userIds = new List<int> { 1, 2, 3, 4, 5 };
        }

        public bool UserExists(int userId)
        {
            return _userIds.Contains(userId);
        }

    }
}
