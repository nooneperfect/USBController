using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Management;
using System.Threading;

namespace testPort
{
    class Program
    {


        static void Main(string[] args)
        {
            USB ezUSB = new USB();

            ezUSB.AddUSBEventWatcher(USBEventHandler.USBEventListenHandler, USBEventHandler.USBEventListenHandler, new TimeSpan(0, 0, 3));
            while(true)
            {

            }
            //List<DeviceStatus> devicesPorts = new List<DeviceStatus>();
            //List<string> newDevicePorts = new List<string>(), deleteDevicePorts = new List<string>();
            //string sleepSeconds = args[1];
            //int sleepSecondInt;
            //while (true)
            //{
            //    for(int i=0;i<devicesPorts.Count;i++)
            //    {
            //        devicesPorts[i].status = false;
            //    }

            //    if (int.TryParse(sleepSeconds, out sleepSecondInt))
            //    {
            //        var list = testPort.USB.AllUsbDevices;
            //        foreach (var item in list)
            //        {
            //            if (string.Compare(item.Service, "WUDFWpdMtp") == 0)
            //            {
            //                if (devicesPorts.Count(x=>x.port == item.PNPDeviceID)>0)
            //                {
            //                    devicesPorts.Single(x=>x.port==item.PNPDeviceID).status = true;
            //                }
            //                else
            //                {
            //                    devicesPorts.Add(new DeviceStatus{ port = item.PNPDeviceID, status = true });
            //                    newDevicePorts.Add(item.PNPDeviceID);
            //                }
            //            }

            //        }
            //        var result = devicesPorts.Where(x => x.status == false).Select(x=>x.port);
            //        deleteDevicePorts.AddRange(result);
            //        foreach (var deleteDevicePort in deleteDevicePorts)
            //        {
            //            devicesPorts.RemoveAll(x=>x.port==deleteDevicePort);
            //        }
            //        Thread.Sleep(sleepSecondInt * 1000);
            //    }
            //var usbDevices = GetUSBDevices();

            //foreach (var usbDevice in usbDevices)
            //{
            //    Console.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}\r\n",
            //        usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
            //}
        }


        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            devices.ForEach(x => Console.WriteLine(x.DeviceID));
            return devices;
        }


    }
}
