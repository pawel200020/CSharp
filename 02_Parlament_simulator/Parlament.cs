using System;
using System.Collections.Generic;

namespace Parlament
{
    class Parlament
    {
        private string _name;
        public string name => _name;
        private string _lastvotename;
        private List<Parliamentarian> parlamentarians = new List<Parliamentarian>();

        public event StartVote startVote;
        public event EndVote endVote;

        public Parlament(string name)
        {
            parlamentarians = new List<Parliamentarian>();
            _name = name;
        }

        public void AddParliamentarian(Parliamentarian parliamentarian)
        {
            parlamentarians.Add(parliamentarian);
        }
        public void StartVote(string votename)
        {
            Console.WriteLine("Parlament no. " + _name + " is starting voting for " + votename);
            _lastvotename = votename;
            startVote?.Invoke(votename);

        }
        public void EndVote()
        {
            Console.WriteLine("Parlament no. " + _name + " ended a vote query");
            endVote?.Invoke();
        }
        public void GetLastVoteResult()
        {
            int[] result = new int[parlamentarians.Count];
            foreach (var item in parlamentarians)
            {
                if (item.ReturnVote() == true)
                {
                    result[0] += 1;
                }
                else
                {
                    result[1] += 1;
                }
            }
            Console.WriteLine("Vote " + _lastvotename + " results:");
            Console.WriteLine("Voted for: " + result[0]);
            Console.WriteLine("Voted against: " + result[1]);
        }
        

        public void SubscribeParlamentariansVote()
        {
            foreach (var item in parlamentarians)
            {
                item.SubscribeToVote(this);
            }
        }
        public void UnSubscribeParlamentariansVote()
        {
            foreach (var item in parlamentarians)
            {
                item.UnSubscribeFromVote(this);
            }
        }
        public void SubscribeParlamentariansEndEvent()
        {
            foreach (var item in parlamentarians)
            {
                item.SubscribeToEndEvent(this);
            }
        }
        public void UnSubscribeParlamentariansEndEvent()
        {
            foreach (var item in parlamentarians)
            {
                item.UnsubscribeFromEnd(this);
            }
        }
    }
}
