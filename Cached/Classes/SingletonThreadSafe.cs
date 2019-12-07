namespace Cached.Classes
{
    /// <summary>
    /// Not thread safe
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _instance = null;

        private Singleton()
        {
        }

        public static Singleton Instance => 
            _instance ?? (_instance = new Singleton());
    }
    /// <summary>
    /// This implementation is thread-safe. The thread takes out a lock on a shared object,
    /// and then checks whether or not the instance has been created before creating the
    /// instance. This takes care of the memory barrier issue (as locking makes sure that all
    /// reads occur logically after the lock acquire, and unlocking makes sure that all
    /// writes occur logically before the lock release) and ensures that only one thread
    /// will create an instance (as only one thread can be in that part of the code at a time -
    /// by the time the second thread enters it,the first thread will have created the instance,
    /// so the expression will evaluate to false). Unfortunately, performance suffers as a
    /// lock is acquired every time the instance is requested.
    /// </summary>
    public sealed class SingletonThreadSafe
    {
        private static SingletonThreadSafe _instance = null;
        private static readonly object Padlock = new object();

        /// <inheritdoc />
        private SingletonThreadSafe()
        {
        }

        public static SingletonThreadSafe Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new SingletonThreadSafe());
                }
            }
        }
    }
}
