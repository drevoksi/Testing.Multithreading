namespace UnitTests;

[TestClass]
public class MultithreadingTest
{
    [TestMethod]
    public void DefaultTest1()
    {
        // Expected output: 99990000
        CompareOutputs(10000, 1);
    }
    [TestMethod]
    public void DefaultTest2()
    {
        // Expected output: 199980000
        CompareOutputs(10000, 2);
    }
    [TestMethod]
    public void DefaultTest3()
    {
        // Expected output: 299970000
        CompareOutputs(10000, 3);
    }
    [TestMethod]
    public void RandomTest()
    {
        var random = new Random();
        for (int i = 0; i < 10; i++)
        {
            CompareOutputs(random.Next(1, 10000), random.Next(1, 16));
        }
    }

    public static int ExpectedOutput(int iterations, int threads)
    {
        // Output should be equal to double the sum of the arithmetic sequence multiplied by the number of threads
        // E.g., for 10000 iterations and 3 threads: 2 * (0 + 9999) / 2 * 10000 * 3 = 299970000
        return (iterations - 1) * iterations * threads;
    }
    public static void CompareOutputs(int iterations, int threads)
    {
        Assert.AreEqual(Application.Run(iterations, threads), ExpectedOutput(iterations, threads));
    }
}
