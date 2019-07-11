using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oic
{
    public abstract class Result<T, E>
    {
        abstract public R Match<R>(Func<T, R> Ok, Func<E, R> Error);
        abstract public void Foreach(Action<T> Ok, Action<E> Error);
        abstract public Result<R, E> Map<R>(Func<T, R> func);
        public static Result<T, E> Ok(T param) => new OkImpl(param);
        public static Result<T, E> Error(E param) => new ErrorImpl(param);
        public static Result<T, E> make(T param) => Ok(param);

        private class OkImpl : Result<T, E>
        {
            private readonly T param;
            public OkImpl(T param) => this.param = param;
            public override R Match<R>(Func<T, R> Ok, Func<E, R> Error) => Ok(param);
            public override void Foreach(Action<T> Ok, Action<E> Error) => Ok(param);
            public override Result<R, E> Map<R>(Func<T, R> func) => Result<R, E>.Ok(func(param));
        }

        private class ErrorImpl : Result<T, E>
        {
            private readonly E param;
            public ErrorImpl(E param) => this.param = param;
            public override R Match<R>(Func<T, R> Ok, Func<E, R> Error) => Error(param);
            public override void Foreach(Action<T> Ok, Action<E> Error) => Error(param);
            public override Result<R, E> Map<R>(Func<T, R> func) => Result<R, E>.Error(param);
        }
    }
}
