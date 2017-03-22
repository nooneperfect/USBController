using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace testPort
{
    class USBEventHandler
    {
        public static void USBEventListenHandler(Object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
            {
                Console.WriteLine("USB插入时间：" + DateTime.Now + "\r\n");
            }
            else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
            {
                Console.WriteLine("USB拔出时间：" + DateTime.Now + "\r\n");
            }

            foreach (USBControllerDevice Device in USB.WhoUSBControllerDevice(e))
            {
                Console.WriteLine("\tAntecedent：" + Device.Antecedent + "\r\n");
                Console.WriteLine("\tDependent：" + Device.Dependent + "\r\n");
            }
        }
    }

      
    
}
