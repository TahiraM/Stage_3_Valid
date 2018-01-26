using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Stage3_Verification
{
    class Extraction
    {
        public static string FileType()
        {
            string file = "Deal.csv";
            return file;
        }
        public static StringBuilder ReadFile()
        {
            var JSONString = new StringBuilder();
            string Fulltext;
            using (StreamReader sr = new StreamReader(FileType()))
            {
                while (!sr.EndOfStream)
                {
                    JSONString.Append("[");
                    Fulltext = sr.ReadToEnd().ToString();
                    string[] rows = Fulltext.Split('\n');
                    string a = rows[0];
                    string b = rows[1];
                    string c = rows[2];
                    string[] AValues = a.Split("||");
                    string[] BValues = b.Split("||");
                    string[] CValues = c.Split("||");

                    for (int i = 0; i <= rows.Count() - 1; i++)
                    {
                        JSONString.Append("{");
                        for (int j = 0; j < AValues.Count(); j++)
                        {
                            if (i == 0)
                            {
                                if (j == 7 || j == 5)
                                {
                                    Nullable<int> v = Validations.IntVal(BValues[j].ToString());
                                    JSONString.Append("\"" + AValues[j].ToString() + "\":" + "\"" + v + "\"");
                                    JSONString.Append(",");
                                }
                                if (j == 12)
                                {
                                    Nullable<double> w = Validations.DoubVal(BValues[j].ToString());
                                    JSONString.Append("\"" + AValues[j].ToString() + "\":" + "\"" + w + "\"");
                                    JSONString.Append(",");
                                }
                                if (j == 0 || j == 1 || j == 2 || j == 8)
                                {
                                    if (BValues[j].ToString() == "")
                                    {
                                        Console.WriteLine("Error: ");
                                        string empty = Validations.Error(BValues[j].ToString());
                                        Console.WriteLine(AValues[j].ToString() + empty + " in Row 1");
                                        break;
                                    }
                                    else
                                    {
                                        string m = Validations.StriVal(BValues[j].ToString());
                                        JSONString.Append("\"" + AValues[j].ToString() + "\":" + "\"" + m + "\"");
                                        JSONString.Append(",");
                                    }
                                }
                                else
                                {
                                    string x = Validations.StriVal(BValues[j].ToString());
                                    JSONString.Append("\"" + AValues[j].ToString() + "\":" + "\"" + x + "\"");
                                    JSONString.Append(",");
                                }
                            }
                        }

                        if (i == rows.Count()-1)
                        {
                            for (int k = 0; k < AValues.Count(); k++)
                            {
                                if (k == 7)
                                {
                                    Nullable<int> v = Validations.IntVal(CValues[k].ToString());
                                    JSONString.Append("\"" + AValues[k].ToString() + "\":" + "\"" + v + "\"");
                                    JSONString.Append(",");
                                }
                                if (k == 12)
                                {
                                    Nullable<double> w = Validations.DoubVal(CValues[k].ToString());
                                    JSONString.Append("\"" + AValues[k].ToString() + "\":" + "\"" + w + "\"");
                                    JSONString.Append(",");
                                }
                                if (k == 5 || k == 11 || k == 8 || k == 2)
                                {
                                    if (CValues[k].ToString() == "")
                                    {
                                        Console.WriteLine("Error: ");
                                        string empty = Validations.Error(CValues[k].ToString());
                                        Console.WriteLine(AValues[k].ToString() + empty + " in Row 2");
                                        break;
                                    }
                                    else
                                    {
                                        string m = Validations.StriVal(CValues[k].ToString());
                                        JSONString.Append("\"" + AValues[k].ToString() + "\":" + "\"" + m + "\"");
                                        JSONString.Append(",");
                                    }
                                }
                                else
                                {
                                    string x = Validations.StriVal(CValues[k].ToString());
                                    JSONString.Append("\"" + AValues[k].ToString() + "\":" + "\"" + x + "\"");
                                    JSONString.Append(",");
                                }
                            }
                        }

                        JSONString.Append("}");
                    }
                }
                JSONString.Append("]");
            }
            Console.WriteLine(JSONString.ToString());
            FileStream Sjson = new FileStream("Vali.json", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter addJ = new StreamWriter(Sjson);
            Console.SetOut(addJ);
            Console.Write(JSONString.ToString());
            Console.SetOut(Console.Out);
            addJ.Close();
            Sjson.Close();
            return JSONString;
        }

    }
}
