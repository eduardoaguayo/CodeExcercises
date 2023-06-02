using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HitssMeridianLink
{
    class Program
    {
        static void Main(string[] args)
        {
            LouisianaMarathon marathon = new LouisianaMarathon();

            marathon.Winner();
            marathon.CountByCategory();
            marathon.WinnerByCategory();


            SortedList sorted = new SortedList();

            int[] lst1 = { 2,3,5 };
            int[] lst2 = { 8,9,6 };
            sorted.CombinedArraySorted(lst1, lst2);

            Solution solution = new Solution();
            //Sorry por esto, fue de último momento :P
            ListNode lst = new ListNode();
            ListNode list = new ListNode(5,lst);
            ListNode lssst = new ListNode(6, list);
             
            solution.RemoveNthFromEnd(lssst, 2);

            Console.WriteLine("Hello World!");
        }

      

    }
    
    public class MarathonParticipants
    {
      public int ParticipantNumber { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Club { get; set; }
        public DateTime Time { get; set; }
        internal static MarathonParticipants ParseLine(string line)
        {
            var column = line.Split(',');

            return new MarathonParticipants()
            {
                ParticipantNumber = int.Parse(column[0]),
                Name = column[1],
                Category = column[2],
                Club = column[3],
                Time = DateTime.Parse(column[4])
            };
        }
    }
    //LOUISIANA MARATHON
    public class LouisianaMarathon
    {
        public IEnumerable CountByCategory()
        {

            var lst = GetList();

            var bycategory = from l in lst
                             group l by l.Category into grp
                             select new
                             {
                                 Category = grp.Key,
                                 Count = grp.Count()
                             };
            return bycategory;
        }
        public string Winner()
        {
            var lst = GetList();

            var winnerlist = from l in lst
                             orderby l.Time ascending
                             select l.Name;
            string winner = winnerlist.FirstOrDefault().ToString();
            return winner;


        }
        public IEnumerable WinnerByCategory()
        {
            var lst = GetList();
            var winnerlist = from l in lst
                             group l by l.Category
                             into grps
                             select grps.OrderBy(p => p.Time).First();


            return winnerlist;



        }
        public List<MarathonParticipants> GetList()
        {
            var lst = File.ReadAllLines("C:/Users/Eduardo/source/repos/HitssMeridianLink/HitssMeridianLink/Program.cs")
              .Skip(1)
              .Where(row => row.Length > 0)
             .Select(MarathonParticipants.ParseLine).ToList();
            return lst;
        }
    }
    //MERGE TWO SORTED LISTS
    public class SortedList
    {
        public int[] CombinedArraySorted(int[] lst1, int[] lst2)
        {
            int[] combined = new int[lst1.Length + lst2.Length];

            Array.Copy(lst1, combined, lst1.Length);
            Array.Copy(lst2, 0, combined, lst1.Length, lst2.Length);
            Array.Sort(combined);

            return combined;
        }
    }
    //REMOVE Nth NODE FROM END OF LIST
 public class ListNode {
 public int val;
 public ListNode next;
 public ListNode(int val=0, ListNode next=null) {
 this.val = val;
 this.next = next;
 }

        }
 

    public class Solution
    {

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode  actual = head;

            int count = 0;

            while(actual != null && actual.next != null)
            {
                count++;
                actual = actual.next;
            }

            int deletion = count - n;

            if(deletion <0)
            {
                head = head.next;
                return head;
            }

            ListNode dmmy = head;
          

            for(int i= 0; i< deletion; i++)
            {
                dmmy = dmmy.next;
            }

            dmmy.next = dmmy.next.next;

            return head;
        }
    }
    


}
