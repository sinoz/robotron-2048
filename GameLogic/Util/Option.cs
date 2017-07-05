using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Util
{
    interface Option<T>
    {
        bool isPresent();

        T get();
    }

    public class Some<T> : Option<T>
    {
        private T value;

        public Some(T t)
        {
            if (t == null)
            {
                throw new ArgumentException();
            }

            this.value = t;
        }

        public T get()
        {
            return value;
        }

        public bool isPresent()
        {
            return true;
        }
    }

    public sealed class None<T> : Option<T>
    {
        public T get()
        {
            throw new Exception();
        }

        public bool isPresent()
        {
            return false;
        }
    }
}
