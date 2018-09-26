using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stringConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("String to Hex(with space)");
            comboBox1.Items.Add("String to Hex(without space)");
            comboBox1.Items.Add("Hex to String");
            comboBox1.Items.Add("String to Base64");
            comboBox1.Items.Add("Base64 to String");
            comboBox1.Items.Add("URL encode");
            comboBox1.Items.Add("URL decode");
            comboBox1.Items.Add("String to Unicode");
            comboBox1.Items.Add("Unicode to String");
            comboBox1.Items.Add("GB2312 to UTF-8");
            comboBox1.Items.Add("UTF-8 to GB2312");
            comboBox1.Items.Add("String to MD5(Hex)");
            comboBox1.Items.Add("String to SHA-1(Hex)"); 
            comboBox1.Items.Add("String to SHA-256(Hex)");
            comboBox1.Items.Add("String to SHA-512(Hex)");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox2.Text = ConvertString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            textBox2.Text = ConvertString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
                listBox1.Items.Add(comboBox1.SelectedItem);
            textBox2.Text = ConvertString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(realtimeCheckBox.Checked)
                textBox2.Text = ConvertString();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConvertString();
        }

        private string ConvertString()
        {
            string result = textBox1.Text;
            foreach(var v in listBox1.Items)
            {
                switch(v.ToString())
                {
                    case "String to Hex(with space)":
                        result = ConvertTool.String2Hex(result, true);
                        break;
                    case "String to Hex(without space)":
                        result = ConvertTool.String2Hex(result, false);
                        break;
                    case "Hex to String":
                        result = ConvertTool.Hex2String(result);
                        break;
                    case "String to Base64":
                        result = ConvertTool.base64(result,true);
                        break;
                    case "Base64 to String":
                        result = ConvertTool.base64(result,false);
                        break;
                    case "URL encode":
                        result = System.Web.HttpUtility.UrlEncode(result);
                        break;
                    case "URL decode":
                        result = System.Web.HttpUtility.UrlDecode(result);
                        break;
                    case "GB2312 to UTF-8":
                        result = ConvertTool.ChangeEncode(result, "GB2312", "UTF-8");
                        break;
                    case "UTF-8 to GB2312":
                        result = ConvertTool.ChangeEncode(result, "UTF-8", "GB2312");
                        break;
                    case "String to MD5(Hex)":
                        result = ConvertTool.MD5Encrypt(result);
                        break;
                    case "String to SHA-1(Hex)":
                        result = ConvertTool.sha1(result);
                        break;
                    case "String to SHA-256(Hex)":
                        result = ConvertTool.sha256(result);
                        break;
                    case "String to SHA-512(Hex)":
                        result = ConvertTool.sha512(result);
                        break;
                    case "String to Unicode":
                        result = ConvertTool.String2Unicode(result);
                        break;
                    case "Unicode to String":
                        result = ConvertTool.Unicode2String(result);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
