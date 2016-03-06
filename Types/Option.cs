using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public struct Option<T> where T : class
    {
        private T _value;

        public Option(T referenceType)
        {
            _value = referenceType;
        }

        public Option<T> Bind<R>(T r, Func<R, Option<T>> func)
        {
            return new Option<T>(r);
        }


        public T Value
        {
            get
            {
                if (_value == null)
                {
                    throw new NullReferenceException("Option is None, check before use.");
                }
                return _value;
            }
            private set { _value = value; }
        }

        public static T Some(Option<T> value) => value.Value;

        public bool Some() => !None();

        public bool None() => Value == default(T);

        public static Option<string> AddOne(Option<string> option)
        {
            return ApplyFunction(option, (s => s + "1"));
        }

        static Option<R> ApplyFunction<A, R>(Option<A> option, Func<A, R> function) where A : class where R : class
        {
            return ApplySpecialFunction<A, R>(option, (A unwrapped) => new Option<R>(function(unwrapped)));
        }

        static Option<R> ApplySpecialFunction<A, R>(Option<A> option, Func<A, Option<R>> function) where A : class where R : class
        {
            if (option.Some())
            {
                A unwrapped = option.Value;
                Option<R> result = function(unwrapped);
                return result;
            }
            return new Option<R>(default(R));
        }
    }
}
