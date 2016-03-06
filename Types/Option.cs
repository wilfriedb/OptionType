using System;
using System.Collections.Generic;
using System.Linq;

namespace Types
{
    public struct Option<T> where T : class
    {
        private readonly T _value;

        private Option(T referenceType)
        {
            _value = referenceType;
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
        }

        public static Option<T> Some(T value) => new Option<T>(value);

        public static Option<T> None() => Some(default(T));

        public bool IsSome => !IsNone;

        public bool IsNone => _value == default(T);


        public static Option<R> FMap<A, R>(Option<A> option, Func<A, R> function) where A : class where R : class
            => Bind(option, unwrapped => new Option<R>(function(unwrapped)));

        public static Option<R> Bind<A, R>(Option<A> option, Func<A, Option<R>> function) where A : class where R : class
        {
            if (option.IsSome)
            {
                var unwrapped = option.Value;
                var result = function(unwrapped);
                return result;
            }
            return Option<R>.None();
        }
    }

}
