using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler_Code
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /** Simple interface with user **/
            Console.WriteLine("Choose a scheduling algorithim:");
            Console.Write(" 0:FCFS \n 1:SJF \n 2:SJF preemptive \n 3:Priority \n 4:Priority preemptive \n 5:RR\n");
            string input = Console.ReadLine();
            int scheuling_Algorithim;
            Int32.TryParse(input, out scheuling_Algorithim);
            // Console.WriteLine();
            Console.WriteLine(scheuling_Algorithim);
            switch (scheuling_Algorithim)
            {
                case 0:
                    {
                        Console.WriteLine("How many processes do you want to enter");
                        input = Console.ReadLine();
                        int processes_number;
                        Int32.TryParse(input, out processes_number);
                        Console.Write("No. processes = {0}\n", processes_number);
                        /** Start reading the data **/
                        //Queue burst_time = new Queue();
                        //Queue arrival_time = new Queue();
                        string strTemp;
                        string[] strTemp_arr;
                        // used to play with arrival time given "not life action"
                        //List<string[]> arrayList = new List<string[]>();
                        List<string> strTemp_list = new List<string>();
                        List<double> Arrival_list = new List<double>();
                        List<string> name_list = new List<string>();
                        Console.WriteLine("Please enter a sequence of processes like this:");
                        Console.WriteLine("Burst_time  Arrival_time");
                        for (int i = 0; i < processes_number; i++)
                        {//
                            strTemp = Console.ReadLine();
                            strTemp_arr = strTemp.Split(' ');
                            strTemp_arr[0].Trim();
                            strTemp_arr[1].Trim();
                            strTemp_list.Add(strTemp_arr[0]);
                            Arrival_list.Add(Convert.ToInt32(strTemp_arr[1]));
                            name_list.Add("P" + Convert.ToString(i + 1));

                        }
                        /** Check the list values **/
                        //test_list_values(strTemp_list, processes_number);
                        //test_list_values(Arrival_list, processes_number);
                        //test_list_values(name_list, processes_number);

                        /** sort the list in array shape **/
                        double[] key_arr = Arrival_list.ToArray();
                        string[] values_arr = strTemp_list.ToArray();
                        string[] names_arr = name_list.ToArray();
                        double[] key_arr2 = Arrival_list.ToArray();
                        Array.Sort(key_arr, values_arr);
                        Array.Sort(key_arr2, names_arr); // to make P1 > first process entered by user not first process in arrival time

                        /** test the array values **/
                        //test_arr_values(key_arr, processes_number);
                        //Console.WriteLine();
                        //test_arr_values(values_arr, processes_number);
                        //Console.WriteLine();
                        //test_arr_values(names_arr, processes_number);

                        /** assign values to the list of arrays **/
                        // TBD

                        /** output printing **/
                        Print_FCFS(key_arr, values_arr, names_arr);
                        break;
                        /** Check the queues values **/
                        //test_queue_values(burst_time);
                        //test_queue_values(arrival_time);
                    }

                case 1:
                case 2:
                case 3:
                case 4:
                    {
                        Console.WriteLine("How many processes do you want to enter");
                        input = Console.ReadLine();
                        int processes_number;
                        Int32.TryParse(input, out processes_number);
                        Console.Write("No. processes = {0}\n", processes_number);
                        Console.WriteLine();
                        //processes_number = 5; // TBR later
                        int[,] processes = new int[processes_number, 4];
                        string strTemp;
                        string[] strTemp_arr;
                        /** read processes array **/
                        Console.WriteLine("Please enter a sequence of processes like this:");
                        Console.WriteLine("Process_number Arrival_time Burst_time Priority"); // Adjust the priority >> SJF
                        for (int i = 0; i < processes_number; i++)
                        {//
                            
                            strTemp = Console.ReadLine();
                            strTemp_arr = strTemp.Split(' '); // four elements
                            strTemp_arr[0].Trim();
                            strTemp_arr[1].Trim();
                            strTemp_arr[2].Trim();
                            strTemp_arr[3].Trim();
                            // read array
                            int temp_input; 
                            Int32.TryParse(strTemp_arr[0], out temp_input);
                            processes[i, 0] = temp_input;
                            //Number_list.Add(temp_input);
                            Int32.TryParse(strTemp_arr[1], out temp_input);
                            processes[i, 1] = temp_input;
                            //Number_list.Add(temp_input);
                            Int32.TryParse(strTemp_arr[2], out temp_input);
                            processes[i, 2] = temp_input;
                            //Number_list.Add(temp_input);
                            Int32.TryParse(strTemp_arr[3], out temp_input);
                            processes[i, 3] = temp_input;
                            //Number_list.Add(temp_input);
                        }
                                                
                        for (int i = 0; i < processes_number; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                Console.Write(processes[i, j]);
                            }
                            Console.WriteLine();
                        }
                        Console.Read();
                        int[] ReadyQ = new int[5];
                        int ReadyNum = 0;
                        int PreTop = -1;
                        int time = 0;
                        bool finished = true;
                        while (finished)
                        {
                            // lookking for new processes to enter the ready queue
                            for (int i = 0; i < processes_number; i++)
                            {
                                if (processes[i, 1] == time) { ReadyQ[ReadyNum] = processes[i, 0]; ReadyNum++; }
                            }

                            // sorting according to required algorithm
                            if (scheuling_Algorithim == 1)
                            {
                                sort(processes, processes_number, ref ReadyQ, ReadyNum); //preemptive SJF
                            }
                            else if (scheuling_Algorithim == 2)
                            {
                                if (PreTop != ReadyQ[0])
                                    sort(processes, processes_number, ref ReadyQ, ReadyNum);  //non-preemptive SJF
                                PreTop = ReadyQ[0];
                            }
                            else if (scheuling_Algorithim == 3)
                            {
                                Psort(processes, processes_number, ref ReadyQ, ReadyNum); //preemptive priority
                            }
                            else if (scheuling_Algorithim == 4)
                            {
                                if (PreTop != ReadyQ[0])
                                    Psort(processes, processes_number, ref ReadyQ, ReadyNum);//non-preemptive priority
                                PreTop = ReadyQ[0];
                            }


                            if (ReadyNum == 0) Console.WriteLine("at the second {0}: No processes yet", time);
                            else
                            {
                                running(ReadyQ[0], ref processes, processes_number, time); //running the top queue process if there is any
                                dequeue(processes, processes_number, ref ReadyQ, ref ReadyNum); //removing the 0 remaining time process from ReadyQ if there is any
                            }
                            // checking if all processes have 0 remaining time then processing has been finished
                            int counter = 0;
                            for (int i = 0; i < processes_number; i++)
                            {
                                if (processes[i, 2] == 0) counter++;
                            }
                            if (counter == processes_number) finished = false;
                            else time++;
                        }
                        Console.WriteLine("Finished processing at {0} second.", time + 1);
                        Console.ReadKey();
                        break;
                    }

                case 5:
                    {
                        /** Simple User Interface **/
                        Console.WriteLine("How much is your Quantum?");
                        float Quantum = Convert.ToSingle(Console.ReadLine());
                        //Console.WriteLine(Quantum+0.535);
                        Console.WriteLine("How many processes do you to enter");
                        input = Console.ReadLine();
                        int processes_number;
                        Int32.TryParse(input, out processes_number);
                        Console.WriteLine();
                        /** Start reading the data **/
                        Console.WriteLine("Please enter a sequence of processes like this:");
                        Console.WriteLine("Burst_time  Arrival_time");
                        //List<string[]> arrayList = new List<string[]>();
                        string strTemp;
                        string[] strTemp_arr;
                        List<string> strTemp_list = new List<string>();
                        List<double> Arrival_list = new List<double>();
                        List<string> name_list = new List<string>();
                        for (int i = 0; i < processes_number; i++)
                        {//
                            strTemp = Console.ReadLine();
                            strTemp_arr = strTemp.Split(' ');
                            strTemp_arr[0].Trim();
                            strTemp_arr[1].Trim();
                            strTemp_list.Add(strTemp_arr[0]);
                            Arrival_list.Add(Convert.ToInt32(strTemp_arr[1]));
                            name_list.Add("P" + Convert.ToString(i + 1));
                        }

                        /** sort the list in array shape **/
                        double[] key_arr = Arrival_list.ToArray();
                        string[] values_arr = strTemp_list.ToArray();
                        string[] names_arr = name_list.ToArray();
                        double[] key_arr2 = Arrival_list.ToArray();
                        Array.Sort(key_arr, values_arr);
                        Array.Sort(key_arr2, names_arr); // to make P1 > first process entered by user not first process in arrival time

                        /** output printing **/
                        Print_RR(key_arr, values_arr, names_arr, Quantum);
                        break;
                    }

                    /** Check the queues values **/
                    //test_queue_values(burst_time);
                    //test_queue_values(arrival_time);
            }

        }

        public static void test_arr_values(string[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + "\n");
            }
        }
        public static void test_arr_values(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + "\n");
            }
        }
        public static void test_arr_values(double[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + "\n");
            }
        }
        public static void test_list_values(List<string> l, int n)
        {

            //string[] array = list.ToArray(); // TB Removed
            for (int i = 0; i < n; i++)
            {
                Console.Write(l[i] + "\n");
            }

        }
        public static void test_list_values(List<int> l, int n)
        {

            //string[] array = list.ToArray(); // TB Removed
            for (int i = 0; i < n; i++)
            {
                Console.Write(l[i] + "\n");
            }

        }


        public static void test_queue_values(Queue<int> q)
        {
            Console.WriteLine();
            Console.Write("count of the queue =" + q.Count + " ");
            foreach (int i in q)
            {
                Console.Write(i + " ");
            }

        }

        public static void Print_FCFS(double[] key_arr, string[] values, string[] names)
        {
            int size = key_arr.Length;
            double passed_time = key_arr[0];
            Console.Write("|" + passed_time + "|");
            for (int i = 0; i < size; i++)
            {
                passed_time += Convert.ToDouble(values[i]);
                if ((passed_time - Convert.ToDouble(values[i])) < key_arr[i])
                {
                    Console.Write("  ");
                    Console.Write("  ");
                    Console.Write("|" + key_arr[i] + "|");
                    passed_time += key_arr[i] - (passed_time - Convert.ToDouble(values[i]));
                    Console.Write("  ");
                    Console.Write(names[i] + "  ");
                    Console.Write("|" + passed_time + "|");
                }
                else
                {
                    Console.Write("  ");
                    Console.Write(names[i] + "  ");
                    Console.Write("|" + passed_time + "|");
                }
            }
        }



        public static void Print_RR(double[] key_arr, string[] values, string[] names, float Quantum)
        {
            int size = key_arr.Length;
            int no_processes = size;
            int index = 0;
            List<int> previous_dead_processes = new List<int>(); // to check finished processes
            float[] values_ft = new float[size];
            double passed_time = key_arr[0];
            /** make array of float values **/
            for (int i = 0; i < size; i++)
            {
                values_ft[i] = Convert.ToSingle(values[i]);
            }

            Console.Write("|" + passed_time + "|");
            do
            {
                if (passed_time >= key_arr[index])
                {// case : current process didn't arrive yet
                    if (values_ft[index] <= 0)
                    {// this process finished its needed burst time
                        if (!previous_dead_processes.Contains(index))
                        {
                            previous_dead_processes.Add(index);
                            no_processes--;
                        }
                    }
                    else
                    {
                        Console.Write("  ");
                        Console.Write(names[index]);
                        Console.Write("  ");
                        if (values_ft[index] - Quantum < 0)
                        {// handling case: remaining time in this process < quantum
                            passed_time += values_ft[index];
                        }
                        else
                        {
                            passed_time += Quantum;
                        }
                        values_ft[index] -= Quantum;
                        passed_time = System.Math.Round(passed_time, 2);
                        Console.Write("|" + passed_time + "|");
                    }
                    index = (index + 1) % size;
                }

                else
                {
                    index = (index + 1) % size;

                }
            } while (no_processes > 0);
        }

        static void Psort(int[,] processes, int NumOfProcesses, ref int[] ReadyQ, int ReadyNum) //priority sort
        {
            int min = 100;
            int temp;
            for (int i = 0; i < ReadyNum; i++)
            {
                for (int j = 0; j < NumOfProcesses; j++)
                    if (ReadyQ[i] == processes[j, 0])
                    {
                        if (processes[j, 3] < min) { min = processes[j, 3]; temp = ReadyQ[0]; ReadyQ[0] = ReadyQ[i]; ReadyQ[i] = temp; }
                    }
            }
        }
        static void sort(int[,] processes, int NumOfProcesses, ref int[] ReadyQ, int ReadyNum)// SJF sort
        {
            int min = 100;
            int temp;
            for (int i = 0; i < ReadyNum; i++)
            {
                for (int j = 0; j < NumOfProcesses; j++)
                    if (ReadyQ[i] == processes[j, 0])
                    {
                        if ((processes[j, 2] < min) && (processes[j, 2] > 0)) { min = processes[j, 2]; temp = ReadyQ[0]; ReadyQ[0] = ReadyQ[i]; ReadyQ[i] = temp; }
                    }
            }
        }
        static void running(int ReadyQ0, ref int[,] processes, int NumOfProcesses, int time)
        {
            for (int i = 0; i < NumOfProcesses; i++)
            {
                if (ReadyQ0 == processes[i, 0])
                {
                    processes[i, 2]--;
                    Console.WriteLine("at the second {0}: processing p{1}", time, processes[i, 0]);
                    break;
                }
            }

        }
        static void dequeue(int[,] processes, int NumOfProcesses, ref int[] ReadyQ, ref int ReadyNum)
        {
            for (int i = 0; i < NumOfProcesses; i++)
            {
                if (ReadyQ[0] == processes[i, 0])
                {
                    if (processes[i, 2] == 0)
                    {
                        ReadyNum--;
                        ReadyQ[0] = ReadyQ[ReadyNum];
                    }
                }
            }
        }

    }
}


