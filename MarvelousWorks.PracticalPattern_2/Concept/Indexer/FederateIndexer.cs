using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Concept.Indexer
{
    public class FederateIndexer
    {
        private static IDictionary<int, User> users = new Dictionary<int, User>();

        static FederateIndexer()
        {
            User user;
            user = new User("joe", 20, Gender.Male);
            users.Add(user.Key, user);
            user = new User("K", 21, Gender.Male);
            users.Add(user.Key, user);
            user = new User("K", 22, Gender.Female); // another 'K'
            users.Add(user.Key, user);
        }

        // ��������������λ��� User ��Ŀ
        public User this[string name, int age] 
        { get { return users[(name + age).GetHashCode()]; } }
    }
}
