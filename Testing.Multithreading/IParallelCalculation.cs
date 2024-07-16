using System;
namespace Testing.Multithreading
{
	public interface IParallelCalculation
	{
		public void Perform(int thread, List<int> outputs);
	}

	public class ParallelCount : IParallelCalculation
	{
		readonly int iterations;
		public ParallelCount(int iterations)
		{
			this.iterations = iterations;
		}
		// This calculation does not consider thread # – it is the same for each thread
		public void Perform(int thread, List<int> outputs)
		{
			for (int i = 0; i < iterations; i++)
			{
				int calculation = i * 2;
				lock (outputs)
				{
					outputs.Add(calculation);
				}
			}
		}
	}
}

