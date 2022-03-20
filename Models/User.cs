using System;
using System.Collections.Generic;

namespace PainAssessment.Models
{
    public class User
    {
        private static User _account;
        private Dictionary<string, User> _accounts = new Dictionary<string, User>();

        private User() { }

        private static object syncLock = new object();

        public static User Instance
        {
            get
            {
                if( _account == null)
                {
                    lock (syncLock)
                    { 
                        _account = new User();
                        return _account;
                    }
                }
                else
                {
                    return _account;
                }
            }
        }
     }

    //public User this[string user]
    //{
    //    get { return _accounts[user]; }
    //    set { _accounts[user] = value; }
    //}
}
