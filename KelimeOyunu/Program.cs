using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// @Author Yunus Emre Erturk ====> yemrerturk @gmail.com / www.muhendiserturk.com

namespace KelimeOyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings
             ["ConnString"].ConnectionString);
            //Disconnected mimaride veriler Memory'e cekilir ve orada işlem görür.
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT ProductName FROM Products", Conn);
            DataTable dt_productTable = new DataTable();
            DataTable dt_productTableFake = new DataTable();
            dt_productTableFake.Columns.Add("isim");
            dataAdapter.Fill(dt_productTable);

            char harf = ' ';
            string str=null;
            int counter = 0;
            int loopCounter = 0;

            //Name'lerin boşluğa kadar olan kismini başka bir DataTable'a dolduruyorum.(SQL de yapılıp direk o çekilebilirdi)
            foreach (DataRow dataRow in dt_productTable.Rows)
            {
                str = dataRow[0].ToString();

                if (str.Contains(" "))
                {
                    int i = str.IndexOf(" ");
                    str = str.Substring(0, i);
                    dataRow["ProductName"] = str;
                    dt_productTableFake.Rows.Add(dataRow[0].ToString()); //dataRow[0] veya dataRow["ProductName"]
                }
                else
                {
                    int i = str.Length;
                    str = str.Substring(0, i);
                    dataRow["ProductName"] = str;
                    dt_productTableFake.Rows.Add(dataRow[0].ToString());
                }
            }
            
            while (true)
            {
                if (harf == ' ')
                {
                    Console.WriteLine("harf girin");
                    harf = Convert.ToChar(Console.ReadLine());

                }

                dt_productTableFake.AcceptChanges();// Çok ONEMLI !! DataTable'da yapilacak degisiklikleri (delete) kabul etmeden delete yapamıyoruz !!
                foreach (DataRow dataRow2 in dt_productTableFake.Rows)
                {
                    str = dataRow2[0].ToString();
                    if (str[0] == harf.ToString().ToUpper()[0])
                    {
                        Console.WriteLine(dataRow2[0].ToString());
                        harf = str[str.Length - 1];
                        counter++;
                        dataRow2.Delete();//DataTable'da yapılan değişiklik.(satir silinmesi)
                    }   
                }
                 
                loopCounter++;
                if (loopCounter == 2)
                {
                    Console.WriteLine("Oyun bitti bulunan kelime sayisi :"+counter);
                    harf = ' ';
                    counter = 0;
                    loopCounter = 0;
                    dt_productTableFake.Reset();

                    dt_productTableFake.Columns.Add("isim");
                    foreach (DataRow dataRow in dt_productTable.Rows)
                    {
                        str = dataRow[0].ToString();

                        if (str.Contains(" "))
                        {
                            int i = str.IndexOf(" ");
                            str = str.Substring(0, i);
                            dataRow["ProductName"] = str;
                            dt_productTableFake.Rows.Add(dataRow[0].ToString()); //dataRow[0] veya dataRow["ProductName"] yazılabilir.
                        }
                        else
                        {
                            int i = str.Length;
                            str = str.Substring(0, i);
                            dataRow["ProductName"] = str;
                            dt_productTableFake.Rows.Add(dataRow[0].ToString());

                        }
                    }

                }
            }


            //@Author Yunus Emre Erturk ====> yemrerturk@gmail.com / www.muhendiserturk.com
        }
    }
}
