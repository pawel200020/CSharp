namespace Lab1
{
    public class DialogParser
    {
        Hero hero;
        public DialogParser(Hero hero)
        {
            this.hero = hero;
        }
        public string ParseDialog(IDialogPart dialog)
        {
            string variable = "#HERONAME#";
            string dialogToParse = dialog.getDialog();
            string result;
            if (dialogToParse.Contains(variable))
            {
                result = dialogToParse.Replace(variable, hero.GetName());
                return result;

            } else
            {
                return dialogToParse;
            }
            
        }
    }
}
