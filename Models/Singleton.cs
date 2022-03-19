using System;
using System.Collections.Generic;

namespace PainAssessment.Models
{
    public class Singleton
    {
        private static Singleton _account;
        private Dictionary<string, Singleton> _accounts = new Dictionary<string, Singleton>();

        private Singleton() { }

        private static object syncLock = new object();

        public static Singleton Instance
        {
            get
            {
                if( _account == null)
                {
                    lock (syncLock)
                    { 
                        _account = new Singleton();
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

    //public Singleton this[string singleton]
    //{
    //    get { return _accounts[singleton]; }
    //    set { _accounts[singleton] = value; }
    //}
}
