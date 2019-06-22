using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(new[] {"12:12:12"}, new [] { "few seconds ago" }, "12:12:12");
            Test(new[] { "23:23:23", "23:23:23" }, new[] { "59 minutes ago", "59 minutes ago" }, "00:22:23");
            Test(new[] { "00:10:10", "00:10:10" }, new[] { "59 minutes ago", "1 hours ago" }, "impossible");
            Test(new[] { "11:59:13", "11:13:23", "12:25:15" }, new[] { "few seconds ago", "46 minutes ago", "23 hours ago" }, "11:59:23");
            Console.ReadKey(true);
        }

        private static void Test(string[] postTimes, string[] showTimes, string expected)
        {
            var result = GetCurrentTime(postTimes, showTimes).Equals(expected) ? "PASS" : "FAIL";
            var postTimesCsv = string.Join(", ", postTimes);
            var showTimesCsv = string.Join(", ", showTimes);
            Console.WriteLine($"[{postTimesCsv}], [{showTimesCsv}] => {result}");
        }

        public static string GetCurrentTime(string[] exactPostTime, string[] showPostTime)
        {
            int size = exactPostTime.Length; // total "size" posts are there.
            for(int i=0;i<size-1;i++)
            {
                for(int j=i+1;j<size;j++)
                {
                    if(exactPostTime[i]==exactPostTime[j])
                    {
                        if(showPostTime[i]!=showPostTime[j])
                        {
                            return "impossible"; // to check if relevant post-time and showposttime are equally corresponding if equal.
                        }
                        else
                            continue;
                    }
                }
            }
            string[] result = new string[size]; // results of all the posts are stored in a string array.
            for(int i=0;i<size;i++)
            {
                result[i] = finder(exactPostTime[i],showPostTime[i]);
            }
            Array.Sort(result); // to know the current time of now.
            return result[size-1]; // this is the current time.
        
        }
         public static string finder(string exactPostTime_i, string showPostTime_i)
         {
             string[] s1 = exactPostTime_i.Split(':'); // split the time by : to get the hour, minute and second strings separately
             string[] s2 = showPostTime_i.Split(' '); // To know the X->value and if its seconds, minutes and hour ago
             int hh = int.Parse(s1[0]); // parsed hour value.
             int mm = int.Parse(s1[1]); // Parsed minute value.
             int ss = int.Parse(s1[2]); // Parsed seconds Value.
             int ssnow=ss; // To calculate the current time seconds.
             int mmnow=mm; // To calculate the current time minutes.
             int hhnow=hh; // To calculate the current time hours.
             if(showPostTime_i=="few seconds ago")
             {
                 ssnow = ss+59;
                 if(ssnow>=60)
                 {
                     mmnow=mm+1;
                     ssnow=ssnow%60;
                     if(mmnow>=60)
                     {
                         hhnow=hhnow+1;
                         mmnow=mmnow%60;
                     }
                     if(hhnow>=24)
                     {
                         hhnow=hhnow%24;
                     }
                 }
                 
                 int set=0; // signifies if hour value is lesser then new value.
                 
                 if(hh<=hhnow)
                    set=0;
                 else
                    set=1;
                    
                 if(set==0)
                 {
                    hhnow=hh;//we are returning hhnow, mmnow and ssnow always so returned the same value if previous value of hh was lesser.
                    mmnow=mm;//" " " for mm.
                    ssnow=ss;//" "  " for ss.
                 }
             }
             
             if(s2[1]=="minutes")
             {
                 int min = int.Parse(s2[0]); // parse the value how many minutes ago the post was made
                 mmnow+=min; // add to new time
                 if(mmnow>59)
                 {
                     hhnow+=1;
                     mmnow%=60;
                     if(hhnow>23)
                     {
                         hhnow%=24;
                     }
                 }
             }
             
             if(s2[1]=="hours")
             {
                 int hour = int.Parse(s2[0]); // parse the value how many hour ago the post was made.
                 hhnow+=hour;
                 if(hhnow>23)
                 {
                     hhnow%=24;
                 }
             }
              TimeSpan tt =new TimeSpan(hhnow,mmnow,ssnow); // will convert the hh,mm,ss format to hh:mm:ss format
              string r = tt.ToString(); // converted TimeSpan to a string to return it.
              return r;
         }
    }
}
