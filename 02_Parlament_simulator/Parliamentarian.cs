using System;

namespace Parlament
{
    class Parliamentarian
    {
        private int _id;
        bool _vote;
        bool isVotingAvaible;
        public event AddVote addVote;
        public Parliamentarian(int id)
        {
            _id = id;
            isVotingAvaible = false;
        }

        public bool ReturnVote()
        {
            return _vote;
        }
       
        
        private void Begin(string votename)
        {
            Random random = new Random();
            addVote += Votelogic;
            isVotingAvaible = true;
            addVote?.Invoke(random.Next(2) == 1);
            Console.WriteLine(_id + " voted " + votename+ " with result: "+_vote);
        }
        private void End()
        {
            Console.WriteLine(_id+": Vote query ended");
            isVotingAvaible = false;
            addVote -= Votelogic;
        }
        private void Votelogic(bool a)
        {
            if (isVotingAvaible == true)
            {
                _vote = a;
            }
            else
            {
                Console.WriteLine("You cannot vote this time!");
            }
        }


        public void SubscribeToVote(Parlament parlament)
        {
            Console.WriteLine("parlametarian no. " + _id + " has been subscribed to parlament " + parlament.name);
            parlament.startVote += Begin;
        }
        public void UnSubscribeFromVote(Parlament parlament)
        {
            Console.WriteLine(_id + ": I am unsubscribing my vote method");
            parlament.startVote -= Begin;

        }
        public void SubscribeToEndEvent(Parlament parlament)
        {
            parlament.endVote += End;
        }
        public void UnsubscribeFromEnd(Parlament parlament)
        {
            parlament.endVote -= End;
        }
    }
}
