using System;
using System.Collections.Generic;
using System.Linq;

namespace Subject
{
    /// <summary>
    /// Thread safe singleton responsible for creating
    /// unique sequence for email subject.
    /// </summary>
    public sealed class ReferenceIncrementer
    {
        private static readonly Lazy<ReferenceIncrementer> Lazy =
            new Lazy<ReferenceIncrementer>(() =>
                new ReferenceIncrementer());

        public static ReferenceIncrementer Instance => Lazy.Value;

        private List<int> _baseList = new List<int>();

        /// <summary>
        /// Populate HashSet with random numbers.
        /// HastSet items are unique.
        /// </summary>
        private void CreateList()
        {
            _baseList = new List<int>();

            for (var index = 1; index < 9000; index++)
            {
                _baseList.Add(index);
            }
        }
        /// <summary>
        /// Return a left padded number prefix with REF: 0001
        /// .Any ask if there are any values when called.
        /// </summary>
        /// <returns></returns>
        public string GetReferenceValue()
        {
            if (!_baseList.Any())
            {
                CreateList();
            }

            var number = _baseList.FirstOrDefault();
            _baseList.Remove(number);

            return $" REF: {number:D4}";

        }

        /// <summary>
        /// Instantiate List
        /// </summary>
        private ReferenceIncrementer()
        {
            CreateList();
        }
        /// <summary>
        /// Used to reset at a given time e.g. right before midnight,
        /// perhaps by a scheduled job.
        /// </summary>
        public void Reset()
        {
            CreateList();
        }
    }
}
