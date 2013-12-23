﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class VisitorAtCamping : Visitor
    {
        //Field
        int? spotid;

        //Constructor
        public VisitorAtCamping(int visitor_id, String rfid, String first_name, String last_name, Decimal balance, int spotid)
            : base(visitor_id, rfid, first_name, last_name, balance)
        {
            this.spotid = spotid;
        }

        //Properties
        public int? SpotID { get { return this.spotid; } }

        //Methods
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
