﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    class FlyState : IMoveState
    {
        public void Move()
        {
            throw new NotImplementedException();
        }
        public override String ToString() { return $"{this.GetType().Name}"; }
    }
}