//namespace OStest1
//{
//    class Program
//    {
//        static void Psort(int[,] processes, int NumOfProcesses, ref int[] ReadyQ, int ReadyNum) //priority sort
//        {
//            int min = 100;
//            int temp;
//            for (int i = 0; i < ReadyNum; i++)
//            {
//                for (int j = 0; j < NumOfProcesses; j++)
//                    if (ReadyQ[i] == processes[j, 0])
//                    {
//                        if (processes[j, 3] < min) { min = processes[j, 3]; temp = ReadyQ[0]; ReadyQ[0] = ReadyQ[i]; ReadyQ[i] = temp; }
//                    }
//            }
//        }
//        static void sort(int[,] processes, int NumOfProcesses, ref int[] ReadyQ, int ReadyNum)// SJF sort
//        {
//            int min = 100;
//            int temp;
//            for (int i = 0; i < ReadyNum; i++)
//            {
//                for (int j = 0; j < NumOfProcesses; j++)
//                    if (ReadyQ[i] == processes[j, 0])
//                    {
//                        if ((processes[j, 2] < min) && (processes[j, 2] > 0)) { min = processes[j, 2]; temp = ReadyQ[0]; ReadyQ[0] = ReadyQ[i]; ReadyQ[i] = temp; }
//                    }
//            }
//        }
//        static void running(int ReadyQ0, ref int[,] processes, int NumOfProcesses, int time)
//        {
//            for (int i = 0; i < NumOfProcesses; i++)
//            {
//                if (ReadyQ0 == processes[i, 0])
//                {
//                    processes[i, 2]--;
//                    Console.WriteLine("at the second {0}: processing p{1}", time, processes[i, 0]);
//                    break;
//                }
//            }

