using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace benchmark
{
    class Program
    {
        public static int N = 1000;
        public static Stopwatch stopwatch = new Stopwatch();
        static int[,] randomizeInts(int[,]arr)
        {
            Random rng = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    arr[i, j] = rng.Next(Int32.MinValue,Int32.MaxValue);
                }
            }
            return arr;
        }
        static float[,] randomizeFloats(float[,]arr)
        {
            Random rng = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    arr[i, j] = rng.Next();
                }
            }
            return arr;
        }

        static double[,] randomizeDoubles(double[,]arr)
        {
            Random rng = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    arr[i, j] = rng.Next();
                }
            }
            return arr;
        }

        static double arrInt(int[,] arr1, int[,] arr2)
        {
            int a=0;
            randomizeInts(arr1);
            randomizeInts(arr2);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            int[,] resArr = new int[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //resArr[i, j] = 0;
                    for (int k = 0; k < N; k++)
                    {
                        resArr[i, j] += arr1[i,k] * arr2[k,j];
                        a++;
                    }
                }
            }
            stop.Stop();
            TimeSpan interval = stop.Elapsed;
            return interval.TotalMilliseconds;
        }

        static double arrFloat(float[,] arr1, float[,] arr2)
        {
            int a = 0;
            randomizeFloats(arr1);
            randomizeFloats(arr2);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            float[,] resArr = new float[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //resArr[i, j] = 0;
                    for (int k = 0; k < N; k++)
                    {
                        resArr[i, j] += arr1[i,k] * arr2[k,j];
                        a++;
                    }
                }
            }
            DateTime end = DateTime.Now;
            stop.Stop();
            TimeSpan interval = stop.Elapsed;
            return interval.TotalMilliseconds;
        }
        static double arrDouble(double[,] arr1, double[,] arr2)
        {
            int a = 0;
            randomizeDoubles(arr1);
            randomizeDoubles(arr2);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            double[,] resArr = new double[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //resArr[i, j] = 0;
                    for (int k = 0; k < N; k++)
                    {
                        resArr[i, j] += arr1[i,k] * arr2[k,j];
                        a++;
                    }
                }
            }
            stop.Stop();
            TimeSpan interval = stop.Elapsed;
            return interval.TotalMilliseconds;
        }
        static void Main(string[] args)
        {
            int[,] arrayInt1 = new int[N, N];
            int[,] arrayInt2 = new int[N, N];
            float[,] arrayFloat1 = new float[N, N];
            float[,] arrayFloat2 = new float[N, N];
            double[,] arrayDouble1 = new double[N, N];
            double[,] arrayDouble2 = new double[N, N];
            stopwatch.Start();
            double serg=0;
            for (int i = 1; i < 100; i++)
            {
                serg += arrInt(arrayInt1, arrayInt2);
                Console.WriteLine("ты пьешь");
            }
            stopwatch.Stop();
            serg /= 100;
            string csv="";
            StreamWriter file = new StreamWriter(@"D:\Integer.csv");
            file.WriteLine("PModel;Task;OpType;Opt;InsCount;Timer;Time;Lnum;AvTime;AbsError;RelError;TaskPerf");
            TimeSpan tspan = stopwatch.Elapsed;
            for (int n = 1; n < 100; n++)
            {
                csv+=("Intel(R) Core(TM) i3-9100F CPu @ 3.60GHz;");
                csv+=("Matrix multiplication;");
                csv+=("Double;");
                csv+=("None;");
                csv+=("1000000000;");
                csv+=("Stopwatch;");
                csv+=(Convert.ToString(tspan.TotalMilliseconds) + ";");
                csv+=(Convert.ToString(n) + ";");
                csv+=(Convert.ToString(serg) + ";");
                csv+=(Convert.ToString(serg-tspan.TotalMilliseconds) + ";");
                csv+=(Convert.ToString(tspan.TotalMilliseconds/serg) + "%;");
                csv+=(Convert.ToString(1000000000.0/serg) + ";");
                file.WriteLine(csv);
                csv = "";
            }

            serg = 0;
            file.Close();
            stopwatch.Start();
            for (int i = 1; i < 100; i++)
            {
                serg += arrFloat(arrayFloat1, arrayFloat2);
                Console.WriteLine("ты пьешь");
            }
            stopwatch.Stop();
            serg /= 100;
            csv="";
            file = new StreamWriter(@"D:\Float.csv");
            file.WriteLine("PModel;Task;OpType;Opt;InsCount;Timer;Time;Lnum;AvTime;AbsError;RelError;TaskPerf");
            tspan = stopwatch.Elapsed;
            for (int n = 1; n < 100; n++)
            {
                csv+=("Intel(R) Core(TM) i3-9100F CPu @ 3.60GHz;");
                csv+=("Matrix multiplication;");
                csv+=("Double;");
                csv+=("None;");
                csv+=("1000000000;");
                csv+=("Stopwatch;");
                csv+=(Convert.ToString(tspan.TotalMilliseconds) + ";");
                csv+=(Convert.ToString(n) + ";");
                csv+=(Convert.ToString(serg) + ";");
                csv+=(Convert.ToString(serg-tspan.TotalMilliseconds) + ";");
                csv+=(Convert.ToString(tspan.TotalMilliseconds/serg) + "%;");
                csv+=(Convert.ToString(1000000000.0/serg) + ";");
                file.WriteLine(csv);
                csv = "";
            }

            serg = 0;
            file.Close();

            for (int i = 1; i < 100; i++)
            {
                serg += arrDouble(arrayDouble1, arrayDouble2);
                Console.WriteLine("ты пьешь");
            }
            serg /= 100;
            csv="";
            file = new StreamWriter(@"D:\Double.csv");
            file.WriteLine("PModel;Task;OpType;Opt;InsCount;Timer;Time;Lnum;AvTime;AbsError;RelError;TaskPerf");
            tspan = stopwatch.Elapsed;
            for (int n = 1; n < 100; n++)
            {
                csv+=("Intel(R) Core(TM) i3-9100F CPu @ 3.60GHz;");
                csv+=("Matrix multiplication;");
                csv+=("Double;");
                csv+=("None;");
                csv+=("1000000000;");
                csv+=("Stopwatch;");
                csv+=(Convert.ToString(tspan.TotalMilliseconds) + ";");
                csv+=(Convert.ToString(n) + ";");
                csv+=(Convert.ToString(serg) + ";");
                csv+=(Convert.ToString(serg-tspan.TotalMilliseconds) + ";");
                csv+=(Convert.ToString(tspan.TotalMilliseconds/serg) + "%;");
                csv+=(Convert.ToString(1000000000.0/serg) + ";");
                file.WriteLine(csv);
                csv = "";
            }

            serg = 0;
            file.Close();
        }
    }
}
