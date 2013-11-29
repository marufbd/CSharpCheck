#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCheck
{
    public abstract class Generator<T> : IEnumerable<T>
    {
        protected readonly Random _rnd = new Random(DateTime.Now.Millisecond);

        protected int _size = Parameters.GenItemCount;

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> SuchThat(Func<T, bool> predicate)
        {
            return this.Where(predicate);
        }

        public List<Stat<T>> GenerateStatistics()
        {
            return new GenStat<T>(this).GetStats().ToList();
        }
    }


    internal class GenStat<T>
    {
        private readonly IList<Stat<T>> _stats;

        public GenStat(Generator<T> generator)
        {
            var total = generator.Count();
            _stats = generator.GroupBy(x => x).Select(g => new Stat<T>(g.Key, (g.Count()*100/total))).ToList();
        }

        public IList<Stat<T>> GetStats()
        {
            return _stats;
        }
    }

    //imitate scala case class (immutable)
    public sealed class Stat<T>
    {
        public Stat(T val, int freq)
        {
            Value = val;
            Frequency = freq;
        }

        public T Value { get; private set; }
        public int Frequency { get; private set; }

        public override string ToString()
        {
            return String.Format("{0, -10} | {1, 5}%", Value, Frequency);
        }
    }
}