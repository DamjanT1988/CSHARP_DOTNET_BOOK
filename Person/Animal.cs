using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//205
namespace PacktLibrary
{
    public class Animal : IDisposable
    {
        public Animal()
        {
            // allocate unmanaged resource
        }
        ~Animal() // Finalizer
        {
            if (disposed) return;
            Dispose(false);
        }
        bool disposed = false; // have resources been released?
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            // deallocate the *unmanaged* resource
            // ...
            if (disposing)
            {
                // deallocate any other *managed* resources
                // ...
            }
            disposed = true;
        }

        /*
        • The public Dispose method will be called by a developer using your type.
        When called, both unmanaged and managed resources need to be deallocated.
        • The private Dispose method with a bool parameter is used internally to
        implement the deallocation of resources. It needs to check the disposing
        parameter and disposed flag because if the finalizer has already run, then
        only unmanaged resources need to be deallocated.
         */
    }
}