//        }
//        static void dequeue(int[,] processes, int NumOfProcesses, ref int[] ReadyQ, ref int ReadyNum)
//        {
//            for (int i = 0; i < NumOfProcesses; i++)
//            {
//                if (ReadyQ[0] == processes[i, 0])
//                {
//                    if (processes[i, 2] == 0)
//                    {
//                        ReadyNum--;
//                        ReadyQ[0] = ReadyQ[ReadyNum];
//                    }
//                }
//            }
//        }

//        static void Main(string[] args)
//        {
//            //int NumOfProcesses = 5;
//            //// process name, arrival time, burst time, priority
//            //int[,] processes = new int[5, 4] { { 1, 0, 4, 1 }, { 2, 0, 3, 0 }, { 3, 1, 1, 4 }, { 4, 10, 5, 6 }, { 5, 12, 2, 3 } };
//            //Console.WriteLine("choose required algorithm");
//            //Console.WriteLine("     press 1 for preemptive SJF");
//            //Console.WriteLine("     press 2 for non-preemptive SJF");
//            //Console.WriteLine("     press 3 for preemptive Priority");
//            //Console.WriteLine("     press 4 for non-preemptive Priority");
//            //int algorithm = Convert.ToInt32(Console.ReadLine());
//            int[] ReadyQ = new int[5];
//            int ReadyNum = 0;
//            int PreTop = -1;
//            int time = 0;
//            bool finished = true;
//            while (finished)
//            {
//                // lookking for new processes to enter the ready queue
//                for (int i = 0; i < ; i++)
//                {
//                    if (processes[i, 1] == time) { ReadyQ[ReadyNum] = processes[i, 0]; ReadyNum++; }
//                }

