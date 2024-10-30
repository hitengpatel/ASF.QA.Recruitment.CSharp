/* ************************ Original Code *************************
 using Application;
using System.Globalization;
using System.Net.Http.Json;

using HttpClient client = new();

var canadaDateResponse = client.GetFromJsonAsync<WorldTimeAPIResponse>("http://worldtimeapi.org/api/timezone/America/Toronto").Result;
var canadaDateTime = DateTimeOffset.ParseExact(canadaDateResponse.datetime, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFzzz", CultureInfo.InvariantCulture);

var ukDateTime = DateTime.Now;

var dateTimeFormatter = "dddd dd MMMM yyyy HH:mm:ss";

Console.WriteLine($"UK Time: {ukDateTime.ToString(dateTimeFormatter)}");
Console.WriteLine($"Canada time:  {canadaDateTime.ToString(dateTimeFormatter)}");

if (ukDateTime > canadaDateTime)
{
    Console.WriteLine($"You are {Math.Round(ukDateTime.Subtract(canadaDateTime.DateTime).TotalMinutes, 0)}m ahead of Canada");
} 
else
{
    Console.WriteLine($"Canada is {Math.Round(canadaDateTime.Subtract(ukDateTime).TotalMinutes, 0)}m ahead of you");
}

//public partial class Program { }
*******************************************************************/

/***** TO DO *****************************************************
Console qpp need to be refactored to take httpclient as constructor paramater (DI - Depenedancy Jenction) by moving it into new class
Than we can create the console app with a mocked httpclient or real httpclient 
and we can switch unit testing as required to use real httpclient endpoint or moked service 
******************************************************************/

using Application;
using System;
using System.Globalization;
using System.Net.Http.Json;

using HttpClient client = new(); 
var dateTimeFormatter = "dddd dd MMMM yyyy HH:mm:ss";


var canadaDateResponse = client.GetFromJsonAsync<WorldTimeAPIResponse>("http://worldtimeapi.org/api/timezone/America/Toronto").Result;
var canadaDateTime = DateTimeOffset.ParseExact(canadaDateResponse.datetime, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFzzz", CultureInfo.InvariantCulture);

var ukDateResponse = client.GetFromJsonAsync<WorldTimeAPIResponse>("http://worldtimeapi.org/api/timezone/GB").Result;
var ukDateTime = DateTimeOffset.ParseExact(ukDateResponse.datetime, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFzzz", CultureInfo.InvariantCulture);

Console.WriteLine($"UK Time: {ukDateTime.ToString(dateTimeFormatter)}");
Console.WriteLine($"Canada Time: {canadaDateTime.ToString(dateTimeFormatter)}");


if (ukDateTime > canadaDateTime)
{
    Console.WriteLine($"You are {Math.Round(ukDateTime.Subtract(canadaDateTime.DateTime).TotalMinutes, 0)}m ahead of Canada");
}
else
{
    Console.WriteLine($"Canada is {Math.Round(canadaDateTime.Subtract(ukDateTime).TotalMinutes, 0)}m ahead of you");
}