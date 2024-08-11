using System;
using System.Diagnostics;

public class MergeSort
{
    public static void Main(string[] args)
    {
        // Create data sets
        int[] smallDataSet = GenerateDataSet(37);
        int[] mediumDataSet = GenerateDataSet(845);
        int[] largeDataSet = GenerateDataSet(13489);

        // Execute and time the original merge sort
        Console.WriteLine("Original Merge Sort:");
        ExecuteAndTime(smallDataSet, "Small");
        ExecuteAndTime(mediumDataSet, "Medium");
        ExecuteAndTime(largeDataSet, "Large");

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }

    private static void ExecuteAndTime(int[] dataSet, string sizeLabel)
    {
        int[] dataSetCopy = (int[])dataSet.Clone();
        Stopwatch stopwatch = Stopwatch.StartNew();
        MergeSortAlgorithm(dataSetCopy, 0, dataSetCopy.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"{sizeLabel} Data Set - Time elapsed: {stopwatch.Elapsed.TotalMilliseconds} ms");
    }

    private static void MergeSortAlgorithm(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSortAlgorithm(array, left, middle);
            MergeSortAlgorithm(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }

    private static void Merge(int[] array, int left, int middle, int right)
    {
        int leftArraySize = middle - left + 1;
        int rightArraySize = right - middle;

        int[] leftArray = new int[leftArraySize];
        int[] rightArray = new int[rightArraySize];

        Array.Copy(array, left, leftArray, 0, leftArraySize);
        Array.Copy(array, middle + 1, rightArray, 0, rightArraySize);

        int i = 0, j = 0;
        int k = left;
        while (i < leftArraySize && j < rightArraySize)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftArraySize)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightArraySize)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }

    private static int[] GenerateDataSet(int size)
    {
        Random rand = new Random();
        int[] dataSet = new int[size];
        for (int i = 0; i < size; i++)
        {
            dataSet[i] = rand.Next(0, 10000);
        }
        return dataSet;
    }
}
    

