using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L3_2_Ratings_
{
    internal class Program
    {
        const string readFile = "U2.txt";
        const string writeFile = "Results.txt";
        /// <summary>
        /// Reading data from the text file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="cont"></param>
        static void readData(string filename,Ratings cont)
        {
            string line;
            int number;
            string surname;
            string name;
            string answer;
            using(StreamReader reader=new StreamReader(filename))
            {
                line = reader.ReadLine();
                string[] parts = line.Split(';');
                cont.setNameFaculty(parts[0]);
                cont.setCorrectAnswer(parts[1]);
                while((line=reader.ReadLine()) != null)
                {
                    parts= line.Split(';');
                    number= Convert.ToInt32(parts[0]);
                    surname= parts[1];
                    name = parts[2];
                    answer= parts[3];
                    Rating newer= new Rating(number,surname,name,answer);
                    cont.add(newer);
                }

            }
        }
        /// <summary>
        /// Writing results to the separate text file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="cont"></param>
        static void printData(string filename,Ratings cont)
        {
            int q = 58;
            using(StreamWriter writer=new StreamWriter(filename,true))
            {
                writer.WriteLine(cont.getNameFaculty());
                writer.WriteLine("The correct answer is {0}", cont.getCorrectAnswer());
                writer.WriteLine(new string('-', q));
                writer.WriteLine("|Number|Student's Surname|Student's name|Student's answer|");
                writer.WriteLine(new string('-', q));
                for (int i=0;i<cont.get();i++)
                {
                    writer.WriteLine("|{0,6}|{1,17}|{2,14}|{3,16}|", cont.get(i).getNumber(), cont.get(i).getSurname(), cont.get(i).getName(), cont.get(i).getAnswer());
                }
                writer.WriteLine(new string('-',q));
                writer.WriteLine();
            }
        }
        /// <summary>
        /// Writing results to the separate text file with all additional information
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="cont"></param>
        static void printDataExtend(string filename, Ratings cont)
        {
            int q = 79;
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine(cont.getNameFaculty());
                writer.WriteLine("The correct answer is {0}", cont.getCorrectAnswer());
                writer.WriteLine(new string('-', q));
                writer.WriteLine("|Number|Student's Surname|Student's name|Student's answer|  Evaluation  |Grade|");
                writer.WriteLine(new string('-', q));
                for (int i = 0; i < cont.get(); i++)
                {
                    writer.WriteLine("|{0,6}|{1,17}|{2,14}|{3,16}|{4,14}|{5,5}|", cont.get(i).getNumber(), cont.get(i).getSurname(), cont.get(i).getName(), cont.get(i).getAnswer(),cont.get(i).getEvaluation(), cont.get(i).getGrade());
                }
                writer.WriteLine(new string('-', q));
                writer.WriteLine();
            }
        }
        /// <summary>
        /// method that sorts all students by points and names
        /// </summary>
        /// <param name="cont"></param>
        static void ratingSort(Ratings cont)
        {
            int smallest;
            Rating temp;
            for (int i = 0; i < cont.get() - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < cont.get(); j++)
                {
                    if (cont.get(j) > cont.get(smallest))
                    {
                        smallest = j;
                    }
                }
                temp = new Rating(
                    cont.get(smallest).getNumber(),
                    cont.get(smallest).getSurname(),
                    cont.get(smallest).getName(),
                    cont.get(smallest).getAnswer(),
                    cont.get(smallest).getEvaluation(),
                    cont.get(smallest).getGrade());

                cont.get(smallest).setNumber(cont.get(i).getNumber());
                cont.get(smallest).setSurname(cont.get(i).getSurname());
                cont.get(smallest).setName(cont.get(i).getName());
                cont.get(smallest).setAnswer(cont.get(i).getAnswer());
                cont.get(smallest).setEvaluation(cont.get(i).getEvaluation());
                cont.get(smallest).setGrade(cont.get(i).getGrade());

                cont.get(i).setNumber(temp.getNumber());
                cont.get(i).setSurname(temp.getSurname());
                cont.get(i).setName(temp.getName());
                cont.get(i).setAnswer(temp.getAnswer());
                cont.get(i).setEvaluation(temp.getEvaluation());
                cont.get(i).setGrade(temp.getGrade());
            }
        }
        static void Main(string[] args)
        {
            if(File.Exists(writeFile)) File.Delete(writeFile);
            Ratings informaticsTest = new Ratings();
            readData(readFile, informaticsTest);
            printData(writeFile, informaticsTest);
            informaticsTest.evaluation();
            printDataExtend(writeFile, informaticsTest);
            ratingSort(informaticsTest);
            printDataExtend(writeFile, informaticsTest);
            informaticsTest.kickBadStudents();
            printDataExtend(writeFile, informaticsTest);
        }
    }
}
