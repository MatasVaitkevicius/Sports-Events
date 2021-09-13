using System;
using System.Collections;
using System.Collections.Generic;

namespace Events.TestHelpers.Data
{
    public abstract class DataBase : IEnumerable<object[]>
    {
        private readonly ICollection<object[]> _data;

        protected DataBase(object[][] data)
        {
            // ReSharper disable once JoinNullCheckWithUsage
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            _data = data;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}