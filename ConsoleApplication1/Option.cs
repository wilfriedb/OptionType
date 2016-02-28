using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Option<T> where T : class
    {

        public Option()
        {
            Value = default(T);
        }

        public Option(T referenceType)
        {
            Value = referenceType;
        }

        public Option<T> Bind<R>(T r, Func<R, Option<T>> func)
        {
            return new Option<T>(r);
        }


        private T Value { get; }

        public static T Some(Option<T> value) => value.Value;

        public bool Some() => Value != default(T);

        public bool None() => Value == default(T);

        public static Option<string> AddOne(Option<string> option)
        {
            return ApplyFunction(option, (s => s + "1"));
        }

        static Option<R> ApplyFunction<A, R>(Option<A> option, Func<A, R> function) where A : class where R : class
        {

            return ApplySpecialFunction<A, R>(option,(A unwrapped) => new Option<R>(function(unwrapped)));

            //if (option.Some())
            //{
            //    A unwrapped = option.Value;
            //    R result = function(unwrapped);
            //    return new Option<R>(result);
            //}
            //return new Option<R>();

        }

        static Option<R> ApplySpecialFunction<A, R>(Option<A> option, Func<A, Option<R>> function) where A : class where R : class
        {
            if (option.Some())
            {
                A unwrapped = option.Value;
                Option<R> result = function(unwrapped);
                return result;
            }
            return new Option<R>();
        }
    }
}
