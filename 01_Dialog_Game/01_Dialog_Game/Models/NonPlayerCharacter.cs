using System.Collections.Generic;

namespace Lab1
{
    public class NonPlayerCharacter
    {
        string name;
        string dialog;
        List <HeroDialogPart> heroResponses;
        public NonPlayerCharacter(string name, string firstTalk)
        {
            this.name = name;
            this.dialog = firstTalk;
        }
        public NonPlayerCharacter()
        {
            name = null;
            dialog = null;
        }
        public NpcDialogPart StartTalking()
        {
            return new NpcDialogPart(dialog);
        }
        public string GetName()
        {
            return name;
        }
    }
}