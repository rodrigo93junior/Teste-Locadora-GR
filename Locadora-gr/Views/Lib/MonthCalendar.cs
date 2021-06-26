using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    namespace Lib
    {
        class Calendario : MonthCalendar
        {
            public Calendario(
                Point Location
            )
            {
                this.Location = Location;
            }
        }
    }
}