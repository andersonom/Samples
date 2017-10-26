using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Client
    {
        public enum TipoCliente { Gold = 1, Silver = 2 }

        public class Cliente
        {
            public int ClienteId { get; set; }
            public string Nome { get; set; }
            public DateTime DataCadastro { get; set; }
            public TipoCliente TipoCliente { get; set; }
            public virtual bool ClienteEspecial()
            {
                return DataCadastro.Year < 2010;
            }
            public virtual decimal CalcularDesconto(decimal valor)
            {
                switch (TipoCliente)
                {
                    case TipoCliente.Gold:
                        return valor * 0.40m; //desconto de 60%
                    case TipoCliente.Silver:
                        return valor * 0.80m; //Desconto de 20%
                    default:
                        return valor;
                }
            }
        }

        public class PossivelCliente : Cliente
        {
            public int PossivelClienteId { get; set; }

            public override decimal CalcularDesconto(decimal valor)
            {
                return base.CalcularDesconto(valor);
            }

            public override bool ClienteEspecial()
            {
                //Ops, eu ainda não sou cliente, muito menos especial
                throw new NotImplementedException();
            }
        }
    }
}
