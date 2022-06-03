// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;
using ConcurrentAndImmutableCollectionsVerificationConsoleApp;

Console.WriteLine("Welcome in testing purpose immutable vs concurrent collections");

var sut = new PerfTestImmutableVsConcurrent(100_000);

var sw = new Stopwatch();

sw.Start();
var concurrent = sut.Concurrent(10);
concurrent.Wait();
sw.Stop();

Console.WriteLine($"{nameof(sut.Concurrent)} with result {concurrent.Result} with time: {sw.ElapsedMilliseconds}");

sw.Reset();

sw.Start();
var immutable = sut.ImmutableTest(10);
immutable.Wait();
sw.Stop();
Console.WriteLine($"{nameof(sut.ImmutableTest)} with result {immutable.Result} with time: {sw.ElapsedMilliseconds}");