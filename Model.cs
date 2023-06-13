using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    internal class Model
    {
        protected DBConnect db;
        public Model()
        {
            db = DBConnect.getInstance();
        }
    }
}
