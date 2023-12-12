using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SgLinxExecutor
{
    internal class Geral
    {
        
        public string InverterData(string str)
        {
            char[] charStr = str.ToCharArray();
            string str2 = charStr[2].ToString() + charStr[3].ToString() + charStr[0].ToString() + charStr[1].ToString();
            return str2;
        }

        public string InverterDataTimePicker(string str)
        {
            string[] arrayStr = str.Split('/');
            string str2 = arrayStr[2]+"-" +arrayStr[1]+"-"+arrayStr[0];
            return str2;
        }
        public string ToDt(string str,char separador)
        {
            //2023-02-22 --> 0222
            string[] arrayStr = str.Split(separador);
            string str2 = arrayStr[0];
            char[] transform = str2.ToCharArray();
            string str3 =( arrayStr[1] + transform[2] + transform[3]);
            str = str3;
            return str;

        }
        public bool ValidarData(TextBox textBox)
        {
            char[] textBoxArray = textBox.Text.ToCharArray();
            int textBoxArrayX = int.Parse((textBoxArray[0] + textBoxArray[1]).ToString());
            int textBoxArrayY = int.Parse((textBoxArray[2] + textBoxArray[3]).ToString());
            if (textBoxArrayX > textBoxArrayY)
            {
                MessageBox.Show("Mês não pode ser maior que o ano");
                return false;
            }
            else
            {
               return true;
            }
        }

        public string IgnoreDateHoursMinutesSeconds(string str)
        {
            string str2 = str.Split(' ')[0];
            return str2;
        }

        public string AlterSeparator(string str, char separator , char newSeparator)
        {
            string[] splitted = str.Split(separator);
            str = splitted[0] + newSeparator.ToString() + splitted[1] + newSeparator.ToString() + splitted[2];
            return str;
        }

        public string DateToFormatAAAAMMDD(string str, char separator)
        {
            string[] arrayStr = str.Split(separator);
            string str2 = arrayStr[2] + "-" + arrayStr[1] + "-" + arrayStr[0];
            return str2;
        }

        
    }
}
