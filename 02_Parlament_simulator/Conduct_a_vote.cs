using System;
using System.Collections.Generic;

namespace Parlament
{
    class Conduct_a_vote
    {
        int _parlamentarianquantity;
        string _votename;
        Parlament _parlament;
        public Conduct_a_vote(int parlamentarianquantity, string votename, string parlamentName)
        {
            _parlamentarianquantity = parlamentarianquantity;
            _votename = votename;
            _parlament = new Parlament(parlamentName);          
        }
        private void GenerateParlamentarians()
        {
            for (int i = 0; i < _parlamentarianquantity; i++)
            {
                Parliamentarian _parlamentarian = new Parliamentarian(i);
                _parlament.AddParliamentarian(_parlamentarian);
            }
        }
        public void Vote()
        {
            GenerateParlamentarians();
            _parlament.SubscribeParlamentariansVote();
            _parlament.StartVote(_votename);
            _parlament.UnSubscribeParlamentariansVote();
            _parlament.SubscribeParlamentariansEndEvent();
            _parlament.EndVote();
            _parlament.UnSubscribeParlamentariansEndEvent();
            _parlament.GetLastVoteResult();
        }      
    }
}
