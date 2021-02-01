using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        
        public class InfoBlocs
        {
            Program prgm;


            public List<IMyBatteryBlock> listAllBattery = new List<IMyBatteryBlock>();
            public List<IMyBatteryBlock> listGroupBattery = new List<IMyBatteryBlock>();

            public List<IMyTerminalBlock> listBlocs = new List<IMyTerminalBlock>();
            

            public void Init(Program _prgm)
            {
                prgm = _prgm;
                prgm.GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(listAllBattery);
                prgm.GridTerminalSystem.GetBlocks(listBlocs);

                
            }



            public void FindBatGrpWithName(string nameGroup)
            {
                if (prgm.GridTerminalSystem.GetBlockGroupWithName(nameGroup) == null) return;

                prgm.GridTerminalSystem.GetBlockGroupWithName(nameGroup).GetBlocksOfType(listGroupBattery);
            }


            #region <--: DEBUG :-->

            public void ShowDebugBlocUtility()
            {

                if (listAllBattery.Count != 0)
                {
                    prgm.Echo("Nbs total de batterie: " + listAllBattery.Count);

                    foreach (IMyBatteryBlock batteryBlock in listAllBattery)
                    {
                        prgm.Echo("Name Battery: " + batteryBlock.CustomName);
                        prgm.Echo("Charge Mode: " + batteryBlock.ChargeMode);
                    }
                }


                if (listGroupBattery.Count != 0)
                {
                    prgm.Echo("~~~~  GroupName: " + prgm._nameGroupBattery + " ~~~~ Total: " + listGroupBattery.Count);
                    foreach (IMyBatteryBlock batteryGroupBlock in listGroupBattery)
                    {
                        prgm.Echo("Name : ~~~~ " + batteryGroupBlock.CustomName + " ~~~~");
                        prgm.Echo("Charge Mode: " + batteryGroupBlock.ChargeMode);
                    }
                    prgm.Echo("~~~~~~ Fin Group: " + prgm._nameGroupBattery + " ~~~~~~");
                }


                prgm.Echo("~~~~~~ ALL BLOCS ~~~~~~ "+listBlocs.Count);
                foreach (var item in listBlocs)
                {
                    //firstVariatChanges.First(line => line.Status == LineStatus.FirstEmptyRow)
                    prgm.Echo(item.BlockDefinition.TypeId.ToString());
                }
            }
            #endregion
        }
    }
}
