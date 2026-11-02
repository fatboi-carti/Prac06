using System.Management;

var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

foreach (ManagementObject item in searcher.Get())
{
    System.Console.WriteLine($"Название: {item["Name"]}");
    System.Console.WriteLine($"Ядер: {item["NumberOfCores"]}");
    System.Console.WriteLine($"Логических процессоров: {item["NumberOfLogicalProcessors"]}");
}