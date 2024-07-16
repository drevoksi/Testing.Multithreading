using Testing.Multithreading;

int iterations = 10000;
int threads = Convert.ToInt32(Console.ReadLine());

int result = Application.Run(iterations, threads);

Console.WriteLine(result);