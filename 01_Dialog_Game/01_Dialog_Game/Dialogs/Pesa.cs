using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Pesa
    {
        public static void TalkToPesa(NonPlayerCharacter character, DialogParser parser)
        {
            List<NpcDialogPart> npcdialogs = new List<NpcDialogPart>();
            List<HeroDialogPart> herodialogs = new List<HeroDialogPart>();
            int deepthNpc = 0;
            int deepthHero = 0;
            npcdialogs.Add(character.StartTalking());
            npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
            npcdialogs[deepthNpc].addHeroResponse("Yes please");
            npcdialogs[deepthNpc].addHeroResponse("Sorry not today");
            npcdialogs[deepthNpc].SaySth();
            herodialogs.Add(npcdialogs[deepthNpc].PossibleAnswersAndReturnResult());
            herodialogs[deepthNpc].setDialog(parser.ParseDialog(herodialogs[deepthHero]));
            if (herodialogs[deepthHero].getDialog() == "Yes please")
            {
                deepthNpc++;
                herodialogs[deepthHero].addNpcResponse("You have got 100 gold #HERONAME#");
                npcdialogs.Add(herodialogs[deepthHero].getResponse());
                npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
                npcdialogs[deepthNpc].SaySth();
                npcdialogs[deepthNpc].addHeroResponse("I want to buy a BaCa dark theme");
                npcdialogs[deepthNpc].addHeroResponse("I want to buy a sausage");
                deepthHero++;
                herodialogs.Add(npcdialogs[deepthNpc].PossibleAnswersAndReturnResult());
                herodialogs[deepthNpc].setDialog(parser.ParseDialog(herodialogs[deepthHero]));
                if (herodialogs[deepthHero].getDialog() == "I want to buy a sausage")
                {
                    herodialogs[deepthHero].addNpcResponse("Here you have 20 gold left on your account, do you want to give me a tip #HERONAME# ?");
                    deepthNpc++;
                    npcdialogs.Add(herodialogs[deepthHero].getResponse());
                    npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
                    npcdialogs[deepthNpc].SaySth();
                    npcdialogs[deepthNpc].addHeroResponse("Yes of course");
                    npcdialogs[deepthNpc].addHeroResponse("Sorry not today");
                    deepthHero++;
                    herodialogs.Add(npcdialogs[deepthNpc].PossibleAnswersAndReturnResult());
                    herodialogs[deepthNpc].setDialog(parser.ParseDialog(herodialogs[deepthHero]));
                    if (herodialogs[deepthHero].getDialog() == "Yes of course")
                    {
                        herodialogs[deepthHero].addNpcResponse("Thank you #HERONAME#");
                        deepthNpc++;
                        npcdialogs.Add(herodialogs[deepthHero].getResponse());
                        npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
                        npcdialogs[deepthNpc].SaySth();
                        return;
                    }
                    else if (herodialogs[deepthHero].getDialog() == "Sorry not today")
                    {
                        herodialogs[deepthHero].addNpcResponse("You are not honest person #HERONAME#");
                        deepthNpc++;
                        npcdialogs.Add(herodialogs[deepthHero].getResponse());
                        npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
                        npcdialogs[deepthNpc].SaySth();
                        return;
                    }
                }
                else if (herodialogs[deepthHero].getDialog() == "I want to buy a BaCa dark theme")
                {
                    herodialogs[deepthHero].addNpcResponse("Sory not in stock #HERONAME#");
                    deepthNpc++;
                    npcdialogs.Add(herodialogs[deepthHero].getResponse());
                    npcdialogs[deepthNpc].setDialog(parser.ParseDialog(npcdialogs[deepthNpc]));
                    npcdialogs[deepthNpc].SaySth();
                    return;
                }
            }
            else if (herodialogs[deepthHero].getDialog() == "Sorry not today")
            {
                return;
            }


        }
    }
}
