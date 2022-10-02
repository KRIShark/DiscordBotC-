using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBeamMpServersDCBot.data
{
    public class BeamMP_Config
    {
        public BeamMP_Config()
        {

        }

        public BeamMP_Config(bool updateAuto)
        {
            UpdateAuto = updateAuto;
        }

        public BeamMP_Config(bool updateAuto, int messageIdOfTheStatusMessge)
        {
            UpdateAuto = updateAuto;
            MessageIdOfTheStatusMessge = messageIdOfTheStatusMessge;
        }

        public bool UpdateAuto { get; set; } = false;
        public int MessageIdOfTheStatusMessge { get; set; }
    }
}
