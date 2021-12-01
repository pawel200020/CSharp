using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab1
{
    public static class Akara
    {
        public static void TalkToAkara(NonPlayerCharacter character, DialogParser parser)
        {
            List<NpcDialogPart> npcdialogs = new List<NpcDialogPart>();
            List<HeroDialogPart> herodialogs = new List<HeroDialogPart>();
            int deepthNpc = 0;
            int deepthHero = 0;
            npcdialogs.Add(character.StartTalking());
            npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
            npcdialogs[deepthNpc].addHeroResponse("Yes I can");
            npcdialogs[deepthNpc].addHeroResponse("No I can't");
            npcdialogs[deepthNpc].SaySth();
            herodialogs.Add(npcdialogs[deepthNpc].PossibleAnswersAndReturnResult());
            herodialogs[deepthNpc].setDialog( parser.ParseDialog(herodialogs[deepthHero]));
            if(herodialogs[deepthHero].getDialog()== "Yes I can")
            {
                deepthNpc++;
                herodialogs[deepthHero].addNpcResponse("Thank you, You will recive 100 gold");
                npcdialogs.Add( herodialogs[deepthHero].getResponse());
                npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
                npcdialogs[deepthNpc].SaySth();
                npcdialogs[deepthNpc].addHeroResponse("I will tell you if I am ready");
                npcdialogs[deepthNpc].addHeroResponse("100 gold is not enough!");
                deepthHero++;
                herodialogs.Add( npcdialogs[deepthNpc].PossibleAnswersAndReturnResult());
                herodialogs[deepthNpc].setDialog(parser.ParseDialog(herodialogs[deepthHero]));
                if (herodialogs[deepthHero].getDialog() == "100 gold is not enough!")
                {
                    herodialogs[deepthHero].addNpcResponse("I am very poor, I do not have more money :-( ");
                    deepthNpc++;
                    npcdialogs.Add(herodialogs[deepthHero].getResponse());
                    npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
                    npcdialogs[deepthNpc].SaySth();
                    npcdialogs[deepthNpc].addHeroResponse("OK, lets do this for 100 gold");
                    npcdialogs[deepthNpc].addHeroResponse("Sorry I cant help you");
                    deepthHero++;
                    herodialogs.Add(npcdialogs[deepthNpc].PossibleAnswersAndReturnResult());
                    herodialogs[deepthNpc].setDialog(parser.ParseDialog(herodialogs[deepthHero]));
                    if (herodialogs[deepthHero].getDialog() == "OK, lets do this for 100 gold")
                    {
                        herodialogs[deepthHero].addNpcResponse("Thank you #HERONAME#");
                        deepthNpc++;
                        npcdialogs.Add(herodialogs[deepthHero].getResponse());
                        npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
                        npcdialogs[deepthNpc].SaySth();
                        return;
                    }
                    else if(herodialogs[deepthHero].getDialog() == "Sorry I cant help you")
                    {
                        return;
                    }
                }
                else if(herodialogs[deepthHero].getDialog() == "I will tell you if I am ready")
                {
                    return;
                }
            } else if(herodialogs[deepthHero].getDialog() == "No I can't")
            {
                return;
            }

        }

    }
}
