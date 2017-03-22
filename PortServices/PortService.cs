using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO.Ports;

namespace PortServices
{
    public partial class PortService : ServiceBase
    {
        private SerialPort port1;

        public PortService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                var portName = ports[i].ToString();
                if (!string.IsNullOrEmpty(portName))
                 {
                    port1 = new SerialPort(portName);
                    port1.BaudRate = 9600;//波特率
                    port1.Parity = Parity.None;//无奇偶校验位
                    port1.StopBits = StopBits.Two;//两个停止位
                    port1.Handshake = Handshake.RequestToSend;//控制协议
                    port1.ReceivedBytesThreshold = 4;//设置 DataReceived 事件发生前内部输入缓冲区中的字节数


                    //port1.DataReceived += new SerialDataReceivedEventHandler(port1_DataReceived);//DataReceived事件委托
                }
            }
            
        }

        protected override void OnStop()
        {
        }
    }
}
