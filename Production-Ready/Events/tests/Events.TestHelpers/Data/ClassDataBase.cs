using System;
using System.Collections.Generic;
using System.Linq;

namespace Events.TestHelpers.Data
{
    public abstract class ClassDataBase : ClassDataBase<object>
    {
        protected ClassDataBase(IEnumerable<object> data) :
            base(data)
        {
        }
    }

    public abstract class ClassDataBase<T> : DataBase
    {
        protected ClassDataBase(IEnumerable<T> data) :
            base(data?.Select(d => new object[] { d }).ToArray())
        {
        }
    }

    public abstract class ClassDataBase<T1, T2> : DataBase
    {
        protected ClassDataBase(IEnumerable<Tuple<T1, T2>> data) :
            base(data?.Select(d => new object[] { d.Item1, d.Item2 }).ToArray())
        {
        }
    }

    public abstract class ClassDataBase<T1, T2, T3> : DataBase
    {
        protected ClassDataBase(IEnumerable<Tuple<T1, T2, T3>> data) :
            base(data?.Select(d => new object[] { d.Item1, d.Item2, d.Item3 }).ToArray())
        {
        }
    }

    public abstract class ClassDataBase<T1, T2, T3, T4> : DataBase
    {
        protected ClassDataBase(IEnumerable<Tuple<T1, T2, T3, T4>> data) :
            base(data?.Select(d => new object[] { d.Item1, d.Item2, d.Item3, d.Item4 })
                .ToArray())
        {
        }
    }

    public abstract class ClassDataBase<T1, T2, T3, T4, T5> : DataBase
    {
        protected ClassDataBase(IEnumerable<Tuple<T1, T2, T3, T4, T5>> data) :
            base(data?.Select(d => new object[] { d.Item1, d.Item2, d.Item3, d.Item4, d.Item5 })
                .ToArray())
        {
        }
    }

    public abstract class ClassDataBase<T1, T2, T3, T4, T5, T6> : DataBase
    {
        protected ClassDataBase(IEnumerable<Tuple<T1, T2, T3, T4, T5, T6>> data) :
            base(data?.Select(d => new object[] { d.Item1, d.Item2, d.Item3, d.Item4, d.Item5, d.Item6 })
                .ToArray())
        {
        }
    }

    public abstract class ClassDataBase<T1, T2, T3, T4, T5, T6, T7> : DataBase
    {
        protected ClassDataBase(IEnumerable<Tuple<T1, T2, T3, T4, T5, T6, T7>> data) :
            base(data?.Select(d => new object[] { d.Item1, d.Item2, d.Item3, d.Item4, d.Item5, d.Item6, d.Item7 })
                .ToArray())
        {
        }
    }
}