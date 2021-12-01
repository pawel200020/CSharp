using System;
using System.Collections.Generic;

namespace Lab1
{
    public class NpcDialogPart: IDialogPart
    {
        string dialog;
        List<HeroDialogPart> heroDialogs;
        public NpcDialogPart(string dialog)
        {
            this.dialog = dialog;
            heroDialogs = new List<HeroDialogPart>();
        }
        public void addHeroResponse (string herodialog)
        {
            HeroDialogPart dialog = new HeroDialogPart(herodialog);
            heroDialogs.Add(dialog);
        }
        public void SaySth()
        {
            Console.WriteLine(dialog);
        }
        public HeroDialogPart PossibleAnswersAndReturnResult ()
        {
            int i = 1;
            foreach (var item in heroDialogs) 
            {
                Console.Write("["+i+"] ");
                i++;
                item.SaySth();
            }
            int command = -1;
            while (true)
            {
                command = Convert.ToInt32(Console.ReadLine());
                if(command>0 && command < i)
                {
                    return heroDialogs[ command - 1];
                }
                else
                {
                    MenuDialogs.WrongCommand();
                }
            }
        }
        public string getDialog()
        {
            return dialog;
        }
        public void setDialog(string s) 
        {
            dialog = s;
        }

    }
}
