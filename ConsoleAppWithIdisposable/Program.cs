using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWithIdisposable
{
    class Program
    {
        int PPP;
        static void Main(string[] args)
        {
            DerivedClass b = new DerivedClass();
            b.Dispose();
        }
       
    }
    public class BaseClass : IDisposable
    {
        bool disposed = false;
       
        FileStream file = new FileStream("C:/test.txt", FileMode.Open);  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                file.Dispose();
            }
            disposed = true;
        }
        ~BaseClass()
        {
            Dispose(false);
        }
    }
    public class DerivedClass : BaseClass
    {
        bool disposed = false;
        FileStream file = new FileStream("C:/test1.txt", FileMode.OpenOrCreate);
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                file.Dispose();
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }
}
