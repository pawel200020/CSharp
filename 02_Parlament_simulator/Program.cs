using System;

namespace Parlament
{
    public delegate void StartVote(string voteTitle);
    public delegate void EndVote();
    public delegate void AddVote(bool a);

    class Program
    {
        public static void Main()
        {
            Conduct_a_vote c1 = new Conduct_a_vote(20, "Polexit", "Poland");
            c1.Vote();
            Console.WriteLine("----------------------------------------------------------");
            Conduct_a_vote c2 = new Conduct_a_vote(15, "Delegalise Diesel cars", "Russia");
            c2.Vote();
        }
    }
}
