using System.Management;

var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

foreach (ManagementObject item in searcher.Get())
{
    System.Console.WriteLine($"Название: {item["Name"]}");
    System.Console.WriteLine($"Ядер: {item["NumberOfCores"]}");
    System.Console.WriteLine($"Логических процессоров: {item["NumberOfLogicalProcessors"]}");
}

var diskSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

foreach (ManagementObject disk in diskSearcher.Get())
{
    System.Console.WriteLine($"Модель: {disk["Model"]}");
    long sizeBytes = Convert.ToInt64(disk["Size"]);
    System.Console.WriteLine($"Размер: {sizeBytes / 1024.0 / 1024 / 1024:F1} ГБ");
}