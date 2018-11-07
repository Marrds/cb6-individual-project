using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectRev3
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public bool UnRead { get; set; }
        public DateTime DateAndTime { get; set; }



        //navigation property
        public virtual User User { get; set; }
        
        // polla minimata exoyn enan paralipti
        //foreing key apo tin klasi tou user
        public int userId { get; set; }
        

        




    }
}
