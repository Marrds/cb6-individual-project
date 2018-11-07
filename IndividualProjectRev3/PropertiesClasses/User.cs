using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int LevelOfAccess { get; set; }

        //enas user exei polla minimata
        //navigation property
        public virtual ICollection<Message> Messages { get; set; }



    }
}