//                // sorting according to required algorithm
//                if (scheuling_Algorithim == 1)
//                {
//                    sort(processes, NumOfProcesses, ref ReadyQ, ReadyNum); //preemptive SJF
//                }
//                else if (scheuling_Algorithim == 2)
//                {
//                    if (PreTop != ReadyQ[0])
//                        sort(processes, NumOfProcesses, ref ReadyQ, ReadyNum);  //non-preemptive SJF
//                    PreTop = ReadyQ[0];
//                }
//                else if (scheuling_Algorithim == 3)
//                {
//                    Psort(processes, NumOfProcesses, ref ReadyQ, ReadyNum); //preemptive priority
//                }
//                else if (scheuling_Algorithim == 4)
//                {
//                    if (PreTop != ReadyQ[0])
//                        Psort(processes, NumOfProcesses, ref ReadyQ, ReadyNum);//non-preemptive priority
//                    PreTop = ReadyQ[0];
//                }


//                if (ReadyNum == 0) Console.WriteLine("at the second {0}: No processes yet", time);
//                else
//                {
//                    running(ReadyQ[0], ref processes, NumOfProcesses, time); //running the top queue process if there is any
//                    dequeue(processes, NumOfProcesses, ref ReadyQ, ref ReadyNum); //removing the 0 remaining time process from ReadyQ if there is any
//                }
//                // checking if all processes have 0 remaining time then processing has been finished
//                int counter = 0;
//                for (int i = 0; i < NumOfProcesses; i++)
//                {
//                    if (processes[i, 2] == 0) counter++;
//                }
//                if (counter == NumOfProcesses) finished = false;
//                else time++;
//            }
//            Console.WriteLine("Finished processing at {0} second.", time + 1);
//            Console.ReadKey();
//        }
//    }
//}