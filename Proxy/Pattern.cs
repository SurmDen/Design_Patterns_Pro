using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    //basic interface for real subject and his proxy
    public interface ISubject
    {
        void Request();
    }

    //real subj
    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("Request is handled by RealSubject");
        }
    }

    //his proxy, that looks like real sublect and can call his functionality
    public class ProxySubject : ISubject
    {
        private RealSubject real;

        public ProxySubject()
        {
            real = new RealSubject();
        }

        public void Request()
        {
            if (real != null)
            {
                real.Request();

                return;
            }

            Console.WriteLine("Request is hundled by proxy");
        }
    }
}
