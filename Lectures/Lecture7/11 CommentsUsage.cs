using Lecture7.ClassWithComments;

namespace Lecture7.CommentsUsage
{
    class Test
    {
        /// <summary>
        /// 
        /// </summary>
        public void Run ()
        {
            UserRepository repo = new UserRepository();
            User usr = repo.Get(7);
            
        }
    }
}
