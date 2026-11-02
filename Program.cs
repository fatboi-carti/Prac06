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

var osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

foreach (ManagementObject os in osSearcher.Get())
{
    System.Console.WriteLine($"ОС: {os["Caption"]}");
    System.Console.WriteLine($"Версия: {os["Version"]}");
}

var usbSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE 'USB%'");

System.Console.WriteLine("Устройства Plug and Play с идентификатором USB:");
foreach (ManagementObject device in usbSearcher.Get())
{
    System.Console.WriteLine($"  - {device["Name"]}");
}