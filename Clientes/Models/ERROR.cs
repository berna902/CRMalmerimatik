using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clientes.Models
{
    public class ERROR
    {
        public int cod;
        public string msg;

        public ERROR(int COD, string MSG) {
            this.cod = COD;
            this.msg = MSG;
        }

        public ERROR() {
            this.cod = -1;
            this.msg = "SIN VALOR";
        }
    }
}