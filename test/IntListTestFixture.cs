using System;
using System.Collections.Generic;


namespace Test.AMT.LinqExtensions
{

    public class IntListTestFixture : IDisposable
    {

        public List<int> TestList { get; set; }
        public const int MinTestValue = 0;
        public const int MaxTestValue = 9999;


        public IntListTestFixture()
        {
			TestList = new List<int>();
			for (int i = MinTestValue; i <= MaxTestValue; ++i)
            {
                TestList.Add(i);
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        #endregion IDisposable Support

    }

}