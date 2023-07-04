using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class LockedSingleton
    {
        private static LockedSingleton instance;
        private static object locker = new Object();

        private LockedSingleton()
        {

        }

        public static LockedSingleton GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    instance = new LockedSingleton();
                }
            }

            return instance;
        }

    }
}
