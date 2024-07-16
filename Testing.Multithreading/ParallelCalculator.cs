using System;
using System.Threading;

namespace Testing.Multithreading
{
	public class ParallelCalculator
	{
		public readonly IParallelCalculation parallelCalculation;
		public readonly int threadCount;
		public ParallelCalculator(IParallelCalculation parallelCalculation, int threadCount)
		{
			this.parallelCalculation = parallelCalculation;
			this.threadCount = threadCount;
		}

		public int Calculate()
		{
			var outputs = new List<int>();
			var threads = new Queue<Thread>(threadCount);

			for (int i = 1; i <= threadCount; i++)
			{
				var thread = new Thread(() =>
				{
					Thread.CurrentThread.IsBackground = true;
					parallelCalculation.Perform(i, outputs);
				});
                threads.Enqueue(thread);
                thread.Start();
			}

			while (threads.Count > 0)
				if (!threads.Peek().IsAlive) threads.Dequeue();

			return outputs.Sum();
		}
	}
}

