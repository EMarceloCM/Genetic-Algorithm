using GeneticAlgorithm.Algorithm;
using GeneticAlgorithm.Utils;
using System.Diagnostics;

string instancePath = "cvrp_instance.txt";

ProblemData instanceData = InstanceReader.Read(instancePath);

Console.WriteLine("Número de Clientes: " + instanceData.NumberOfClients);
Console.WriteLine("Capacidade do Veículo: " + instanceData.VehiclesCapacity);
Console.WriteLine("Demandas dos Clientes: " + string.Join(", ", instanceData.ClientDemand));
Console.WriteLine("--------------------------------------------------------");
Console.WriteLine("Matriz de Distâncias: ");
for (int i = 0; i < instanceData.Distances.GetLength(0); i++)
{
    for (int j = 0; j < instanceData.Distances.GetLength(1); j++)
    {
        Console.Write($"início: {i}, fim: {j}, distância: " + instanceData.Distances[i, j] + "\n");
    }
    Console.WriteLine();
}

Stopwatch stopwatch = new Stopwatch();

Genetic geneticAlgorithm = new(instanceData);
stopwatch.Start();
geneticAlgorithm.Solve();
stopwatch.Stop();
Console.WriteLine($"Tempo de execução: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Start();
AntColonyOptimization antColony = new(instanceData);
antColony.FindSolution();
stopwatch.Stop();
Console.WriteLine($"Tempo de execução: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Start();
TabuSearch tabuSearch = new(instanceData);
tabuSearch.Solve();
stopwatch.Stop();
Console.WriteLine($"Tempo de execução: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Start();
ALNS alns = new();
alns.AdaptiveLargeNeighborhoodSearch(instanceData);
stopwatch.Stop();
Console.WriteLine($"Tempo de execução: {stopwatch.ElapsedMilliseconds} ms");