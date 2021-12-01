using System;

namespace Lab1
{
    public class HeroDialogPart : IDialogPart
    {
        string dialog;
        NpcDialogPart npcDialog;
        public HeroDialogPart(string dialog)
        {
            this.dialog = dialog;
        }
        public void SaySth()
        {
            Console.WriteLine(dialog);
        }
        public void addNpcResponse(string dialog)
        {
            NpcDialogPart res = new NpcDialogPart(dialog);
            npcDialog = res;
        }
        public NpcDialogPart getResponse()
        {
            return npcDialog;
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
