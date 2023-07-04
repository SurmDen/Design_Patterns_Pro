using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public abstract class Iterator
    {
        public abstract Object First();
        public abstract Object Next();
        public abstract Object Current();
        public abstract bool IsDone();
    }

    public abstract class Aggregate
    {
        public abstract Iterator CreateIteragor();
        public abstract int Count { get;protected set; }
        public abstract Object this[int index] { get; set; }
    }

    public class SpecificAggregate : Aggregate
    {
        private readonly ArrayList items = new ArrayList();

        public override Iterator CreateIteragor()
        {
            return new SpecificIterator(this);
        }

        public override int Count 
        {
            get => items.Count;
            protected set { } 
        }

        public override Object this[int index]
        {
            get => items[index];
            set { items.Insert(index, value); }
        }
    }

    public class SpecificIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current;

        public SpecificIterator(Aggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;

            _current++;

            if (_current < _aggregate.Count)
            {
                ret = _aggregate[_current];
            }

            return ret;
        }

        public override object Current()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            if (_current >= _aggregate.Count)
            {
                return true;
            }

            return false;
        }
    }
}
