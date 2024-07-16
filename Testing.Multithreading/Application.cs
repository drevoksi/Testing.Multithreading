using System;
namespace Testing.Multithreading
{
	public static class Application
	{
		public static int Run(int iterations, int threads)
		{
            var parallelCalculation = new ParallelCount(iterations);
            var parallelCalculator = new ParallelCalculator(parallelCalculation, threads);
            int result = parallelCalculator.Calculate();
            return result;
        }
	}
}

