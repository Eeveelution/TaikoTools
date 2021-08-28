using System;
using System.Collections.Generic;
using System.Diagnostics;
using TaikoTools.ReplayParser;

Stopwatch stopwatch = Stopwatch.StartNew();

List<ReplayClick> clicks = new ReplayParser("replay.osr").ParseReplay();

stopwatch.Stop();

Console.WriteLine("Elapsed Milliseconds: " + stopwatch.ElapsedMilliseconds.ToString());
