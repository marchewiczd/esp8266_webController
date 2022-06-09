namespace Core.Helpers
{
    internal class AsyncHelper
    {
        private static readonly TaskFactory taskFactory = new(
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> asyncFunc)
        {
            return taskFactory.
                StartNew<Task<TResult>>(asyncFunc)
                .Unwrap<TResult>()
                .GetAwaiter()
                .GetResult();
        }

        public static void RunSync(Func<Task> asyncFunc)
        {
            taskFactory.
                StartNew<Task>(asyncFunc)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

    }
}
