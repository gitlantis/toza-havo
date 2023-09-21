// See https://aka.ms/new-console-template for more information

using System;
using System.Text;

var device = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

Random gen = new Random();

for (int i = 0; i < 99; i++)
{
    var baseUrl = $"http://95.130.227.149:8080/api/StationData/Post?secret=_MyP0werfulDev!ce&station_id={device}";
    for (int j = 0; j < 32; j++)
    {
        if (j < 10)
            baseUrl += $"&A0{j}={gen.NextInt64(-10, 50) + gen.NextDouble():0.###}";
        else
            baseUrl += $"&A{j}={gen.NextInt64(-10, 50) + gen.NextDouble():0.###}";
    }

    int hour = gen.Next(0, 24);         // gen hour between 0 and 23
    int minute = gen.Next(0, 60);       // gen minute between 0 and 59
    int second = gen.Next(0, 60);       // gen second between 0 and 59

    var currentDate = DateTime.Now;
    var randomDate = new DateTime(currentDate.Year, currentDate.Month, DateTime.Today.AddDays(-gen.Next(7)).Day, hour, minute, second);


    baseUrl += $"&date={randomDate}";

    var httpClient= new HttpClient();

    var result = await httpClient.GetAsync(baseUrl);

    Console.WriteLine($"{baseUrl} -> {result.StatusCode}\n");

}
