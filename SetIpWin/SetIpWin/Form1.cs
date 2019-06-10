using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using System.Text;
using System.Management;


namespace SetIpWin
{


    public partial class Form1 : Form
    {




        public Form1()
        {

            //开程序的时候判断有没有配置文件，没有的话创建一个
            InitializeComponent();
            StreamWriter sw;
            //不存在就新建一个文本文件,并在窗口显示目前IP
            if (!File.Exists(@"c:\\ip.txt"))
            {
                
                sw = File.CreateText(@"c:\\ip.txt");
                textBox1.Text = "192.168.2.4";
                textBox2.Text = "255.255.255.0";
                textBox3.Text = "192.168.2.1";
                textBox4.Text = "114.114.114.114";
                textBox5.Text = textBox1.Text;
                sw.Close();
            }
            else
            {
                //如果存在就读数据到窗口
                sw = File.AppendText(@"c:\\ip.txt");
                sw.Close();
                StreamReader fs = new StreamReader(@"c:\\ip.txt");

                textBox1.Text = fs.ReadLine();
                textBox2.Text = fs.ReadLine();
                textBox3.Text = fs.ReadLine();
                textBox4.Text = fs.ReadLine();
                textBox5.Text = fs.ReadLine();
                fs.Close();
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            //点设置的时候删除原来的配置文件，并且新创建一个
            File.Delete(@"c:\\ip.txt");
            StreamWriter sw;
            sw = File.CreateText(@"c:\\ip.txt");

            //把窗口的数据写入到文本

            sw.WriteLine(textBox1.Text, 1);
            sw.WriteLine(textBox2.Text, 1);
            sw.WriteLine(textBox3.Text, 1);
            sw.WriteLine(textBox4.Text, 1);
            sw.WriteLine(textBox5.Text, 1);
            sw.Close();

            //以下是设置IP的部分
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (!(bool)mo["IPEnabled"])
                    continue;

                //设置ip地址和子网掩码
                inPar = mo.GetMethodParameters("EnableStatic");
                inPar["IPAddress"] = new string[] { textBox1.Text };// 设置IP
                inPar["SubnetMask"] = new string[] { textBox2.Text };//设置子网掩码
                outPar = mo.InvokeMethod("EnableStatic", inPar, null);

                //设置网关地址
                inPar = mo.GetMethodParameters("SetGateways");
                inPar["DefaultIPGateway"] = new string[] { textBox3.Text };// 设置网关
                outPar = mo.InvokeMethod("SetGateways", inPar, null);

                //设置DNS
                inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                inPar["DNSServerSearchOrder"] = new string[] { textBox4.Text, textBox5.Text };// 1.DNS 2.备用DNS
                outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //以下是设置IP的部分
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (!(bool)mo["IPEnabled"])
                    continue;

                //设置ip地址和子网掩码
                inPar = mo.GetMethodParameters("EnableStatic");
                inPar["IPAddress"] = new string[] { "192.168.1.44" };// 设置IP
                inPar["SubnetMask"] = new string[] { textBox2.Text };//设置子网掩码
                outPar = mo.InvokeMethod("EnableStatic", inPar, null);

                //设置网关地址
                inPar = mo.GetMethodParameters("SetGateways");
                inPar["DefaultIPGateway"] = new string[] { "192.168.1.1" };// 设置网关
                outPar = mo.InvokeMethod("SetGateways", inPar, null);

                //设置DNS
                inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                inPar["DNSServerSearchOrder"] = new string[] { textBox4.Text, textBox5.Text };// 1.DNS 2.备用DNS
                outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //以下是设置IP的部分
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (!(bool)mo["IPEnabled"])
                    continue;

                //设置ip地址和子网掩码
                inPar = mo.GetMethodParameters("EnableStatic");
                inPar["IPAddress"] = new string[] { "192.168.3.44" };// 设置IP
                inPar["SubnetMask"] = new string[] { textBox2.Text };//设置子网掩码
                outPar = mo.InvokeMethod("EnableStatic", inPar, null);

                //设置网关地址
                inPar = mo.GetMethodParameters("SetGateways");
                inPar["DefaultIPGateway"] = new string[] { "192.168.3.1" };// 设置网关
                outPar = mo.InvokeMethod("SetGateways", inPar, null);

                //设置DNS
                inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                inPar["DNSServerSearchOrder"] = new string[] { textBox4.Text, textBox5.Text };// 1.DNS 2.备用DNS
                outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //以下是设置IP的部分
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (!(bool)mo["IPEnabled"])
                    continue;

                //设置ip地址和子网掩码
                inPar = mo.GetMethodParameters("EnableStatic");
                inPar["IPAddress"] = new string[] { "192.168.2.4" };// 设置IP
                inPar["SubnetMask"] = new string[] { "255.255.255.0" };//设置子网掩码
                outPar = mo.InvokeMethod("EnableStatic", inPar, null);

                //设置网关地址
                inPar = mo.GetMethodParameters("SetGateways");
                inPar["DefaultIPGateway"] = new string[] { "192.168.2.1" };// 设置网关
                outPar = mo.InvokeMethod("SetGateways", inPar, null);

                //设置DNS
                inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                inPar["DNSServerSearchOrder"] = new string[] { "192.168.2.1", "114.114.114.114" };// 1.DNS 2.备用DNS
                outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                break;
            }
        }
    }

}
